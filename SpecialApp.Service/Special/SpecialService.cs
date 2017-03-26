using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using SpecialApp.Repository.Repository;
using SpecialApp.UnitOfWork;

namespace SpecialApp.Service.Special
{
    public class SpecialService : ISpecialService
    {
        private readonly Func<ISpecialUOW> uowFunc;

        public SpecialService(Func<ISpecialUOW> uowFunc)
        {
            this.uowFunc = uowFunc;
        }
        public async Task<IEnumerable<Entity.Specials.Special>> GetByLocation(double latitude, double longitude)
        {
            var uow = uowFunc();
            return await uow.SpecialRepository.GetByLocation(latitude, longitude);
        }
    }
}
