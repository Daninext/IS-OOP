using System;
using System.Collections.Generic;
using Backups.Tools;

namespace Backups.Services
{
    public class BackupJob : IBackupJob
    {
        private List<JobObject> _objects = new List<JobObject>();
        private List<RestorePoint> _points = new List<RestorePoint>();

        public string Mode { get; private set; } = "Split";

        public IReadOnlyList<RestorePoint> Points { get => _points; }

        public void CreateBackUp(IRepository repository)
        {
            DateTime date = DateTime.Now;
            if (Mode == "Split")
            {
                var names = new List<string>();
                foreach (JobObject obj in _objects)
                {
                    names.Add(repository.CreateBackUp(obj, date.ToString()));
                }

                _points.Add(new RestorePoint(date, names));
            }
            else
            {
                _points.Add(new RestorePoint(date, repository.CreateBackUp(_objects, date.ToString())));
            }
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

        public void ChangeModeToSplit()
        {
            Mode = "Split";
        }

        public void ChangeModeToSingle()
        {
            Mode = "Single";
        }
    }
}
