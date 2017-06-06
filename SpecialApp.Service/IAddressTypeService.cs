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

        Task<Option<IEnumerable<IAddressType>>> Get();

        [ResolveFromCache]
        Task<Option<IAddressType>> Get(int id);

    }
}