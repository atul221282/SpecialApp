using Monad;
using SpecialApp.Entity;
using SpecialApp.Entity.Specials;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SpecialApp.Repository.Repository.Specials
{
    public interface ISpecialRepository
    {
        Task<Option<IEnumerable<Special>>> TryGetByLocation(double latitude, double longitude, int distance = 4000);

        Task<Option<IEnumerable<Location>>> TryGetLocation(double latitude, double longitude, int distance = 4000);

        Task<Option<ISpecial>> TryGetById(int id);
    }
}
