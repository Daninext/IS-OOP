using System;

namespace Backups.Services
{
    public class RestorePoint
    {
        public RestorePoint(DateTime date, IRepository repository)
        {
            CreatedDate = date;
            Repository = repository;
        }

        public DateTime CreatedDate { get; }
        public IRepository Repository { get; }
    }
}
