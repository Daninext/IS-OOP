using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using Backups.Services;
using Backups.Tools;
using BackupsExtra.Services;

namespace BackupsExtra.Tests
{
    public class BackupsExtraTests
    {
        private IBackupJob _job;
        private IPointControl _pointControl;

        [SetUp]
        public void Setup()
        {
            _job = null;
            _pointControl = null;
        }

        [Test]
        public void CheckVirtualRepWork()
        {
            _pointControl = new PointControl();
            _job = new BackupJob();

            var jobObj = new JobObject(Encoding.ASCII.GetBytes("98"), "98", "./");

            _pointControl.AddBackupJob((BackupJob)_job);

            _job.AddJob(new JobObject(Encoding.ASCII.GetBytes("1234"), "1234", "./"));
            _job.AddJob(new JobObject(Encoding.ASCII.GetBytes("567"), "567", "./"));
            _job.AddJob(jobObj);

            var rep = new VirtualRepository();

            _job.CreateBackUp(rep);

            _job.RemoveJob(jobObj);
            _job.CreateBackUp(rep);

            _pointControl.ClearOldData();

            Assert.AreEqual(1, _job.GetPoints().Count);
        }
    }
}
