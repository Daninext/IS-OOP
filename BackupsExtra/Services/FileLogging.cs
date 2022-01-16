using System;
using System.IO;
using System.Text;

namespace BackupsExtra.Services
{
    public class FileLogging : ILogging
    {
        private string _path;
        public FileLogging(string logFilePath)
        {
            _path = logFilePath;
        }

        public bool IncludeTimeInfo { get; set; }

        public void SaveLog(string message)
        {
            if (IncludeTimeInfo)
                message = DateTime.Now.ToString() + " " + message;

            using (FileStream fileStream = File.OpenWrite(_path))
            {
                fileStream.Write(Encoding.UTF8.GetBytes(message));
            }
        }
    }
}
