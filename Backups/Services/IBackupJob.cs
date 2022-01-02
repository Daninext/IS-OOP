using System.Collections.Generic;

namespace Backups.Services
{
    public interface IBackupJob
    {
        void CreateBackUp(IRepository repository);
        IReadOnlyList<RestorePoint> GetPoints();
        void AddJob(JobObject obj);
        void RemoveJob(JobObject obj);
        void ChangeMode(IBackupStrategy newMode);
    }
}
