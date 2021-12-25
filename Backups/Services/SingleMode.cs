using System;
using System.Collections.Generic;

namespace Backups.Services
{
    public class SingleMode : IBackupMode
    {
        public IReadOnlyList<string> StartBackup(IReadOnlyList<JobObject> objects, IRepository repository)
        {
            return repository.CreateBackUp(objects, DateTime.Now.ToString());
        }
    }
}
