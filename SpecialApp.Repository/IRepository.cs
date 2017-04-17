using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace SpecialApp.Repository
{
    public interface IRepository<T> where T : class
    {
        DbSet<T> DbSet { get; set; }

        /// <summary>
        /// Gets all.
        /// </summary>
        /// <returns></returns>
        IQueryable<T> GetAll();

        /// <summary>
        /// Gets all including.
        /// </summary>
        /// <param name="includedProperties">The included properties.</param>
        /// <returns></returns>
        IQueryable<T> GetAll(params Expression<Func<T, object>>[] includedProperties);

        /// <summary>
        /// Gets T class by the identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        Task<T> Get(long id);

        /// <summary>
        /// Adds the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        void Add(T entity);

        /// <summary>
        /// Updates the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        void Update(T entity);

        /// <summary>
        /// Delete the specified entity
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        Task Delete(T entity);
    }
}