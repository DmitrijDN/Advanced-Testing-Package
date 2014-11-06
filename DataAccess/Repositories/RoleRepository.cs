
using DataAccess.Entities;
using DataAccess.Infrastructure;
using DataAccess.Mapping;

namespace DataAccess.Repositories
{
    public class RoleRepository: BaseRepository<Role>, IRoleRepository
    {
        public RoleRepository(AtpContext dbContext) : base(dbContext)
        {
        }
    }

    public interface IRoleRepository : IRepository<Role> { }
}
