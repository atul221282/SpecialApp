﻿using Microsoft.EntityFrameworkCore;
using SpecialApp.Base;
using SpecialApp.Entity;
using SpecialApp.UnitOfWork;
using System;
using System.Threading.Tasks;

namespace SpecialApp.Service
{
    public class AddressTypeService : IAddressTypeService
    {
        private readonly Func<ISpecialUOW> uowFunc;

        public AddressTypeService(Func<ISpecialUOW> uowFunc)
        {
            this.uowFunc = uowFunc;
        }

        public void Add()
        {
            var addressType = new AddressType
            {
                AuditCreatedBy = "system",
                AuditLastUpdatedBy = "system",
                AuditCreatedDate = DateTime.Now,
                AuditLastUpdatedDate = DateTime.Now,
                Code = "Code Test",
                Description = "Code desc",
                State = State.Added,
                IsDeleted = false
            };
            uowFunc().GetRepository<AddressType>().Add(addressType);
        }

        public async Task<IAddressType> Get()
        {
            return await uowFunc().GetRepository<AddressType>().GetAll().GetActive().FirstOrDefaultAsync();
        }

        public async Task<int> CommitAsync()
        {
            return await uowFunc().CommitAsync();
        }
    }
}