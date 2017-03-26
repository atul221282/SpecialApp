using SpecialApp.Entity;
using SpecialApp.Repository;
using SpecialApp.Repository.Repository;
using System.Threading.Tasks;

namespace SpecialApp.UnitOfWork
{
    public interface ISpecialUOW
    {
        IRepository<AddressType> AddressTypeRepository { get; }

        ISpecialRepository SpecialRepository { get; }

        Task<int> CommitAsync();
    }
}