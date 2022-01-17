using System;
using System.Linq;
using System.Text.Json;
using Transformer.JsonTemplate;
using Transformer.SystemTempate;

namespace Server.Services.Commands
{
    public class DeleteCommand : ICommand
    {
        private StaffContext _database;
        private Client _client;
        private string[] _args;

        public DeleteCommand(StaffContext database, Client client, params string[] args)
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
                    DeleteStaff();
                    break;
            }
        }

        private void DeleteStaff()
        {
            UserTemplate enterData = JsonSerializer.Deserialize<UserTemplate>(_args[_args.Length - 1]);
            UserTemplate tempStaff = JsonSerializer.Deserialize<UserTemplate>(_args[2]);

            User staff = _database.Users.FirstOrDefault(u => u.Id == tempStaff.intId);

            if (staff == null)
                throw new Exception("There are no staff with such ID");

            User boss = _database.Users.FirstOrDefault(u => u.Id == enterData.intId);

            staff.ChangeTask(boss, null);

            foreach (User lowGradeStaff in staff.Staff)
            {
                lowGradeStaff.Boss = boss;
            }

            _database.SaveChanges();
            _database.Users.Remove(staff);
            _database.SaveChanges();

            Console.WriteLine("Staff with ID {0} deleted", tempStaff.id);
        }
    }
}
