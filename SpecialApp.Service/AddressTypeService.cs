using Microsoft.EntityFrameworkCore;
using Optional;
using SpecialApp.Base;
using SpecialApp.Entity;
using SpecialApp.UnitOfWork;
using System;
using System.Collections.Generic;
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

        public async Task<Option<IEnumerable<IAddressType>>> Get()
        {
            var result = await uowFunc().GetRepository<AddressType>().GetAll().GetActive().ToListAsync();

            return Option.Some((IEnumerable<IAddressType>)result);
        }

        public async Task<Option<IAddressType>> Get(int id)
        {
            var result = await uowFunc().GetRepository<AddressType>().GetAll().GetActive().FirstOrDefaultAsync(x => x.Id == id);

            return Option.Some((IAddressType)result);
        }



        public async Task<int> CommitAsync()
        {
            return await uowFunc().CommitAsync();
        }
    }
}