using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SpecialApp.Service;

namespace SpecialApp.API.Controllers
{
    public class ValuesController : BaseApiController
    {
        private readonly Func<ITestService> tempServiceFunc;

        public ValuesController(Func<ITestService> tempServiceFunc)
        {
            this.tempServiceFunc = tempServiceFunc;
        }
        // GET api/values
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(new string[] { await tempServiceFunc().Test(), "value1", "value2" });
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            return Ok(new { data = $"{tempServiceFunc().Test()} {id}" });
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
