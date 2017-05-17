using SpecialApp.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Text;
using SpecialApp.Entity.Model.Account;
using System.Threading.Tasks;
using AutoMapper;
using SpecialApp.Entity.Companies;

namespace SpecialApp.Service.Account
{
    public class CreateFranchiseService : BaseService, ICreateFranchiseService
    {
        private readonly ISpecialUOW uow;
        private readonly IMapper mapper;

        public CreateFranchiseService(ISpecialUOW uow, IMapper mapper) : base(uow)
        {
            this.uow = uow;
            this.mapper = mapper;
        }

        public async Task Create(CreateFranchiseModel model)
        {
            var entity = mapper.Map<CompanyFranchise>(model);
        }
    }
}
