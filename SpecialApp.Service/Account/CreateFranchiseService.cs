using SpecialApp.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Text;
using SpecialApp.Entity.Model.Account;
using System.Threading.Tasks;

namespace SpecialApp.Service.Account
{
    public class CreateFranchiseService : ICreateFranchiseService
    {
        private readonly ISpecialUOW uow;

        public CreateFranchiseService(ISpecialUOW uow)
        {
            this.uow = uow;
        }

        public async Task Create(CreateFranchiseModel model)
        {
            throw new NotImplementedException();
        }
    }
}
