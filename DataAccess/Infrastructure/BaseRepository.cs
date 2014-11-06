
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using DataAccess.Mapping;

namespace DataAccess.Infrastructure
{
    public abstract class BaseRepository<T> : IRepository<T> where T :  BaseEntity
    {
        private readonly DbContext _dbContext;
        private readonly DbSet<T> _dbSet;

        protected BaseRepository(AtpContext dbContext)
        {
            _dbContext = dbContext;
            _dbSet = _dbContext.Set<T>();
        }

        public T Get(long id)
        {
            return _dbContext.Set<T>().FirstOrDefault(p => p.Id == id);
        }

        public IEnumerable<T> Get(Func<T, bool> filter)
        {
            return _dbContext.Set<T>().Where(filter);
        }

        public T GetOne(Func<T, bool> filter)
        {
            return _dbContext.Set<T>().FirstOrDefault(filter);
        }

        public IEnumerable<T> GetAll()
        {
            return _dbContext.Set<T>();
        }

        //public IEnumerable<T> GetAll(Func<T, bool> filter)
        //{
        //    return _dbContext.Set<T>().Where(filter).ToList();
        //}

        public void AddItem(T item)
        {
            _dbSet.Add(item);
            _dbContext.SaveChanges();
        }

        public void UpdateItem(T item)
        {
            var record = _dbContext.Entry(item);
            _dbContext.SaveChanges();
        }

        public void DeleteItem(T item)
        {
            _dbSet.Remove(item);
        }
    }
}
