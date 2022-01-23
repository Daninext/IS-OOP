using Backups.Services;

namespace BackupsExtra.Services
{
    public interface IPointControl
    {
        void RecoverData(RestorePoint point, string location = null);
        void ClearOldData();
        void AddBackupJob(BackupJob job);
        void RemoveBackupJob(BackupJob job);
        void ChangeClearStrategy(IClearStrategy newStrategy);
        void ChangeClearLimit(IClearLimit newLimit);
        void ChangeLoggingMethod(ILogging newLogger);
    }
}
