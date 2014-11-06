
using System.Data.Entity;
using DataAccess.Entities;
using DataAccess.Mapping;
using DataAccess.Repositories;
using Ninject.Extensions.Factory;
using Ninject.Modules;

namespace DataAccess.Infrastructure
{
    public class DataAccessModule: NinjectModule
    {
        public override void Load()
        {
            Bind<IUnitOfWorkFactory>().ToFactory();
            Bind<IRepositoryFactory>().ToFactory();
            Bind<IUnitOfWork>().To<UnitOfWork>();
            Bind<IRepository<User>, IUserRepository>().To<UserRepository>();
            Bind<IRepository<Role>, IRoleRepository>().To<RoleRepository>();
        }
    }

    public interface IUnitOfWorkFactory
    {
        IUnitOfWork NewUnitOfWork();
    }

    public interface IRepositoryFactory
    {
        IRepository<T> Resolve<T>(DbContext dbContext) where T : IEntity;
        T ResolveTyped<T>(DbContext dbContext);
    }
}
