using System.Collections.Generic;

namespace Backups.Services
{
    public interface IRepository
    {
        IReadOnlyList<string> CreateBackUp(IReadOnlyList<JobObject> objects, string mark);
    }
}
