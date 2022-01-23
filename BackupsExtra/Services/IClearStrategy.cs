using System.Collections.Generic;
using Backups.Services;

namespace BackupsExtra.Services
{
    public interface IClearStrategy
    {
        void Clear(IReadOnlyList<RestorePoint> points, BackupJob job);
    }
}
