using SpecialApp.Entity.Companies;
using System.Threading.Tasks;

namespace SpecialApp.Service.Account
{
    public interface ICompanyService : IBaseService
    {
        Company Add(Company company);
    }
}