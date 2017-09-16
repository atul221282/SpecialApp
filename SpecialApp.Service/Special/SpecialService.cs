using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using SpecialApp.Entity;
using SP = SpecialApp.Entity.Specials;
using SpecialApp.UnitOfWork;
using SpecialApp.Entity.Composer;
using SpecialApp.Base;
using Monad;
using SpecialApp.Base.ServiceResponse;
using System.Linq;

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

        public async Task<Either<string, SP.ISpecial>> GetByIdAsync(int Id)
        {
            var result = await Uow.SpecialRepository.TryGetById(Id);

            if (!result.HasValue())
            {
                return Either.Left<string, SP.ISpecial>(() => "");
            }

            var eitherRight = Either.Right<string, SP.ISpecial>(() => result.Value());

            return eitherRight;
        }

        public async Task<IEnumerable<SP.Special>> GetByLocation(double latitude, double longitude, int distance = 4000)
        {
            var result = new ActiveOnlyEntity<SP.Special>(
                (await Uow.SpecialRepository.TryGetByLocation(latitude, longitude, distance: distance)).Value())
                .GetActive();

            return result;
        }

        public async Task<IEnumerable<Location>> GetLocation(double latitude, double longitude, int distance = 4000)
        {
            var result = new ActiveOnlyEntity<Location>((await Uow.SpecialRepository
                .TryGetLocation(latitude, longitude, distance: distance)).Value())
                .GetActive();

            return result;
        }

        public async Task<Either<IErrorResponse, IEnumerable<SP.Special>>>
            GetLocationsAsync(double latitude, double longitude, int distance = 4000)
        {
            var result = await Uow.SpecialRepository.TryGetByLocation(latitude, longitude, distance: distance);

            return result.When(() => result.HasValue() && result.Value().Any())
                .Then(result.Value)
                .Else(() => GetNotFoundError(longitude, latitude));


            //return result.HasValue() && result.Value().Any()

            //    ? Either.Right<IErrorResponse, IEnumerable<SP.Special>>(
            //        () => result.Value())

            //    : Either.Left<IErrorResponse, IEnumerable<SP.Special>>(
            //        () => new NotFoundError($"No location found for the given latitude = {latitude} and longitude = {longitude}"));
        }

        private static IErrorResponse GetNotFoundError(double longitude, double latitude)
        {
            return new NotFoundError($"No location found for the given latitude = {latitude} and longitude = {longitude}");
        }
    }
}
