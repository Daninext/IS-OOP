namespace Backups.Services
{
    public class VirtualRepository : IRepository
    {
        private VirtualData _virtualRep = new VirtualData();
        public IDataStorage Storage => _virtualRep;
        public void Save(byte[] compressedBytes, string subname = "")
        {
            _virtualRep.AddData((subname, compressedBytes));
        }
    }
}
