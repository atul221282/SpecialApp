using SpecialApp.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Text;
using SpecialApp.Entity.Companies;
using System.Threading.Tasks;
using AutoMapper;
using SpecialApp.Entity.Model.Account;

namespace SpecialApp.Service.Account
{
    public class CompanyService : BaseService, ICompanyService
    {
        private readonly IMapper mapper;

        public CompanyService(ISpecialUOW uow, IMapper mapper) : base(uow)
        {
            this.mapper = mapper;
        }

        public Company Add(Company company)
        {
            var repo = _uow.GetRepository<Company>();
            repo.Add(company);
            return company;
        }

        public Company Add(CreateCompanyModel companyModel)
        {
            var company = mapper.Map<Company>(companyModel);
            company.State = Entity.State.Added;
            var repo = _uow.GetRepository<Company>();
            var repoAddress = _uow.GetRepository<CompanyAddress>();

            repo.Add(company);
            
            return company;
        }
    }
}
