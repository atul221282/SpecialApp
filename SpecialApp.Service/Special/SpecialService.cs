using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using SpecialApp.Entity;
using SP = SpecialApp.Entity.Specials;
using SpecialApp.UnitOfWork;
using SpecialApp.Entity.Composer;
using SpecialApp.Base;
using Optional;

namespace SpecialApp.Service.Special
{
    public class SpecialService : BaseService, ISpecialService
    {
        private readonly Func<ISpecialUOW> uowFunc;

        private new ISpecialUOW _uow;
        public ISpecialUOW Uow
        {
            get
            {
                return _uow = _uow ?? uowFunc();
            }
        }
        public SpecialService(Func<ISpecialUOW> uowFunc) : base(uowFunc())
        {
            this.uowFunc = uowFunc;
        }

        public async Task<Option<SP.ISpecial>> GetById(int Id)
        {
            var result = await Uow.SpecialRepository.GetById(Id);

            return result;
        }

        public async Task<IEnumerable<SP.Special>> GetByLocation(double latitude, double longitude, int distance = 4000)
        {
            var result = new ActiveOnlyEntity<SP.Special>(
                await Uow.SpecialRepository.GetByLocation(latitude, longitude, distance: distance))
                .GetActive();

            return result;
        }

        public async Task<IEnumerable<Location>> GetLocation(double latitude, double longitude, int distance = 4000)
        {
            var result = new ActiveOnlyEntity<Location>(await Uow.SpecialRepository
                .GetLocation(latitude, longitude, distance: distance))
                .GetActive();

            return result;
        }

        public async Task<ISpecialAddressHelper> GetLocations(double latitude, double longitude, int distance = 4000)
        {
            var result = new ActiveOnlyEntity<SP.Special>(
                await Uow.SpecialRepository.GetByLocation(latitude, longitude, distance: distance))
                .GetActive();

            return new SpecialAddressHelper(Uow, result); ;
        }
    }
}
