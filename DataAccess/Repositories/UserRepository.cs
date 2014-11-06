
using System.Data.Entity;
using DataAccess.Entities;
using DataAccess.Infrastructure;
using DataAccess.Mapping;

namespace DataAccess.Repositories
{
    public class UserRepository: BaseRepository<User>, IUserRepository
    {
        private readonly DbSet<User> _dbSet;

        public UserRepository(AtpContext dbContext) : base(dbContext) { }

        public User GetFullUserData(long id)
        {
            throw new System.NotImplementedException();
        }

        public void Remove(User user)
        {
            throw new System.NotImplementedException();
        }
    }

    public interface IUserRepository : IRepository<User>
    {
        User GetFullUserData(long id);

        void Remove(User user);
    }
}
