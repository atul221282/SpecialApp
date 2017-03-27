using SpecialApp.Context;
using SpecialApp.Entity;
using SpecialApp.Repository;
using SpecialApp.Repository.Helpers;
using SpecialApp.Repository.Repository;
using System;
using System.Threading.Tasks;

namespace SpecialApp.UnitOfWork
{
    public class SpecialUOW : BaseUOW, ISpecialUOW
    {
        private readonly SpecialContext context;
        private ISpecialRepository _specialRepository;

        public SpecialUOW(SpecialContext context) : base(context)
        {
            this.context = context;
        }

        public IRepository<AddressType> AddressTypeRepository => new Repository<AddressType>(context);

        public ISpecialRepository SpecialRepository => _specialRepository = _specialRepository ?? new SpecialRepository(context);

    }
}
