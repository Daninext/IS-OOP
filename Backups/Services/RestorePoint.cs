using System;
using System.Runtime.Serialization;

namespace Backups.Services
{
    [DataContract]
    [KnownType(typeof(DiskRepository))]
    [KnownType(typeof(VirtualRepository))]
    public class RestorePoint
    {
        public RestorePoint(DateTime date, IRepository repository)
        {
            CreatedDate = date;
            Repository = repository;
        }

        [DataMember]
        public DateTime CreatedDate { get; set; } // Can changing for test
        [DataMember]
        public IRepository Repository { get; private set; }
        [DataMember]
        public bool Split { get; private set; }

        public void Merge(RestorePoint point)
        {
            Repository.Merge(point.Repository);
        }

        public void Recover(string newLocation)
        {
            Repository.Recover(newLocation);
        }

        public override string ToString()
        {
            return "Created date: " + CreatedDate.ToString() + ". Repository type: " + Repository.GetType().ToString();
        }
    }
}
