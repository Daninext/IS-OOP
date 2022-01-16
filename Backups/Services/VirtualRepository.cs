using System.IO;
using System.Linq;
using System.Runtime.Serialization;

namespace Backups.Services
{
    [DataContract]
    public class VirtualRepository : IRepository
    {
        [DataMember]
        private VirtualData _virtualRep = new VirtualData();

        public VirtualRepository() { }

        public IDataStorage Storage => _virtualRep;

        public void Save(byte[] compressedBytes, string path, string subname = "")
        {
            _virtualRep.AddData((new DataInfo(subname, path), compressedBytes));
        }

        public void Merge(IRepository repository)
        {
            if (repository.GetType() == typeof(VirtualRepository))
            {
                var olderData = (VirtualData)repository.Storage;
                foreach ((DataInfo, byte[]) dataPair in olderData.Data)
                {
                    if (_virtualRep.Data.FirstOrDefault(data => data.Item1 == dataPair.Item1) == (null, null))
                        _virtualRep.AddData(dataPair);
                }
            }
        }

        public void Recover(string newLocation)
        {
            foreach ((DataInfo, byte[]) dataPair in _virtualRep.Data)
            {
                string path;
                if (newLocation == string.Empty || newLocation == null)
                    path = dataPair.Item1.Path;
                else
                    path = newLocation + "\\" + dataPair.Item1.Name;

                if (File.Exists(path))
                    File.Delete(path);

                using (FileStream fileStream = File.OpenWrite(path))
                {
                    fileStream.Write(dataPair.Item2);
                }
            }
        }
    }
}
