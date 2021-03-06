﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using SpecialApp.Repository;
using SpecialApp.Repository.Helpers;
using System.Threading.Tasks;

namespace SpecialApp.UnitOfWork
{
    public abstract class BaseUOW : IBaseUOW
    {
        private readonly DbContext context;

        protected BaseUOW(DbContext context)
        {
            this.context = context;
        }

        public async Task<int> CommitAsync()
        {
            context.ApplyStateChange();
            return await context.SaveChangesAsync();
        }

        public IRepository<T> GetRepository<T>() where T : class
        {
            return new Repository<T>(context);
        }

        /// <summary>
        /// Start transaction on context
        /// </summary>
        /// <returns></returns>
        public async Task<IDbContextTransaction> BeginTransaction()
        {
            return await context.Database.BeginTransactionAsync();
        }

        public void Dispose()
        {
            context.Dispose();
        }
    }
}
