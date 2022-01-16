using System.Collections.Generic;
using Backups.Services;

namespace BackupsExtra.Services
{
    public interface IClearStrategy
    {
        public void Clear(IReadOnlyList<RestorePoint> points, BackupJob job);
    }
}
