using System;
using System.IO;

namespace Backups.Services
{
    public class DiskRepository : IRepository
    {
        private DiskData _diskRep = new DiskData();
        private string _path;

        public DiskRepository(string path)
        {
            _path = path;
        }

        public IDataStorage Storage => _diskRep;

        public void Save(byte[] compressedBytes, string subname = "")
        {
            var outStream = new MemoryStream(compressedBytes);

            string fullName = _path + subname + DateTime.Now.ToString() + ".zip";
            using (var fileStream = new FileStream(fullName, FileMode.Create))
            {
                outStream.Seek(0, SeekOrigin.Begin);
                outStream.CopyTo(fileStream);

                _diskRep.AddPath(fullName);
            }
        }
    }
}
