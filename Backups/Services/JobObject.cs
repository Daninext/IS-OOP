using System.IO;
using System.Linq;
using System.Runtime.Serialization;

namespace Backups.Services
{
    [DataContract]
    public class JobObject
    {
        public JobObject() { }

        public JobObject(string path)
        {
            Content = File.ReadAllBytes(path);
            Name = new FileInfo(path).Name;
            Path = new FileInfo(path).DirectoryName;
        }

        public JobObject(byte[] content, string name, string path)
        {
            Content = content;
            Name = name;
            Path = path;
        }

        [DataMember]
        public byte[] Content { get; private set; }

        [DataMember]
        public string Name { get; private set; }

        [DataMember]
        public string Path { get; private set; }

        public bool Equals(JobObject obj)
        {
            return Content.OrderBy(a => a).SequenceEqual(obj.Content.OrderBy(a => a)) && Name == obj.Name && Path == obj.Path;
        }
    }
}
