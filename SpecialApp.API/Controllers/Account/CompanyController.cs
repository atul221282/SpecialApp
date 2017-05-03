using Microsoft.AspNetCore.Mvc;
using SpecialApp.Entity.Companies;
using SpecialApp.Service.Account;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SpecialApp.API.Controllers.Account
{
    public class CompanyController : BaseAccountApiController
    {
        private readonly Lazy<ICompanyService> lazyService;
        private ICompanyService _service;

        public ICompanyService Service
        {
            get { return _service = _service ?? lazyService.Value; }
        }

        public CompanyController(Lazy<ICompanyService> lazyService)
        {
            this.lazyService = lazyService;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody]Company company)
        {
            using (Service)
            {
                Service.Add(company);
                await Service.CommitAsync();
                return Ok(company);
            }
        }
    }
}
