using System;
using System.Collections.Generic;

namespace Transformer.SystemTempate
{
    public class User
    {
        public User() { }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public int SecurityLevel { get; set; }
        public User Boss { get; set; }
        public List<User> Staff { get; set; } = new List<User>();
        public Task StaffTask { get; set; }

        public void ChangeTask(User boss, Task newTask)
        {
            if (!boss.StaffExists(this))
                throw new Exception("Staff with ID " + Id.ToString() + " don`t obey to staff with ID " + boss.Id.ToString());

            if (StaffTask != null)
                StaffTask.ChangeStaff(null);

            if (newTask != null)
            {
                StaffTask = newTask;
                StaffTask.ChangeStaff(this);
            }
            else
            {
                StaffTask = null;
            }
        }

        public bool StaffExists(User staff)
        {
            if (staff == this)
                return true;

            foreach (User user in Staff)
            {
                if (user == staff)
                    return true;

                if (user.StaffExists(staff))
                    return true;
            }

            return false;
        }

        public override string ToString()
        {
            string str = "ID: " + Id.ToString()
                + "\nName: " + Name
                + "\nSecurity Level: " + SecurityLevel.ToString();

            if (Boss != null)
                str += "\nBoss ID: " + Boss.Id.ToString();
            if (StaffTask != null)
                str += "\nTask ID: " + StaffTask.Id.ToString();

            return str;
        }
    }
}
