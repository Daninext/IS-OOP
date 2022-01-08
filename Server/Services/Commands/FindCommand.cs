using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using Converter.JsonTemplate;
using Converter.SystemTemplate;

namespace Server.Services.Commands
{
    public class FindCommand : ICommand
    {
        private StaffContext _database;
        private Client _client;
        private string[] _args;

        public FindCommand(StaffContext database, Client client, params string[] args)
        {
            _database = database;
            _client = client;
            _args = args;
        }

        public void Execute()
        {
            switch (_args[1])
            {
                case "staff":
                    FindStaff();
                    break;

                case "task":
                    FindTask();
                    break;

                case "report":
                    FindReport();
                    break;
            }
        }

        private void FindStaff()
        {
            try
            {
                UserTemplate enterData = null;
                if (_client != null)
                    enterData = JsonSerializer.Deserialize<UserTemplate>(_args[_args.Length - 1]);
                UserTemplate staff = JsonSerializer.Deserialize<UserTemplate>(_args[2]);

                User findStaff = _database.Users.FirstOrDefault(u => u.Id == staff.intId);

                if (findStaff == null)
                    throw new Exception("Invalid staff ID");
                if (enterData != null && findStaff.SecurityLevel < _database.Users.FirstOrDefault(u => u.Id == enterData.intId).SecurityLevel)
                    throw new Exception("Access is restricted by the access level");

                if (_client == null)
                    Console.WriteLine("Staff information: " + findStaff.ToString());
                else
                    _client.SendAnswer("Staff information: " + findStaff.ToString());
            }
            catch (Exception ex)
            {
                if (_client == null)
                    Console.WriteLine("Finding staff - Failed : " + ex.Message);
                else
                    _client.SendAnswer("Finding staff - Failed : " + ex.Message);
            }
        }

        private void FindTask()
        {
            try
            {
                UserTemplate enterData = null;
                if (_client != null)
                    enterData = JsonSerializer.Deserialize<UserTemplate>(_args[_args.Length - 1]);
                TaskTemplate tempTask = JsonSerializer.Deserialize<TaskTemplate>(_args[2]);

                var allTasks = new List<Task>(_database.Tasks);

                var wrongTasks = new List<Task>();
                foreach(Task task in allTasks)
                {
                    if (tempTask.intId != 0 && tempTask.intId != task.Id)
                        wrongTasks.Add(task);

                    if (tempTask.createdtime != null 
                        && tempTask.createdtime != string.Empty 
                        && DateTime.Parse(tempTask.createdtime) != DateTime.Parse(task.CreatedTime))
                        wrongTasks.Add(task);

                    if (tempTask.lastchangetime != null
                        && tempTask.lastchangetime != string.Empty
                        && DateTime.Parse(tempTask.lastchangetime) != DateTime.Parse(task.LastChangeTime))
                        wrongTasks.Add(task);

                    if (tempTask.intStaffid != 0 && task.Staff != null && task.Staff.Id != tempTask.intStaffid)
                        wrongTasks.Add(task);

                    User staff = _database.Users.FirstOrDefault(u => u.Id == tempTask.intLaststaffid);
                    if (tempTask.intLaststaffid != 0 && staff != null && !task.StaffWorkedWithThisTask(staff))
                        wrongTasks.Add(task);

                    User boss = _database.Users.FirstOrDefault(b => b.Id == tempTask.intBybossid);
                    if (tempTask.intBybossid != 0 && boss != null && !task.IsInBossHierarchy(boss))
                        wrongTasks.Add(task);

                    if (enterData != null)
                    {
                        User enterStaff = _database.Users.FirstOrDefault(u => u.Id == enterData.intId);
                        if (task.NeedSecurityLevel != 0 && enterStaff.SecurityLevel > task.NeedSecurityLevel)
                            wrongTasks.Add(task);
                    }
                }

                foreach (Task del in wrongTasks)
                {
                    allTasks.Remove(del);
                }

                if (allTasks.Count == 0)
                    throw new Exception("Task not found");

                if (_client == null)
                    Console.WriteLine("Finding task - Completed");
                else
                    _client.SendAnswer("Finding task - Completed");

                foreach (Task goodTask in allTasks)
                {
                    if (_client == null)
                        Console.WriteLine(goodTask.ToString());
                    else
                        _client.SendAnswer(goodTask.ToString());
                }

            }
            catch (Exception ex)
            {
                if (_client == null)
                    Console.WriteLine("Finding task - Failed : " + ex.Message);
                else
                    _client.SendAnswer("Finding task - Failed : " + ex.Message);
            }
        }

        private void FindReport()
        {
            try
            {
                UserTemplate enterData = null;
                if (_client != null)
                    enterData = JsonSerializer.Deserialize<UserTemplate>(_args[_args.Length - 1]);
                ReportTemplate tempReport = JsonSerializer.Deserialize<ReportTemplate>(_args[3]);

                if (_args[2] == "read")
                {
                    User boss = _database.Users.FirstOrDefault(u => u.Id == enterData.intId);

                    var reports = new List<Report>();

                    foreach (Report report in _database.Reports)
                    {
                        if (report.Staff == boss && report.Type == tempReport.type && report.Resolved == tempReport.boolResolve)
                            reports.Add(report);
                    }

                    string message = "";
                    foreach (Report report in reports)
                    {
                        message += "\n";
                        message += report.ToString();
                    }

                    _client.SendAnswer("Your reports: " + message + "\n");

                    reports = new List<Report>();

                    foreach (User staff in boss.Staff)
                    {
                        foreach (Report report in _database.Reports)
                        {
                            if (report.Staff == staff && report.Type == tempReport.type && report.Resolved == tempReport.boolResolve)
                                reports.Add(report);
                        }
                    }

                    message = "";
                    foreach (Report report in reports)
                    {
                        message += "\n";
                        message += report.ToString();
                    }

                    _client.SendAnswer("Your staff reports: " + message + "\n");
                }
                else if (_args[2] == "write")
                {
                    Report report = _database.Reports.FirstOrDefault(r => r.Staff.Id == tempReport.intStaffid && r.Type == tempReport.type && !r.Resolved);

                    if (report == null)
                        _client.SendAnswer("system report " + JsonSerializer.Serialize<ReportTemplate>(new ReportTemplate()));
                    else
                        _client.SendAnswer("system report " + JsonSerializer.Serialize<ReportTemplate>(new ReportTemplate(report)));
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
