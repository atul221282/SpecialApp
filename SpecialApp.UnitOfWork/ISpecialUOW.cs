using SpecialApp.Entity;
using SpecialApp.Repository;
using SpecialApp.Repository.Repository;
using System.Threading.Tasks;

namespace SpecialApp.UnitOfWork
{
    public interface ISpecialUOW : IBaseUOW
    {
        IRepository<AddressType> AddressTypeRepository { get; }

        ISpecialRepository SpecialRepository { get; }

    }
}