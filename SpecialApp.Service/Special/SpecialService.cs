using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using SpecialApp.Entity;
using SpecialApp.Repository.Repository;
using SpecialApp.UnitOfWork;

namespace SpecialApp.Service.Special
{
    public class SpecialService : BaseService, ISpecialService
    {
        private readonly Func<ISpecialUOW> uowFunc;

        private ISpecialUOW _uow;
        public ISpecialUOW Uow
        {
            get
            {
                return _uow = _uow ?? uowFunc();
            }
        }
        public SpecialService(Func<ISpecialUOW> uowFunc) : base(uowFunc)
        {
            this.uowFunc = uowFunc;
        }
        public async Task<IEnumerable<Entity.Specials.Special>> GetByLocation(double latitude, double longitude, int distance = 4000)
        {
            return await Uow.SpecialRepository.GetByLocation(latitude, longitude, distance: distance);
        }

        public async Task<IEnumerable<Location>> GetLocation(double latitude, double longitude, int distance = 4000)
        {
            return await Uow.SpecialRepository.GetLocation(latitude, longitude, distance: distance);
        }
    }
}
