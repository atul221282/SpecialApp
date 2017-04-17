using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Threading.Tasks;

namespace SpecialApp.Service
{
    public interface IBaseService : IDisposable
    {
        Task<IDbContextTransaction> BeginTransaction();
    }
}