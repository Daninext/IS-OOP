using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Backups.Services
{
    [DataContract]
    public class DiskData : IDataStorage
    {
        [DataMember]
        private List<(DataInfo, string)> _zipPaths = new List<(DataInfo, string)>();

        public DiskData() { }

        public IReadOnlyList<(DataInfo, string)> ZipPaths => _zipPaths;

        public void AddPath((DataInfo, string) data)
        {
            _zipPaths.Add(data);
        }

        public bool IsSingleStorage()
        {
            return _zipPaths.Count == 1;
        }
    }
}
