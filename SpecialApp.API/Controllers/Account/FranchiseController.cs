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
    public class FranchiseController : BaseAccountApiController
    {
        private readonly Lazy<ICreateFranchiseService> lazyService;
        private readonly Lazy<IMapper> lazyMapper;

        public FranchiseController(Lazy<ICreateFranchiseService> lazyService, 
            Lazy<IMapper> lazyMapper)
        {
            this.lazyService = lazyService;
            this.lazyMapper = lazyMapper;
        }
        [HttpPost]
        public async Task<IActionResult> Create([FromBody]CreateFranchiseModel farnchiseModel)
        {
            var cFranchise = lazyMapper.Value.Map<CompanyFranchise>(farnchiseModel);
            //opt => opt.Items["CurrentUserName"] = User.Identity.Name
            var companyFranchise = await lazyService.Value.Create(cFranchise);
            return Ok(companyFranchise);
        }
    }
}
