using SpecialApp.Entity.Companies;
using SpecialApp.Entity.Model;
using SpecialApp.Entity.Model.Account;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SpecialApp.Service.Account
{
    public interface ICompanyService : IBaseService
    {
        Company Add(Company company);

        Company Add(CreateCompanyModel companyModel);

        Task<IEnumerable<LookupModel>> Get()
    }
}