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
        private readonly ISpecialUOW uow;

        public AddressTypeService(ISpecialUOW uow) : base(uow)
        {
            this.uow = uow;
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
            uow.GetRepository<AddressType>().Add(addressType);
        }

        public async Task<Option<IEnumerable<IAddressType>>> GetAsync()
        {
            var result = await uow.GetRepository<AddressType>().GetAll().GetActive().ToListAsync();

            return result.Some<IEnumerable<IAddressType>>();
        }

        public async Task<Option<IAddressType>> GetAsync(int id)
        {
            var resultOf = await uow.GetRepository<AddressType>()
                .GetAll().GetActive().FirstOrDefaultAsync(x => x.Id == id);

            return resultOf.NoneWhen<IAddressType>(x => x == null);
        }

    }
}