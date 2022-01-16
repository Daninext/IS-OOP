using System;
using System.Collections.Generic;
using Backups.Services;

namespace BackupsExtra.Services
{
    public class CountLimit : IClearLimit
    {
        public CountLimit(int limit)
        {
            Limit = limit;
        }

        public int Limit { get; }

        public IReadOnlyList<RestorePoint> ChooseToClear(BackupJob job)
        {
            if (Limit >= job.GetPoints().Count)
                return new List<RestorePoint>();

            var allPoints = new List<RestorePoint>(job.GetPoints());
            allPoints.Sort(delegate(RestorePoint a, RestorePoint b)
            {
                if (a.CreatedDate >= b.CreatedDate)
                    return 1;
                return -1;
            });

            var delPoints = new List<RestorePoint>();
            for (int i = 0; i != job.GetPoints().Count - Limit; ++i)
                delPoints.Add(allPoints[i]);

            if (delPoints.Count == allPoints.Count)
                throw new Exception("All points must be cleared");

            return delPoints;
        }
    }
}
