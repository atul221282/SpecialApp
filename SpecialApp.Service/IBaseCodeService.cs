using SpecialApp.Entity;
using SpecialApp.Entity.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SpecialApp.Service
{
    public interface IBaseCodeService : IBaseService
    {
        Task<IEnumerable<IBaseCode>> GetByDictionary(string key);
    }
}