using System.Collections.Generic;
using Backups.Services;

namespace BackupsExtra.Services
{
    public interface IClearLimit
    {
        IReadOnlyList<RestorePoint> ChooseToClear(BackupJob job);
    }
}
