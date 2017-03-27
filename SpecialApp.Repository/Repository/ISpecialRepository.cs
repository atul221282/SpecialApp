using SpecialApp.Entity;
using SpecialApp.Entity.Specials;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SpecialApp.Repository.Repository
{
    public interface ISpecialRepository
    {
        Task<IEnumerable<Special>> GetByLocation(double latitude, double longitude, int distance = 4000);
        Task<IEnumerable<Location>> GetLocation(double latitude, double longitude, int distance = 4000);
    }
}
