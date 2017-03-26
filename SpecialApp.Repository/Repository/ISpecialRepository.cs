using SpecialApp.Entity.Specials;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SpecialApp.Repository.Repository
{
    public interface ISpecialRepository
    {
        Task<IEnumerable<Special>> GetByLocation(double latitude, string longitude);
    }
}
