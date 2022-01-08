using System;

namespace Converter.SystemTemplate
{
    public class Report
    {
        public Report()
        {
            CreatedTime = DateTime.Now;
        }
        public int Id { get; set; }
        public User Staff { get; set; }
        public bool Resolved { get; set; }
        public DateTime CreatedTime { get; set; }
        public string Type { get; set; }
        public string Name { get; set; }
        public string Comment { get; set; }

        public void AddComment(string message, User staff)
        {
            if (staff == Staff && !Resolved)
            {
                string processedMessage = message.Replace("^&", " ");
                Comment += processedMessage + "\n";
            }
        }

        public override string ToString()
        {
            string answer = "Staff ID: " + Staff.Id.ToString()
                + "\nCreated time: " + CreatedTime.ToString()
                + "\nResolve: " + Resolved.ToString()
                + "\nType: " + Type
                + "\nName: " + Name.Replace("^&", " ")
                + "\nComment: " + Comment.Replace("^&", " ");

            return answer;
        }
    }
}
