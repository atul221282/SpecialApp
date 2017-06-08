using Optional;
using SpecialApp.Entity;
using SpecialApp.Service.Proxy;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SpecialApp.Service
{
    public interface IAddressTypeService : IBaseService, ICacheService
    {
        void Add();

        [ResolveFromCache]
        Task<Option<IEnumerable<IAddressType>>> GetAsync();

        [ResolveFromCache]
        Task<Option<IAddressType>> GetAsync(int id);

    }
}