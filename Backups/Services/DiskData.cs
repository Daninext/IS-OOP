using System.Collections.Generic;

namespace Backups.Services
{
    public class DiskData : IDataStorage
    {
        private List<string> _zipPaths = new List<string>();

        public IReadOnlyList<string> ZipPaths => _zipPaths;

        public void AddPath(string path)
        {
            _zipPaths.Add(path);
        }
    }
}
