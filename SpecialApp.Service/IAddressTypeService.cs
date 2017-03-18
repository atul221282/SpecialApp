using SpecialApp.Entity2;
using System.Threading.Tasks;

namespace SpecialApp.Service
{
    public interface IAddressTypeService
    {
        void Add();

        Task<AddressType> Get();

        Task<int> CommitAsync();
    }
}