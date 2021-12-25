using System.Collections.Generic;

namespace Backups.Services
{
    public interface IBackupMode
    {
        IReadOnlyList<string> StartBackup(IReadOnlyList<JobObject> objects, IRepository repository);
    }
}
