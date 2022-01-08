using System;
using System.Linq;
using System.Text.Json;
using Converter.JsonTemplate;
using Converter.SystemTemplate;

namespace Server.Services.Commands
{
    public class CreateCommand : ICommand
    {
        private StaffContext _database;
        private Client _client;
        private string[] _args;

        public CreateCommand(StaffContext database, Client client, params string[] args)
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
                    CreateStaff();
                    break;

                case "task":
                    CreateTask();
                    break;

                case "report":
                    CreateReport();
                    break;
            }
        }

        private void CreateStaff()
        {
            try
            {
                UserTemplate enterData = null;
                if (_client != null)
                    enterData = JsonSerializer.Deserialize<UserTemplate>(_args[_args.Length - 1]);
                UserTemplate staff = JsonSerializer.Deserialize<UserTemplate>(_args[2]);

                if (staff.name == null || staff.name == string.Empty)
                    throw new Exception("Empty name field");
                if (staff.password == null || staff.password == string.Empty)
                    throw new Exception("Empty password field");

                User boss = _database.Users.FirstOrDefault(u => u.Id == staff.intBossid);
                if (boss == null && enterData != null)
                    throw new Exception("There are no staff with such a boss ID");
                if (enterData != null && !_database.Users.FirstOrDefault(u => u.Id == enterData.intId).StaffExists(boss))
                    throw new Exception("The staff with such a boss ID does not obey you");

                if (enterData != null)
                    staff.intSecuritylevel = boss.SecurityLevel + 1;
                else if (staff.intSecuritylevel == 0)
                    staff.intSecuritylevel = 1;

                if (_database.Users.FirstOrDefault(u => u.Name == staff.name && u.Password == staff.password) != null)
                    throw new Exception("Such a user already exists");

                var newStaff = new User() { Name = staff.name, Password = staff.password, Boss = boss, SecurityLevel = staff.intSecuritylevel };
                _database.Users.Add(newStaff);
                _database.SaveChanges();
                //if (boss != null)
                //{
                //    boss.Staff.Add(newStaff);
                //    _database.SaveChanges();
                //}

                if (_client == null)
                    Console.WriteLine("Creating new staff - {0} Completed", staff.name);
                else
                    _client.SendAnswer("Creating new staff " + staff.name + " Completed\n");
            }
            catch (Exception ex)
            {
                if (_client == null)
                    Console.WriteLine("Creating new staff - Failed : " + ex.Message);
                else
                    _client.SendAnswer("Creating new staff - Failed : " + ex.Message);
            }
        }

        private void CreateTask()
        {
            try
            {
                UserTemplate enterData = null;
                if (_client != null)
                    enterData = JsonSerializer.Deserialize<UserTemplate>(_args[_args.Length - 1]);
                TaskTemplate task = JsonSerializer.Deserialize<TaskTemplate>(_args[2]);

                if (task.target == null || task.target == string.Empty)
                    throw new Exception("Empty target field");
                task.target = task.target.Replace("^&", " ");

                if (enterData != null)
                {
                    User staff = _database.Users.FirstOrDefault(n => n.Id == enterData.intId);
                    if (task.intNeedsecuritylevel != 0 && task.intNeedsecuritylevel < staff.SecurityLevel)
                        task.intNeedsecuritylevel = staff.SecurityLevel;
                }

                var newTask = new Task(task.target) { NeedSecurityLevel = task.intNeedsecuritylevel };
                _database.Tasks.Add(newTask);
                _database.SaveChanges();

                if (_client == null)
                    Console.WriteLine("Creating new task {0} - Completed", task.target);
                else
                    _client.SendAnswer("Creating new task " + task.target + " - Completed\n");
            }
            catch (Exception ex)
            {
                if (_client == null)
                    Console.WriteLine("Creating new task - Failed : " + ex.Message);
                else
                    _client.SendAnswer("Creating new task - Failed :  " + ex.Message);
            }
        }

        private void CreateReport()
        {
            try
            {
                UserTemplate enterData = null;
                if (_client != null)
                    enterData = JsonSerializer.Deserialize<UserTemplate>(_args[_args.Length - 1]);
                ReportTemplate report = JsonSerializer.Deserialize<ReportTemplate>(_args[2]);

                User staff = _database.Users.FirstOrDefault(u => u.Id == report.intStaffid);

                if (staff == null)
                    throw new Exception("Invalid staff ID");

                var newReport = new Report() { Name = report.name, Type = report.type, Staff = staff};
                _database.Reports.Add(newReport);
                _database.SaveChanges();

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
