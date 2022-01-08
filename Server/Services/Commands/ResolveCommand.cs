using System;
using System.Linq;
using System.Text.Json;
using Converter.JsonTemplate;
using Converter.SystemTemplate;

namespace Server.Services.Commands
{
    public class ResolveCommand : ICommand
    {
        private StaffContext _database;
        private Client _client;
        private string[] _args;

        public ResolveCommand(StaffContext database, Client client, params string[] args)
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
                    ResolveTask();
                    break;
            }
        }

        private void ResolveTask()
        {
            try
            {
                UserTemplate enterData = null;
                if (_client != null)
                    enterData = JsonSerializer.Deserialize<UserTemplate>(_args[_args.Length - 1]);

                User staff = _database.Users.FirstOrDefault(u => u.Id == enterData.intId);

                if (staff.StaffTask == null)
                    throw new Exception("You haven`t any task");

                staff.StaffTask.ChangeState(Task.StateType.Resolved);
                staff.ChangeTask(staff, null);

                if (_client == null)
                    Console.WriteLine("Resolve task - Completed");
                else
                    _client.SendAnswer("Resolve task - Completed\n");
            }
            catch (Exception ex)
            {
                if (_client == null)
                    Console.WriteLine("Resolve task - Failed : " + ex.Message);
                else
                    _client.SendAnswer("Resolve task - Failed : " + ex.Message);
            }
        }
    }
}
