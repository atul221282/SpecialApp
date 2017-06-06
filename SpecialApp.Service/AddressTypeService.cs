using Microsoft.EntityFrameworkCore;
using Optional;
using SpecialApp.Base;
using SpecialApp.Entity;
using SpecialApp.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SpecialApp.Service
{
    public class AddressTypeService : BaseService, IAddressTypeService
    {
        private readonly Func<ISpecialUOW> uowFunc;

        public AddressTypeService(Func<ISpecialUOW> uowFunc) : base(uowFunc())
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

            return result.Some<IEnumerable<IAddressType>>();
        }

        public async Task<Option<IAddressType>> Get(int id)
        {
            var resultOf = await uowFunc().GetRepository<AddressType>()
                .GetAll().GetActive().FirstOrDefaultAsync(x => x.Id == id);

            return resultOf.NoneWhen<IAddressType>(x => x == null);
        }

    }
}