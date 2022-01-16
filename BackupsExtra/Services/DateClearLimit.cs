using System;
using System.Collections.Generic;
using Backups.Services;

namespace BackupsExtra.Services
{
    public class DateClearLimit : IClearLimit
    {
        public DateClearLimit(DateTime limit)
        {
            Limit = limit;
        }

        public DateTime Limit { get; }

        public IReadOnlyList<RestorePoint> ChooseToClear(BackupJob job)
        {
            var allPoints = new List<RestorePoint>(job.GetPoints());
            var delPoints = new List<RestorePoint>();

            foreach (RestorePoint point in allPoints)
            {
                if (point.CreatedDate > Limit)
                    delPoints.Add(point);
            }

            if (delPoints.Count == allPoints.Count)
                throw new Exception("All points must be cleared");

            return delPoints;
        }
    }
}
