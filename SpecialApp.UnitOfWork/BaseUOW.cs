using Microsoft.EntityFrameworkCore;
using SpecialApp.Repository.Helpers;
using System;
using System.Collections.Generic;
using System.Text;
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

        public void Dispose()
        {
            context.Dispose();
        }
    }
}
