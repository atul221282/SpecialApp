using SpecialApp.UnitOfWork;
using System.Collections.Generic;
using SpecialApp.Entity.Companies;
using System.Threading.Tasks;
using AutoMapper;
using SpecialApp.Entity.Model.Account;
using System.Linq;
using SpecialApp.Entity.Model;
using Microsoft.EntityFrameworkCore;
using SpecialApp.Base;
using AutoMapper.QueryableExtensions;
using SpecialApp.Entity.Composer.Company;
using SpecialApp.Entity.Composer;

namespace SpecialApp.Service.Account
{
    public class CompanyService : BaseService, ICompanyService
    {
        private readonly IMapper mapper;
        private readonly IUserIdentity identity;

        public CompanyService(ISpecialUOW uow, IMapper mapper, IUserIdentity identity) : base(uow)
        {
            this.mapper = mapper;
            this.identity = identity;
        }

        public Company Add(Company company)
        {
            var repo = _uow.GetRepository<Company>();

            repo.Add(company);

            return company;
        }

        public Company Add(CompanyModel companyModel)
        {
            var company = mapper.Map<Company>(companyModel,
                opts => opts.Items.Add("EmailAddress", identity.GetEmail() ?? "system"));

            var repo = _uow.GetRepository<Company>();

            repo.Add(company);

            return company;
        }

        public async Task<IEnumerable<CompanyModel>> Get()
        {
            var repo = _uow.GetRepository<Company>();

            var data = await repo.GetAll().ToListAsync();

            var result = new ActiveEntity<Company>(data).GetActive();

            var test = result.WithMinimum(x => x.NumberOfEmployees.Value);

            var test2 = result.Min(x => x.NumberOfEmployees.Value);

            return mapper.Map<IEnumerable<CompanyModel>>(result);
        }

        public async Task<CompanyModel> Get(int id)
        {
            var repo = _uow.GetRepository<Company>();

            var data = await repo.GetAll().Where(x => x.Id == id).ToListAsync();

            var result = new ActiveEntity<Company>(data).GetActive().FirstOrDefault();

            return mapper.Map<CompanyModel>(result);
        }

        public async Task<IEnumerable<LookupModel>> GetLookup()
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
