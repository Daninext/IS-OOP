using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using Backups.Tools;

namespace Backups.Services
{
    [DataContract]
    [KnownType(typeof(SplitStrategy))]
    [KnownType(typeof(SingleStrategy))]
    public class BackupJob : IBackupJob
    {
        [DataMember]
        private List<JobObject> _objects = new List<JobObject>();
        [DataMember]
        private List<RestorePoint> _points = new List<RestorePoint>();

        public delegate void LoggingNotify(string message);

        public event LoggingNotify Notify;

        [DataMember]
        public IBackupStrategy Strategy { get; private set; } = new SplitStrategy();

        public void CreateBackUp(IRepository repository)
        {
            var point = new RestorePoint(DateTime.Now, repository);
            Notify?.Invoke("Point has been created. " + point.ToString());

            Strategy.StartBackup(_objects, point);
            _points.Add(point);
            Notify?.Invoke("Point has been saved. " + point.ToString());
        }

        public IReadOnlyList<RestorePoint> GetPoints()
        {
            return _points;
        }

        public void AddJob(JobObject obj)
        {
            if (_objects.FirstOrDefault(@object => @object.Equals(obj)) != null)
                throw new SameJobObjectBackUpException("There is same Job Object");

            _objects.Add(obj);
        }

        public void RemoveJob(JobObject obj)
        {
            if (!_objects.Remove(obj))
                throw new JobObjectNotFoundBackUpException("There is not Job Object");
        }

        public void RemovePoint(RestorePoint point)
        {
            if (!_points.Remove(point))
                throw new Exception("There is not Restore Point");
        }

        public void ChangeMode(IBackupStrategy newMode)
        {
            Strategy = newMode;
        }

        public override string ToString()
        {
            return "Backup job - " + _objects.Count + " objects, " + _points.Count + " points.";
        }
    }
}
