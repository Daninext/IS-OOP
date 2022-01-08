using System;
using System.Linq;
using System.Text.Json;
using Converter.JsonTemplate;
using Converter.SystemTemplate;

namespace Server.Services.Commands
{
    public class SetCommand : ICommand
    {
        private StaffContext _database;
        private Client _client;
        private string[] _args;

        public SetCommand(StaffContext database, Client client, params string[] args)
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
                    SetTask();
                    break;
            }
        }

        private void SetTask()
        {
            try
            {
                TaskTemplate enterData = null;
                if (_client != null)
                    enterData = JsonSerializer.Deserialize<TaskTemplate>(_args[_args.Length - 1]);
                TaskTemplate tempTask = JsonSerializer.Deserialize<TaskTemplate>(_args[2]);

                User boss = _database.Users.FirstOrDefault(u => u.Id == enterData.intId);
                User staff = _database.Users.FirstOrDefault(u => u.Id == tempTask.intStaffid);
                Task task = _database.Tasks.FirstOrDefault(t => t.Id == tempTask.intId);

                if (staff == null)
                    throw new Exception("Invalid staff ID");
                if (task == null)
                    throw new Exception("Invalid task ID");

                if (task.NeedSecurityLevel != 0 && staff.SecurityLevel > task.NeedSecurityLevel)
                    throw new Exception("Staff has a low access level");

                staff.ChangeTask(boss, task);

                _database.SaveChanges();

                if (_client == null)
                    Console.WriteLine("Changing staff for task - Completed");
                else
                    _client.SendAnswer("Changing staff for task - Completed\n");
            }
            catch (Exception ex)
            {
                if (_client == null)
                    Console.WriteLine("Changing staff for task - Failed : " + ex.Message);
                else
                    _client.SendAnswer("Changing staff for task - Failed : " + ex.Message);
            }
        }
    }
}
