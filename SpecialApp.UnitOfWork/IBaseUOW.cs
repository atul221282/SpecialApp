using Microsoft.EntityFrameworkCore.Storage;
using SpecialApp.Repository;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SpecialApp.UnitOfWork
{
    public interface IBaseUOW : IDisposable
    {
        Task<int> CommitAsync();

        Task<IDbContextTransaction> BeginTransaction();

        IRepository<T> GetRepository<T>() where T : class;
    }
}
