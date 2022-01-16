using System.Collections.Generic;
using Backups.Services;

namespace BackupsExtra.Services
{
    public class MergeStrategy : IClearStrategy
    {
        public void Clear(IReadOnlyList<RestorePoint> points, BackupJob job)
        {
            foreach (RestorePoint point in points)
                job.RemovePoint(point);

            var splitPoints = new List<RestorePoint>(points);
            foreach (RestorePoint point in points)
            {
                if (point.Repository.Storage.IsSingleStorage())
                    splitPoints.Remove(point);
            }

            splitPoints.Sort(delegate(RestorePoint a, RestorePoint b)
            {
                if (a.CreatedDate >= b.CreatedDate)
                    return 1;
                return -1;
            });

            for (int i = 0; i != splitPoints.Count - 1; ++i)
            {
                splitPoints[i + 1].Merge(splitPoints[0]);
            }

            job.GetPoints()[0].Merge(splitPoints[splitPoints.Count - 1]);
        }
    }
}
