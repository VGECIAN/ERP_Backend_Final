using ERP_Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ERP_Data.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        public ERPDbContext _db;
        public DbSet<T> dbSet;

        public Repository(ERPDbContext db, DbSet<T> dbSet)
        {
            _db = db;
            this.dbSet = dbSet;
        }

        public void Add(T entity)
        {
            dbSet.Add(entity);
        }

        public IEnumerable<T> GetAll()
        {
            IQueryable<T> query = dbSet;
            return query.ToList();
        }

        public T GetFirstOrDefault(Expression<Func<T, bool>> filter)
        {
            IQueryable<T> query = dbSet;
            query = query.Where(filter);

            return query.FirstOrDefault();
        }

        public void Remove(T entity)
        {
            dbSet.Remove(entity);
            throw new NotImplementedException();
        }

        public void RemoveRange(T entity)
        {
            dbSet.RemoveRange(entity);
        }

        bool IRepository<T>.Any(Expression<Func<T, bool>> filter)
        {
            IQueryable<T> query = dbSet;
            return query.Any(filter);
        }
        public void Save()
        {
            _db.SaveChanges();
        }
    }
}
