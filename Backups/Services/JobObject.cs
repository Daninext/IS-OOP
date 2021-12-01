using System.IO;
using System.Linq;

namespace Backups.Services
{
    public class JobObject
    {
        public JobObject(string path)
        {
            FileInf = new FileInfo(path);
            Content = File.ReadAllBytes(path);
        }

        public JobObject(byte[] content)
        {
            Content = content;
        }

        public FileInfo FileInf { get; private set; }

        public byte[] Content { get; private set; }

        public bool Equals(JobObject obj)
        {
            if (FileInf != null && obj.FileInf != null)
                return FileInf.FullName == obj.FileInf.FullName;

            return Content.OrderBy(a => a).SequenceEqual(obj.Content.OrderBy(a => a));
        }
    }
}
