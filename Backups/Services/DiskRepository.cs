using System;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Runtime.Serialization;

namespace Backups.Services
{
    [DataContract]
    public class DiskRepository : IRepository
    {
        [DataMember]
        private DiskData _diskRep = new DiskData();
        [DataMember]
        private string _path;

        public DiskRepository() { }

        public DiskRepository(string path)
        {
            _path = path;
        }

        public IDataStorage Storage => _diskRep;

        public void Save(byte[] compressedBytes, string path, string subname = "")
        {
            var outStream = new MemoryStream(compressedBytes);

            string fullName = _path + subname + DateTime.Now.ToString() + ".zip";
            using (var fileStream = new FileStream(fullName, FileMode.Create))
            {
                outStream.Seek(0, SeekOrigin.Begin);
                outStream.CopyTo(fileStream);

                _diskRep.AddPath((new DataInfo(subname, path), fullName));
            }
        }

        public void Merge(IRepository repository)
        {
            if (repository.GetType() == typeof(DiskRepository))
            {
                var olderData = (DiskData)repository.Storage;
                foreach ((DataInfo, string) path in olderData.ZipPaths)
                {
                    if (_diskRep.ZipPaths.FirstOrDefault(p => p.Item2 == path.Item2) == (null, null))
                        _diskRep.AddPath(path);
                }
            }
        }

        public void Recover(string newLocation)
        {
            foreach ((DataInfo, string) pair in _diskRep.ZipPaths)
            {
                string path;
                if (newLocation == string.Empty || newLocation == null)
                    path = pair.Item1.Path;
                else
                    path = newLocation;

                ZipFile.ExtractToDirectory(pair.Item2, path, true);
            }
        }
    }
}
