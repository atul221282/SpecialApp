using SpecialApp.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore.Storage;
using System.Threading.Tasks;

namespace SpecialApp.Service
{
    public abstract class BaseService : IBaseService
    {
        protected readonly IBaseUOW _uow;

        protected BaseService(IBaseUOW uow)
        {
            this._uow = uow;
        }

        public async Task<IDbContextTransaction> BeginTransaction()
        {
            return await _uow.BeginTransaction();
        }

        public async Task CommitAsync()
        {
            await _uow.CommitAsync();
        }

        public void Dispose()
        {
            _uow?.Dispose();
        }
    }
}
