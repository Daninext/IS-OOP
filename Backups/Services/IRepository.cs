using System.Collections.Generic;

namespace Backups.Services
{
    public interface IRepository
    {
        public IReadOnlyList<string> CreateBackUp(List<JobObject> objects, string mark);
        public string CreateBackUp(JobObject jobject, string mark);
    }
}
