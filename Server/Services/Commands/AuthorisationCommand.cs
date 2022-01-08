using System;
using System.Linq;
using System.Text.Json;
using Converter.JsonTemplate;
using Converter.SystemTemplate;

namespace Server.Services.Commands
{
    public class AuthorisationCommand : ICommand
    {
        private StaffContext _database;
        private Client _client;
        private string[] _args;

        public AuthorisationCommand(StaffContext database, Client client, params string[] args)
        {
            _database = database;
            _client = client;
            _args = args;
        }

        public void Execute()
        {
            UserTemplate staff = JsonSerializer.Deserialize<UserTemplate>(_args[2]);

            if (staff.name == null || staff.name == string.Empty)
                throw new Exception("Empty name field");
            if (staff.password == null || staff.password == string.Empty)
                throw new Exception("Empty password field");

            User user = _database.Users.FirstOrDefault(u => u.Name == staff.name && u.Password == staff.password);

            if (user != null)
                _client.SendAnswer("success " + user.Id.ToString());
            else
                _client.SendAnswer("fail");
        }
    }
}
