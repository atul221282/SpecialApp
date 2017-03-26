using System;
using System.Collections.Generic;

using System.Threading.Tasks;

namespace SpecialApp.Service.Special
{
    public interface ISpecialService
    {
        Task<IEnumerable<Entity.Specials.Special>> GetByLocation(double latitude, string longitude);
    }
}
