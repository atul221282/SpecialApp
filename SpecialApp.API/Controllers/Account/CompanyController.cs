using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SpecialApp.Entity.Companies;
using SpecialApp.Entity.Model.Account;
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
        private readonly Lazy<IMapper> lazyMapper;

        public ICompanyService Service
        {
            get { return _service = _service ?? lazyService.Value; }
        }

        public CompanyController(Lazy<ICompanyService> lazyService, Lazy<IMapper> lazyMapper)
        {
            this.lazyService = lazyService;
            this.lazyMapper = lazyMapper;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody]CreateCompanyModel companyModel)
        {
            using (Service)
            {
                var company =  Service.Add(companyModel);

                await Service.CommitAsync();

                return Ok(company);
            }
        }
    }
}
