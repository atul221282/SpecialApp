using SpecialApp.Context;
using SpecialApp.Entity;
using SpecialApp.Repository;
using SpecialApp.Repository.Helpers;
using SpecialApp.Repository.Repository;
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

        public ISpecialRepository SpecialRepository
        {
            get
            {
                return new SpecialRepository(context());
            }
        }


        public async Task<int> CommitAsync()
        {
            context().ApplyStateChange();
            return await context().SaveChangesAsync();
        }
    }
}