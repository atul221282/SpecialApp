using SpecialApp.Entity;
using System;
using System.Collections.Generic;

using System.Threading.Tasks;

namespace SpecialApp.Service.Special
{
    public interface ISpecialService : IBaseService
    {
        Task<IEnumerable<Entity.Specials.Special>> GetByLocation(double latitude, double longitude, int distance = 4000);
        Task<IEnumerable<Location>> GetLocation(double latitude, double longitude, int distance = 4000);
    }
}
