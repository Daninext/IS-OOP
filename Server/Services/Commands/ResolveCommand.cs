﻿using System;
using System.Linq;
using System.Text.Json;
using Transformer.JsonTemplate;
using Transformer.SystemTempate;

namespace Server.Services.Commands
{
    public class ResolveCommand : ICommand
    {
        private StaffContext _database;
        private Client _client;
        private UserTemplate _enterData;
        private string[] _args;

        public ResolveCommand(StaffContext database, Client client, params string[] args)
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
                    ResolveTask();
                    break;
            }
        }

        private void ResolveTask()
        {
            User staff = _database.Users.FirstOrDefault(u => u.Id == _enterData.intId);

            if (staff.StaffTask == null)
                throw new Exception("You haven`t any task");

            staff.StaffTask.ChangeState(Task.StateType.Resolved);
            staff.ChangeTask(staff, null);

            if (_client == null)
                Console.WriteLine("Resolve task - Completed");
            else
                _client.SendAnswer("Resolve task - Completed\n");
        }
    }
}
