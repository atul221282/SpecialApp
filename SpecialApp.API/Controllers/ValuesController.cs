using Microsoft.AspNetCore.Mvc;
using Optional;
using SpecialApp.API.Filters;
using SpecialApp.Entity;
using SpecialApp.Service;
using System;
using System.Collections.Generic;
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
            var at = await tempServiceFunc().Get();

            var data = at.ValueOr(default(IEnumerable<IAddressType>));

            return Ok(data);
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var addressTypeOption = await tempServiceFunc().Get(id);

            var addresType = addressTypeOption.ValueOr(default(IAddressType));

            return Ok(addresType);
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