namespace BackupsExtra.Services
{
    public interface ILogging
    {
        bool IncludeTimeInfo { get; set; }
        void SaveLog(string message);
    }
}
