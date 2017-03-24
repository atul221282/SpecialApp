using SpecialApp.Context2;
using SpecialApp.Entity;
using SpecialApp.Repository;
using SpecialApp.Repository.Helpers;
using System;
using System.Threading.Tasks;

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