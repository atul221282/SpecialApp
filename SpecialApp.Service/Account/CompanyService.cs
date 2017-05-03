using SpecialApp.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Text;
using SpecialApp.Entity.Companies;
using System.Threading.Tasks;

namespace SpecialApp.Service.Account
{
    public class CompanyService : BaseService, ICompanyService
    {
        public CompanyService(ISpecialUOW uow) : base(uow)
        {

        }

        public Company Add(Company company)
        {
            var repo = _uow.GetRepository<Company>();
            repo.Add(company);
            return company;
        }
    }
}
