using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.AspNetCore.Mvc.Routing;
using SpecialApp.API.Infrastructure;
using SpecialApp.Entity;
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
        private readonly Infrastructure.IUrlHelperResolver urlHelper;
        public ICompanyService Service=> _service = _service ?? lazyService.Value;

        public CompanyController(Lazy<ICompanyService> lazyService,
            Lazy<IMapper> lazyMapper, IUrlHelperResolver urlHelper)
        {
            this.lazyService = lazyService;
            this.lazyMapper = lazyMapper;
            this.urlHelper = urlHelper;
        }

        [HttpGet(Name = nameof(GetCollection))]
        public async Task<IActionResult> GetCollection()
        {
            using (Service)
            {
                var result = await Service.Get();

                var data = Result<IEnumerable<CompanyModel>>.Ok(result, CreateLinks());

                return Ok(data);
            }
        }

        [HttpGet("{id}", Name = nameof(GetCompany))]
        public async Task<IActionResult> GetCompany([FromRoute] int id)
        {
            using (Service)
            {
                var result = await Service.Get(id);

                var data = Result<CompanyModel>.Ok(result, CreateLinks());

                return Ok(result);
            }
        }

        [HttpPatch("{id}", Name = nameof(PartiallyUpdateCompany))]
        public async Task<IActionResult> PartiallyUpdateCompany(int id, [FromBody]JsonPatchDocument<CompanyModel> model)
        {
            var pp = new CompanyModel { ComapnyId = id, CompanyName = "" };

            model.ApplyTo(pp);

            return NoContent();
        }

        [HttpPost(Name = nameof(CreateCompany))]
        public async Task<IActionResult> CreateCompany([FromBody]CompanyModel companyModel)
        {
            using (Service)
            {
                var company = Service.Add(companyModel);

                await Service.CommitAsync();

                var data = Result<Entity.Companies.Company>.Ok(company, CreateLinks());

                return CreatedAtRoute(nameof(GetCompany), new { id = company.Id }, data);
            }
        }

        //[HttpPut("{id}",Name = "UpdateCompany")]
        //public async Task<IActionResult> UpdateCompany(int id, [FromBody] CreateCompanyModel model)
        //{
        //    return NoContent();
        //}

        [HttpPut("{id}", Name = nameof(UpdateCompanyCollection))]
        public async Task<IActionResult> UpdateCompanyCollection(int id, [FromBody] List<CompanyModel> models)
        {
            var data = Result<List<CompanyModel>>.Ok(models, CreateLinks());

            return Ok(data);
        }

        private List<HateoasLinks> CreateLinks()
        {
            return new List<HateoasLinks> {
                 new HateoasLinks {
                        Href =  urlHelper.UrlHelper.Link(nameof(GetCollection),null),
                        Rel = "get-company-collection",
                        Method = "GET"
                    },
                    new HateoasLinks {
                        Href =  urlHelper.UrlHelper.Link(nameof(GetCompany), new { id = 1 }),
                        Rel = "get-full-company",
                        Method = "GET"
                    },
                    new HateoasLinks {
                        Href = urlHelper.UrlHelper.Link(nameof(CreateCompany),null),
                        Rel = "create-company",
                        Method = "POST"
                    },
                     new HateoasLinks {
                        Href = urlHelper.UrlHelper.Link(nameof(UpdateCompanyCollection),null),
                        Rel = "update-company",
                        Method = "PUT"
                    },
                      new HateoasLinks {
                        Href = urlHelper.UrlHelper.Link(nameof(PartiallyUpdateCompany),null),
                        Rel = "patch-company",
                        Method = "PATCH"
                    }
                };
        }
    }
}
