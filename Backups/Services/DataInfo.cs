using System.Runtime.Serialization;

namespace Backups.Services
{
    [DataContract]
    public class DataInfo
    {
        public DataInfo(string name, string path)
        {
            Name = name;
            Path = path;
        }

        [DataMember]
        public string Name { get; private set; }
        [DataMember]
        public string Path { get; private set; }
    }
}
