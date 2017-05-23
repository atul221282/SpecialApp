using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.AspNetCore.Mvc.Routing;
using SpecialApp.API.Infrastructure;
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
        private readonly IMyUrlHelper urlHelper;
        public ICompanyService Service
        {
            get { return _service = _service ?? lazyService.Value; }
        }

        public CompanyController(Lazy<ICompanyService> lazyService,
            Lazy<IMapper> lazyMapper, IMyUrlHelper urlHelper)
        {
            this.lazyService = lazyService;
            this.lazyMapper = lazyMapper;
            this.urlHelper = urlHelper;
        }

        [HttpGet("{id}", Name = "GetCompany")]
        public async Task<IActionResult> GetCompany([FromRoute] int id)
        {
            using (Service)
            {
                return Ok();
            }
        }

        [AllowAnonymous]
        [HttpPatch("{id}")]
        public async Task<IActionResult> PartiallyUpdateCompany(int id, [FromBody]JsonPatchDocument<CreateCompanyModel> model)
        {
            var pp = new CreateCompanyModel { ComapnyId = id, CompanyName = "" };
            model.ApplyTo(pp);
            return NoContent();
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody]CreateCompanyModel companyModel)
        {
            using (Service)
            {
                var company = Service.Add(companyModel);

                await Service.CommitAsync();

                return CreatedAtRoute("GetCompany", new { id = company.Id }, company);
            }
        }

        //[HttpPut("{id}",Name = "UpdateCompany")]
        //public async Task<IActionResult> UpdateCompany(int id, [FromBody] CreateCompanyModel model)
        //{
        //    return NoContent();
        //}

        [HttpPut("{id}", Name = "UpdateCompanyCollection")]
        public async Task<IActionResult> UpdateCompanyCollection(int id, [FromBody] List<CreateCompanyModel> models)
        {
            var href = urlHelper.UrlHelper().Link("GetCompany", new { id = 1 });
            return NoContent();
        }
    }
}
