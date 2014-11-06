
using System.Data.Entity;
using System.Linq;
using System.Reflection;
using DataAccess.Entities;
using DataAccess.Infrastructure;
using DataAccess.Migrations;

namespace DataAccess.Mapping
{
    public class AtpContext: DbContext
    {
#if DEBUG
        public const string ConnectionsString =
            @"Data Source=.\SQLEXPRESS;Initial Catalog=ATP;Integrated Security=True";
#else
        public const string ConnectionsString =
            @"Server=130a23bb-ba40-4555-945a-a3db0085b768.sqlserver.sequelizer.com;Database=db130a23bbba404555945aa3db0085b768;User ID=pbrdwplmbsybwyvn;Password=CLefkRzxivmtqsEK2kBgNNaGSiiuyRhz6BjR7hF2JraExinSmviQCS2XKDvbGf8y;";
#endif
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }

        public AtpContext() : base(ConnectionsString) { }

        public AtpContext(string connectionString): base(connectionString)
        {
            
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<AtpContext, Configuration>());
            modelBuilder.Configurations.Add(new UserConfigurations());
            modelBuilder.Configurations.Add(new RoleConfiguration());
            base.OnModelCreating(modelBuilder);
        }
    }
}
