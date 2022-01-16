using System.Collections.Generic;
using Backups.Services;

namespace BackupsExtra.Services
{
    public interface ILimitStrategy
    {
        IReadOnlyList<RestorePoint> Choose(IReadOnlyList<IClearLimit> limits, BackupJob job);
    }
}
