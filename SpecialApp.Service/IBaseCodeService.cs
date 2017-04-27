using SpecialApp.Entity;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SpecialApp.Service
{
    public interface IBaseCodeService : IBaseService
    {
        Task<IEnumerable<T>> Get<T>() where T : BaseCode;
    }
}