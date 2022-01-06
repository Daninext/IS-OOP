using System.Collections.Generic;

namespace Backups.Services
{
    public interface IBackupStrategy
    {
        void StartBackup(IReadOnlyList<JobObject> objects, RestorePoint point);
    }
}
