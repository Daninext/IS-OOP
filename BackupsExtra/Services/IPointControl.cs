using Backups.Services;

namespace BackupsExtra.Services
{
    public interface IPointControl
    {
        public void RecoverData(RestorePoint point, string location = null);
        public void ClearOldData();
        public void AddBackupJob(BackupJob job);
        public void RemoveBackupJob(BackupJob job);
        public void ChangeClearStrategy(IClearStrategy newStrategy);
        public void ChangeClearLimit(IClearLimit newLimit);
        public void ChangeLoggingMethod(ILogging newLogger);
    }
}
