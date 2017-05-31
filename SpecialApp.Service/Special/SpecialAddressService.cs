using SpecialApp.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SP = SpecialApp.Entity.Specials;
using SpecialApp.Base;
using Microsoft.EntityFrameworkCore;

namespace SpecialApp.Service.Special
{
    public class SpecialAddressHelper : ISpecialAddressHelper
    {
        private IEnumerable<SP.ISpecial> specials;
        private readonly ISpecialUOW uow;

        public SpecialAddressHelper(ISpecialUOW uow, IEnumerable<SP.ISpecial> specials)
        {
            this.specials = specials;
            this.uow = uow;
        }

        public async Task<ISpecialAddressHelper> WithAddress()
        {
            var ids = specials.Select(x => x.Id.Value);

            var spAddRepo = uow.GetRepository<SP.SpecialAddress>();

            var addressList = await spAddRepo.GetAll().Where(x => ids.Contains(x.SpecialId)).ToListAsync();

            foreach (var sp in specials)
            {
                sp.Addresses = addressList.Where(x => x.SpecialId == sp.Id).ToList();
            }

            return this;
        }

        public IEnumerable<SP.ISpecial> Resolve()
        {
            return this.specials;
        }
    }
}
