﻿using System.Text;
using NUnit.Framework;
using Backups.Services;
using Backups.Tools;

namespace Backups.Tests
{
    public class BackupsTests
    {
        private IBackupJob _job;

        [SetUp]
        public void Setup()
        {
            _job = null;
        }

        [Test]
        public void CheckVirtualRepWork()
        {
            _job = new BackupJob();

            var jobObj = new JobObject(Encoding.ASCII.GetBytes("98"), "98", "./");

            _job.AddJob(new JobObject(Encoding.ASCII.GetBytes("1234"), "1234", "./"));
            _job.AddJob(new JobObject(Encoding.ASCII.GetBytes("567"), "567", "./"));
            _job.AddJob(jobObj);

            Assert.Catch<SameJobObjectBackUpException>(() =>
            {
                _job.AddJob(jobObj);
            });

            _job.ChangeMode(new SingleStrategy());

            var rep = new VirtualRepository();

            _job.CreateBackUp(rep);

            Assert.AreEqual(1, ((VirtualData)rep.Storage).Data.Count);
            Assert.AreEqual(1, _job.GetPoints().Count);

            _job.RemoveJob(jobObj);
            _job.ChangeMode(new SplitStrategy());
            _job.CreateBackUp(rep);

            Assert.Catch<JobObjectNotFoundBackUpException>(() =>
            {
                _job.RemoveJob(jobObj);
            });

            Assert.AreEqual(3, ((VirtualData)rep.Storage).Data.Count);
            Assert.AreEqual(2, _job.GetPoints().Count);
        }
    }
}
