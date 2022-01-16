namespace Backups.Services
{
    public interface IRepository
    {
        IDataStorage Storage { get; }
        void Save(byte[] compressedBytes, string path, string subname = "");
        void Merge(IRepository repository);
        void Recover(string newLocation);
    }
}
