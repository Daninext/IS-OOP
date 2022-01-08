﻿using System;
using System.Linq;
using System.Text.Json;
using Converter.JsonTemplate;
using Converter.SystemTemplate;

namespace Server.Services.Commands
{
    public class UpdateCommand : ICommand
    {
        private StaffContext _database;
        private Client _client;
        private string[] _args;

        public UpdateCommand(StaffContext database, Client client, params string[] args)
        {
            _database = database;
            _client = client;
            _args = args;
        }

        public void Execute()
        {
            switch (_args[1])
            {
                case "task":
                    UpdateTask();
                    break;

                case "report":
                    UpdateReport();
                    break;
            }
        }

        private void UpdateTask()
        {
            try
            {
                TaskTemplate enterData = null;
                if (_client != null)
                    enterData = JsonSerializer.Deserialize<TaskTemplate>(_args[_args.Length - 1]);
                TaskTemplate tempTask = JsonSerializer.Deserialize<TaskTemplate>(_args[2]);

                User staff = _database.Users.FirstOrDefault(u => u.Id == enterData.intId);

                Task task = _database.Tasks.FirstOrDefault(t => t.Staff.Id == staff.Id && t.State != Task.StateType.Resolved);

                if (staff.StaffTask == null)
                    throw new Exception("You haven`t any task");
                if (task == null)
                    throw new Exception("This task is resolved");

                task.AddComment(tempTask.comment, staff);
                if (task.State != Task.StateType.Active)
                    task.ChangeState(Task.StateType.Active);

                _database.SaveChanges();

                if (_client == null)
                    Console.WriteLine("New comment added");
                else
                    _client.SendAnswer("New comment added\n");
            }
            catch (Exception ex)
            {
                if (_client == null)
                    Console.WriteLine("Creating new staff - Failed : " + ex.Message);
                else
                    _client.SendAnswer("Creating new staff - Failed : " + ex.Message);
            }
        }

        private void UpdateReport()
        {
            try
            {
                UserTemplate enterData = null;
                if (_client != null)
                    enterData = JsonSerializer.Deserialize<UserTemplate>(_args[_args.Length - 1]);
                ReportTemplate tempReport = JsonSerializer.Deserialize<ReportTemplate>(_args[2]);

                Report report = _database.Reports.FirstOrDefault(r => r.Type == tempReport.type && r.Staff.Id == tempReport.intStaffid && r.Resolved == false);

                report.Name = tempReport.name;
                report.Comment = tempReport.comment;
                report.Resolved = tempReport.boolResolve;

                _database.SaveChanges();

                if (_client != null)
                    _client.SendAnswer("Report saved");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
