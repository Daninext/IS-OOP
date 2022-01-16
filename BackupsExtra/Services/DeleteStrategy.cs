using System.Collections.Generic;
using Backups.Services;

namespace BackupsExtra.Services
{
    public class DeleteStrategy : IClearStrategy
    {
        public void Clear(IReadOnlyList<RestorePoint> points, BackupJob job)
        {
            foreach (RestorePoint point in points)
                job.RemovePoint(point);
        }
    }
}
