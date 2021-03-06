﻿using Optional;
using SpecialApp.Entity;
using System;
using System.Collections.Generic;
using SP = SpecialApp.Entity.Specials;
using System.Threading.Tasks;
using Monad;
using SpecialApp.Base.ServiceResponse;

namespace SpecialApp.Service.Special
{
    public interface ISpecialService : IBaseService
    {
        Task<Either<IErrorResponse, SP.ISpecial>> GetByIdAsync(int Id);

        Task<Either<IErrorResponse, IEnumerable<SP.Special>>> GetByLocation(double latitude, double longitude, int distance = 4000);

        Task<Either<IErrorResponse, IEnumerable<Location>>> GetLocation(double latitude, double longitude, int distance = 4000);

        Task<Either<IErrorResponse, IEnumerable<SP.Special>>> GetLocationsAsync(double latitude, double longitude, int distance = 4000);
    }
}
