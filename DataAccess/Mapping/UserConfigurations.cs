
using System.Data.Entity.ModelConfiguration;
using DataAccess.Entities;

namespace DataAccess.Mapping
{
    public class UserConfigurations: EntityTypeConfiguration<User>
    {
        public UserConfigurations()
        {
            Property(p => p.Email).HasColumnName("Email");
            Property(p => p.Name.FirstName).HasColumnName("FirstName");
            Property(p => p.Name.LastName).HasColumnName("LastName");
            Property(p => p.Name.MiddleName).HasColumnName("MiddleName");
            HasRequired(p => p.Role);
        }
    }
}
