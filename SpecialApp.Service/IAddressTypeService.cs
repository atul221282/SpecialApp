using Optional;
using SpecialApp.Entity;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SpecialApp.Service
{
    public interface IAddressTypeService : IBaseService
    {
        void Add();

        Task<Option<IEnumerable<IAddressType>>> Get();

        Task<Option<IAddressType>> Get(int id);

    }
}