using System.IO;
using System.Linq;

namespace Backups.Services
{
    public class JobObject
    {
        public JobObject(string path)
        {
            Content = File.ReadAllBytes(path);
            Name = new FileInfo(path).Name;
        }

        public JobObject(byte[] content, string name)
        {
            Content = content;
            Name = name;
        }

        public byte[] Content { get; private set; }

        public string Name { get; }

        public bool Equals(JobObject obj)
        {
            return Content.OrderBy(a => a).SequenceEqual(obj.Content.OrderBy(a => a));
        }
    }
}
