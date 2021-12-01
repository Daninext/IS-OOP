using System.Collections.Generic;

namespace Backups.Services
{
    public interface IBackupJob
    {
        public void CreateBackUp(IRepository repository);
        public IReadOnlyList<RestorePoint> GetPoints();
        public void AddJob(JobObject obj);
        public void RemoveJob(JobObject obj);
        public void ChangeModeToSplit();
        public void ChangeModeToSingle();
    }
}
