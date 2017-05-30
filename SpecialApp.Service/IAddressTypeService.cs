using SpecialApp.Entity;
using System.Threading.Tasks;

namespace SpecialApp.Service
{
    public interface IAddressTypeService
    {
        void Add();

        Task<IAddressType> Get();

        Task<int> CommitAsync();
    }
}