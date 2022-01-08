using System;
using System.Linq;
using System.Collections.Generic;

namespace Converter.SystemTemplate
{
    public class Task
    {
        public enum StateType
        {
            Open,
            Active,
            Resolved
        }

        public Task()
        {
        }

        public Task(string target)
        {
            State = StateType.Open;
            Target = target;
            CreatedTime = DateTime.Now.ToShortDateString();
            LastChangeTime = DateTime.Now.ToShortDateString();

            WriteHistory("Task created {0} \n", DateTime.Now.ToShortDateString());
        }

        public int Id { get; set; }
        public StateType State { get; set; }
        public string Target { get; set; }
        public string Comment { get; set; }
        public string History { get; set; }
        public int NeedSecurityLevel { get; set; }
        public string CreatedTime { get; set; }
        public string LastChangeTime { get; set; }
        public User Staff { get; set; }
        public List<User> LastStaff { get; set; } = new List<User>();

        public bool IsInBossHierarchy(User boss)
        {
            while (boss != null)
            {
                if (boss == Staff.Boss)
                    return true;

                boss = Staff.Boss;
            }

            return false;
        }

        public void ChangeState(StateType state)
        {
            if (State == StateType.Resolved)
                throw new Exception("Task already resolved");

            WriteHistory("State was changed from {0} to {1}\n", State, state);

            State = state;
        }

        public void ChangeStaff(User newStaff)
        {
            if (Staff == null)
            {
                Staff = newStaff;
                WriteHistory("Current stuff changed: null to {0} - {1}\n", newStaff.Id, newStaff.Name);
            } 
            else
            {
                LastStaff.Add(Staff);

                if (newStaff != null)
                    WriteHistory("Current stuff changed: {0} - {1} to {2} - {3}\n", Staff.Id, Staff.Name, newStaff.Id, newStaff.Name);
                else
                    WriteHistory("Current stuff changed: {0} - {1} to null\n", Staff.Id, Staff.Name);

                Staff = newStaff;
            }
        }

        public void AddComment(string message, User staff)
        {
            if (State == StateType.Resolved)
                throw new Exception("Task already resolved");

            if (staff == Staff)
            {
                string processedMessage = message.Replace('.', ' ');
                Comment += processedMessage + "\n";
                WriteHistory("Staff with ID {0} added comment: {1} \n", staff.Id, processedMessage);
            }
        }

        private void WriteHistory(string format, params object[] args)
        {
            string message = format;

            for (int i = 0; i != args.Length; ++i)
                message = message.Replace("{" + i.ToString() + "}", args[i].ToString());

            History += message;
        }

        public bool StaffWorkedWithThisTask(User staff)
        {
            if (Staff == staff || LastStaff.FirstOrDefault(s => s == staff) != null)
                return true;

            return false;
        }

        public override string ToString()
        {
            string str = "ID: " + Id.ToString()
                + "\nState: " + State.ToString()
                + "\nTarget: " + Target
                + "\nComment: " + Comment
                + "\nHistory: " + History
                + "Need security level: " + NeedSecurityLevel.ToString() + "\n";

            if (Staff != null)
                str += "Current staff ID: " + Staff.Id.ToString() + "\n";

            return str;
        }
    }
}
