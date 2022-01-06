namespace Backups.Services
{
    public interface IRepository
    {
        IDataStorage Storage { get; }
        public void Save(byte[] compressedBytes, string subname = "");
    }
}
