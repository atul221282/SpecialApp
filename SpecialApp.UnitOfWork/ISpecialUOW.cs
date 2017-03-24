using SpecialApp.Entity;
using SpecialApp.Repository;
using System.Threading.Tasks;

namespace SpecialApp.UnitOfWork
{
    public interface ISpecialUOW
    {
        IRepository<AddressType> AddressTypeRepository { get; }

        Task<int> CommitAsync();
    }
}