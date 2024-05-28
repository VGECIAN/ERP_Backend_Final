using ERP_Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace ERP_Data.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly ERPDbContext _db;
        private readonly DbSet<T> _dbSet;

        public Repository(ERPDbContext db)
        {
            _db = db;
            _dbSet = _db.Set<T>();
        }

        public void Add(T entity)
        {
            _dbSet.Add(entity);
        }

        public IEnumerable<T> GetAll()
        {
            IQueryable<T> query = _dbSet;
            return query.ToList();
        }

        public T GetFirstOrDefault(Expression<Func<T, bool>> filter)
        {
            IQueryable<T> query = _dbSet.Where(filter);
            return query.FirstOrDefault();
        }

        public void Remove(T entity)
        {
            _dbSet.Remove(entity);
        }


        public bool Any(Expression<Func<T, bool>> filter)
        {
            IQueryable<T> query = _dbSet;
            return query.Any(filter);
        }

        public void Save()
        {
            _db.SaveChanges();
        }

        public void RemoveRange(T entity)
        {
            _dbSet.RemoveRange(entity);
        }
    }
}
