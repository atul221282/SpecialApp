using SpecialApp.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Text;
using SpecialApp.Entity.Companies;
using System.Threading.Tasks;
using AutoMapper;
using SpecialApp.Entity.Model.Account;
using System.Linq;
using SpecialApp.Entity.Model;
using Microsoft.EntityFrameworkCore;

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
            company.AuditCreatedBy = "system";
            company.AuditLastUpdatedBy = "system";
            var repo = _uow.GetRepository<Company>();
            var repoAddress = _uow.GetRepository<CompanyAddress>();

            repo.Add(company);
            return company;
        }

        public async Task<IEnumerable<LookupModel>> Get()
        {
            var repo = _uow.GetRepository<Company>();
            var result = await repo.GetAll()
                .Select(x => new LookupModel
                {
                    Id = x.Id.Value,
                    Code = x.CompanyName,
                    Description = x.Details,
                    RowVersion = x.RowVersion
                })
                .ToListAsync();

            return result;
        }
    }
}
