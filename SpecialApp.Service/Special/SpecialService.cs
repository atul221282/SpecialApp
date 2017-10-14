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
using System.Text;

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

        public async Task<Either<IErrorResponse, SP.ISpecial>> GetByIdAsync(int Id)
            => await TryGetByIdAsync(Id);

        public async Task<Either<IErrorResponse, IEnumerable<SP.Special>>> GetByLocation(double latitude, double longitude, int distance = 4000)
        {
            var result = new ActiveOnlyEntity<SP.Special>(
                (await Uow.SpecialRepository.TryGetByLocation(latitude, longitude, distance: distance)).Value())
                .GetActive();

            if (result == null)
            {
                return Either.Left<IErrorResponse, IEnumerable<SP.Special>>(() => new NotFoundError("No location found"));
            }

            return Either.Right<IErrorResponse, IEnumerable<SP.Special>>(() => result);
        }

        public async Task<Either<IErrorResponse, IEnumerable<Location>>> GetLocation(double latitude, double longitude, int distance = 4000)
        {
            var result = new ActiveOnlyEntity<Location>((await Uow.SpecialRepository
                .TryGetLocation(latitude, longitude, distance: distance)).Value())
                .GetActive();

            if (result == null)
            {
                return Either.Left<IErrorResponse, IEnumerable<Location>>(() => new NotFoundError("No location found"));
            }

            return Either.Right<IErrorResponse, IEnumerable<Location>>(() => result);
        }

        public async Task<Either<IErrorResponse, IEnumerable<SP.Special>>>
            GetLocationsAsync(double latitude, double longitude, int distance = 4000)
        {
            var errors = new List<IErrorResponse>();

            if (latitude == 0)
                errors.Add(new ServerError("Latitude is null"));

            if (longitude == 0)
                errors.Append(new ServerError("Longitude is null"));

            var locations = await Uow.SpecialRepository.TryGetByLocation(latitude, longitude, distance: distance);

            var result = locations.When(() => locations.HasValue() && locations.Value().Any())
                .Then(locations.Value)
                .SafeElse(
                () => NoLocationFoundError?.Invoke(longitude, latitude),
                () => LocationExceptionError?.Invoke(longitude, latitude));

            return errors.HasError() ? errors.GetError<IEnumerable<SP.Special>>() : result;
        }

        private async Task<Either<IErrorResponse, SP.ISpecial>> TryGetByIdAsync(int Id)
        {
            var result = await Uow.SpecialRepository.TryGetById(Id);

            return result.When(() => result.HasValue())
                .Then(result.Value)
                .SafeElse(() => NoSpecialFoundError.Invoke(Id));
        }

        private Func<double, double, IErrorResponse> NoLocationFoundError =>
             (lon, lat) => new NotFoundError($"No location found for the given latitude = {lat} and longitude = {lon}");

        private Func<double, double, IErrorResponse> LocationExceptionError =>
             (lon, lat) => new NotFoundError($"Error processign request for finding location where given latitude = {lat} and longitude = {lon}");

        private Func<int, IErrorResponse> NoSpecialFoundError =>
             (id) => new NotFoundError($"No special found for the given id = {id}");
    }
}
