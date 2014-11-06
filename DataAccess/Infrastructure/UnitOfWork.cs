
using System;
using System.Data.Entity;
using DataAccess.Entities;
using DataAccess.Mapping;
using DataAccess.Repositories;

namespace DataAccess.Infrastructure
{
    public class UnitOfWork: IUnitOfWork
    {
        private readonly IRepositoryFactory _repoFactory;
        private AtpContext _currentContext;

        private readonly Lazy<IUserRepository> _lazyUserRepo;

        private IDbSet<User> _userDbSet;

        public AtpContext CurrentContext
        {
            get
            {
                if (_currentContext == null)
                {
                    //_currentContext = new ATPContext(@"Data Source=.\SQLEXPRESS;Initial Catalog=ATP;Integrated Security=True;");
                    //_currentContext = new AtpContext("ATPConnection");
                    _currentContext = new AtpContext();
                }
                return _currentContext;
            }
        }

        public UnitOfWork(IRepositoryFactory repositoryFactory)
        {
            _repoFactory = repositoryFactory;

            _lazyUserRepo = new Lazy<IUserRepository>(() => GetTypedRepository<IUserRepository>());
        }

        public void Dispose()
        {
            if (_currentContext != null)
            {
                _currentContext.Dispose();   
            }
        }

        public IRepository<T> GetRepository<T>() where T : class, IEntity
        {
            throw new System.NotImplementedException();
        }

        public IUserRepository UserRepository
        {
            get { return _lazyUserRepo.Value; }
        }

        public T GetTypedRepository<T>()
        {
            return _repoFactory.ResolveTyped<T>(CurrentContext);
        }

        public void Commit()
        {
            throw new System.NotImplementedException();
        }

        public void Rollback()
        {
            throw new System.NotImplementedException();
        }
    }
}
