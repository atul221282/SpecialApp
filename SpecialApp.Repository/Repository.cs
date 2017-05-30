using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Threading.Tasks;

namespace SpecialApp.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly DbContext DbContext;

        public DbSet<T> DbSet { get; set; }

        //private readonly DbSet<T> DbSet;

        public Repository(DbContext context)
        {
            this.DbContext = context;
            this.DbSet = this.DbContext.Set<T>();
        }

        public IQueryable<T> GetAll()
        {
            return this.DbSet;
        }

        public virtual void Add(T entity)
        {
            var dbEntityEntry = DbContext.Entry(entity);

            if (dbEntityEntry.State != EntityState.Detached)
            {
                dbEntityEntry.State = EntityState.Added;
            }
            else
            {
                DbSet.Add(entity);
            }
        }

        public async Task Delete(int id)
        {
            var entity = await Get(id);
            if (entity == null) return; // not found; assume already deleted.
            await Delete(entity);
        }

        public async Task Delete(T entity)
        {
            var dbEntityEntry = DbContext.Entry(entity);
            if (dbEntityEntry.State != EntityState.Deleted)
            {
                dbEntityEntry.State = EntityState.Deleted;
            }
            else
            {
                DbSet.Attach(entity);
                await Task.Factory.StartNew(() => DbSet.Remove(entity));
            }
        }

        public virtual Task<T> Get(long id)
        {
            return DbSet.FindAsync(id);
        }

        public void Update(T entity)
        {
            var dbEntityEntry = DbContext.Entry(entity);
            if (dbEntityEntry.State == EntityState.Detached)
            {
                DbSet.Attach(entity);
            }
            dbEntityEntry.State = EntityState.Modified;
        }

        public IQueryable<T> GetAll(params Expression<Func<T, object>>[] includedProperties)
        {
            IQueryable<T> query = DbSet;
            foreach (var includedProperty in includedProperties)
            {
                query = query.Include(includedProperty);
            }
            return query;
        }
    }
}