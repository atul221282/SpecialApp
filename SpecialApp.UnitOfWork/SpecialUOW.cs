using SpecialApp.Context2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SpecialApp.Entity2;
using SpecialApp.Repository;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SpecialApp.Repository.Helpers;

namespace SpecialApp.UnitOfWork
{
    public class SpecialUOW : ISpecialUOW
    {
        private readonly Func<SpecialContext> context;

        public SpecialUOW(Func<SpecialContext> context)
        {
            this.context = context;
        }

        public IRepository<AddressType> AddressTypeRepository => new Repository<AddressType>(context());

        public async Task<int> CommitAsync()
        {
            context().ApplyStateChange();
            return await context().SaveChangesAsync();

        }
    }
}
