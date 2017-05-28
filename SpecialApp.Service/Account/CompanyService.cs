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
using SpecialApp.Entity.Composer;
using AutoMapper.QueryableExtensions;

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

            return Add(company);
        }

        public async Task<IEnumerable<CompanyModel>> Get()
        {
            var repo = _uow.GetRepository<Company>();

            var result = await repo.GetAllActive()
                .ProjectTo<CompanyModel>()
                .ToListAsync();

            //var test = result.WithMinimum(x => x.NumberOfEmployees.Value);

            return result;
        }

        public async Task<CompanyModel> Get(int id)
        {
            var repo = _uow.GetRepository<Company>();

            var data = await repo.GetAllActive()
                .Where(x => x.Id == id)
                .ProjectTo<CompanyModel>()
                .FirstOrDefaultAsync();

            return data;
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
