using System;
using System.Collections.Generic;
using Backups.Tools;

namespace Backups.Services
{
    public class BackupJob : IBackupJob
    {
        private List<JobObject> _objects = new List<JobObject>();
        private List<RestorePoint> _points = new List<RestorePoint>();

        public IBackupStrategy Strategy { get; private set; } = new SplitStrategy();

        public IReadOnlyList<RestorePoint> Points { get => _points; }

        public void CreateBackUp(IRepository repository)
        {
            var point = new RestorePoint(DateTime.Now, repository);
            Strategy.StartBackup(_objects, point);
            _points.Add(point);
        }

        public IReadOnlyList<RestorePoint> GetPoints()
        {
            return _points;
        }

        public void AddJob(JobObject obj)
        {
            foreach (JobObject jobObject in _objects)
            {
                if (jobObject.Equals(obj))
                    throw new SameJobObjectBackUpException("There is same Job Object");
            }

            _objects.Add(obj);
        }

        public void RemoveJob(JobObject obj)
        {
            foreach (JobObject jobObject in _objects)
            {
                if (jobObject.Equals(obj))
                {
                    _objects.Remove(jobObject);
                    return;
                }
            }

            throw new JobObjectNotFoundBackUpException("There is not Job Object");
        }

        public void ChangeMode(IBackupStrategy newMode)
        {
            Strategy = newMode;
        }
    }
}
