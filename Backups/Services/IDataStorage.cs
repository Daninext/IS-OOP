namespace Backups.Services
{
    public interface IDataStorage // I use this for the IRepository interface
    {
        bool IsSingleStorage();
    }
}
