using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SpecialApp.Service.Account;

namespace SpecialApp.API.Controllers.Company
{

    public class LookupController : BaseCompanyController
    {
        private readonly Lazy<ICompanyService> lazyService;
        private ICompanyService _service;

        public ICompanyService Service
        {
            get { return _service = _service ?? lazyService.Value; }
        }

        public LookupController(Lazy<ICompanyService> lazyService)
        {
            this.lazyService = lazyService;
        }

        // GET: api/Lookup
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            using (Service)
            {
                var result = await Service.GetLookup();
                return Ok(result);
            }
        }

        // GET: api/Lookup/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }
    }
}
