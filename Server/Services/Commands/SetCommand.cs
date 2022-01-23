using System;
using System.Linq;
using System.Text.Json;
using Transformer.JsonTemplate;
using Transformer.SystemTempate;

namespace Server.Services.Commands
{
    public class SetCommand : ICommand
    {
        private StaffContext _database;
        private Client _client;
        private UserTemplate _enterData;
        private string[] _args;

        public SetCommand(StaffContext database, Client client, params string[] args)
        {
            _database = database;
            _client = client;
            _args = args;

            if (_client != null)
                _enterData = JsonSerializer.Deserialize<UserTemplate>(_args[_args.Length - 1]);
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
            TaskTemplate tempTask = JsonSerializer.Deserialize<TaskTemplate>(_args[2]);

            User boss = _database.Users.FirstOrDefault(u => u.Id == _enterData.intId);
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
    }
}
