using System;
using System.Collections.Generic;

namespace Backups.Services
{
    public class SplitMode : IBackupMode
    {
        public IReadOnlyList<string> StartBackup(IReadOnlyList<JobObject> objects, IRepository repository)
        {
            var names = new List<string>();
            foreach (JobObject obj in objects)
            {
                JobObject[] arr = { obj };
                names.Add(repository.CreateBackUp(new List<JobObject>(arr), DateTime.Now.ToString())[0]);
            }

            return names;
        }
    }
}
