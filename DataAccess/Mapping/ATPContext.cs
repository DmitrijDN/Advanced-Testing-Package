
using System.Data.Entity;
using DataAccess.Entities;
using DataAccess.Infrastructure;

namespace DataAccess.Mapping
{
    public class AtpContext: DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }

        public AtpContext() { }

        public AtpContext(string connectionString): base(connectionString)
        {
            
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new UserConfigurations());
            modelBuilder.Configurations.Add(new RoleConfiguration());
        }
    }
}
