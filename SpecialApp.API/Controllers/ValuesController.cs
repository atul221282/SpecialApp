using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace SpecialApp.API.Controllers
{
    public class ValuesController : BaseApiController
    {
        private readonly ITempService tempService;

        public ValuesController(ITempService tempService)
        {
            this.tempService = tempService;
        }
        // GET api/values
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(new string[] { tempService.Test(), "value1", "value2" });
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            return Ok(new { data = $"{tempService.Test()} {id}" });
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
