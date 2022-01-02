using System.Collections.Generic;

namespace Backups.Services
{
    public class VirtualData : IDataStorage
    {
        private List<(string, byte[])> _data = new List<(string, byte[])>();

        public IReadOnlyList<(string, byte[])> Data => _data;

        public void AddData((string, byte[]) data)
        {
            _data.Add(data);
        }
    }
}
