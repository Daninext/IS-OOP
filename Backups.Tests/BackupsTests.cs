using NUnit.Framework;
using Backups.Services;
using System.Text;
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

            _job.AddJob(new JobObject(Encoding.ASCII.GetBytes("1234")));
            _job.AddJob(new JobObject(Encoding.ASCII.GetBytes("567")));
            _job.AddJob(new JobObject(Encoding.ASCII.GetBytes("98")));

            Assert.Catch<SameJobObjectBackUpException>(() =>
            {
                _job.AddJob(new JobObject(Encoding.ASCII.GetBytes("98")));
            });

            _job.ChangeMode(new SingleMode());

            var rep = new VirtualRepository();

            _job.CreateBackUp(rep);

            Assert.AreEqual(1, rep.VirtualDirectory.Count);
            Assert.AreEqual(1, _job.GetPoints().Count);

            _job.RemoveJob(new JobObject(Encoding.ASCII.GetBytes("98")));
            _job.ChangeMode(new SplitMode());
            _job.CreateBackUp(rep);

            Assert.Catch<JobObjectNotFoundBackUpException>(() =>
            {
                _job.RemoveJob(new JobObject(Encoding.ASCII.GetBytes("98")));
            });

            Assert.AreEqual(3, rep.VirtualDirectory.Count);
            Assert.AreEqual(2, _job.GetPoints().Count);
        }
    }
}
