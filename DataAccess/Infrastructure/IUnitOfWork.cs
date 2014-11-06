
using System;
using System.Data.Entity;
using DataAccess.Repositories;

namespace DataAccess.Infrastructure
{
    public interface IUnitOfWork: IDisposable
    {
        IRepository<T> GetRepository<T>() where T : class, IEntity;
        //T GetDbSet<T>() where T : BaseEntity; 
            
        T GetTypedRepository<T>();

        IUserRepository UserRepository { get; }

        void Commit();
        void Rollback();
    }
}
