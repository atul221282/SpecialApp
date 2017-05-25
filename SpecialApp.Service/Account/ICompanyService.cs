using SpecialApp.Entity.Companies;
using SpecialApp.Entity.Model;
using SpecialApp.Entity.Model.Account;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SpecialApp.Service.Account
{
    public interface ICompanyService : IBaseService
    {
        Task<IEnumerable<CompanyModel>> Get();

        Company Add(Company company);

        Task<CompanyModel> Get(int id);

        Company Add(CompanyModel companyModel);

        Task<IEnumerable<LookupModel>> GetLookup();
    }
}