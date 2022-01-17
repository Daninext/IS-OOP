using System.Data.Entity;
using Transformer.SystemTempate;

namespace Server
{
    public class StaffContext : DbContext
    {
        public StaffContext()
            : base("staff")
        { }

        public DbSet<User> Users { get; set; }
        public DbSet<Task> Tasks { get; set; }
        public DbSet<Report> Reports { get; set; }
    }
}
