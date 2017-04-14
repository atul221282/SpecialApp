using Microsoft.AspNetCore.Mvc;
using SpecialApp.API.Filters;
using SpecialApp.Entity;
using SpecialApp.Service;
using System;
using System.Threading.Tasks;

namespace SpecialApp.API.Controllers
{
    
    public class ValuesController : BaseApiController
    {
        private readonly Func<IAddressTypeService> tempServiceFunc;

        public ValuesController(Func<IAddressTypeService> tempServiceFunc)
        {
            this.tempServiceFunc = tempServiceFunc;
        }

        // GET api/values
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            AddressType at = null;
            try
            {
                at = await tempServiceFunc().Get();
                if (at == null)
                {
                    tempServiceFunc().Add();
                    await tempServiceFunc().CommitAsync();
                    at = await tempServiceFunc().Get();
                }
            }
            catch (Exception ex)
            {
            }
            return Ok(new string[] { at?.Description, "value1", "value2" });
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            return Ok(new { data = $"{(await tempServiceFunc().Get()).Description} {id}" });
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