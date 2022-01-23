using System;
using System.Collections.Generic;
using System.Linq;
using Backups.Services;

namespace BackupsExtra.Services
{
    public class HybridAnyLimitStrategy : ILimitStrategy
    {
        public IReadOnlyList<RestorePoint> Choose(IReadOnlyList<IClearLimit> limits, BackupJob job)
        {
            var delPoints = new List<RestorePoint>();

            foreach (IClearLimit limit in limits)
            {
                IReadOnlyList<RestorePoint> tempPoints = limit.ChooseToClear(job);

                foreach (RestorePoint point in tempPoints)
                {
                    if (delPoints.FirstOrDefault(p => p == point) == null)
                        delPoints.Add(point);
                }
            }

            if (delPoints.Count == job.GetPoints().Count)
                throw new Exception("All points must be cleared");

            return delPoints;
        }
    }
}
