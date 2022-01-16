using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Backups.Services
{
    [DataContract]
    public class VirtualData : IDataStorage
    {
        [DataMember]
        private List<(DataInfo, byte[])> _data = new List<(DataInfo, byte[])>();

        public VirtualData() { }

        public IReadOnlyList<(DataInfo, byte[])> Data => _data;

        public void AddData((DataInfo, byte[]) data)
        {
            _data.Add(data);
        }

        public bool IsSingleStorage()
        {
            return _data.Count == 1;
        }
    }
}
