
using System.Data.Entity.ModelConfiguration;
using DataAccess.Entities;

namespace DataAccess.Mapping
{
    public class RoleConfiguration: EntityTypeConfiguration<Role>
    {
        public RoleConfiguration()
        {
            Property(p => p.RoleName).HasColumnName("Role");
            //HasRequired(k => k.Users);
        }
    }
}
