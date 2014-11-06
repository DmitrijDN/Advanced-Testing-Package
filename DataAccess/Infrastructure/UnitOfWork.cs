
using System;
using System.Data.Entity;
using System.Data.Entity.Core.EntityClient;
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
                    //_currentContext = new AtpContext(@"Data Source=.\SQLEXPRESS;Initial Catalog=ATP;Integrated Security=True;");
                    //_currentContext = new AtpContext("name=ATPConnection");
                    _currentContext = new AtpContext();

                    //string connectionString = new System.Configuration.ConfigurationSettings.AppSettings["ConnectionString"]);
 
                    //System.Data.SqlClient.SqlConnectionStringBuilder scsb = new System.Data.SqlClient.SqlConnectionStringBuilder(connectionString);
 
                    //EntityConnectionStringBuilder ecb = new EntityConnectionStringBuilder();
                    //ecb.Metadata = "res://*/Sample.csdl|res://*/Sample.ssdl|res://*/Sample.msl";
                    //ecb.Provider = "System.Data.SqlClient";
                    //ecb.ProviderConnectionString = scsb.ConnectionString;
 
                    //var dataContext = new SampleEntities(ecb.ConnectionString);

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
