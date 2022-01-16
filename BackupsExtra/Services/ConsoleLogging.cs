using System;

namespace BackupsExtra.Services
{
    public class ConsoleLogging : ILogging
    {
        public bool IncludeTimeInfo { get; set; }

        public void SaveLog(string message)
        {
            if (IncludeTimeInfo)
                message = DateTime.Now.ToString() + " " + message;

            Console.WriteLine(message);
        }
    }
}
