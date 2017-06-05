using Microsoft.AspNetCore.Mvc;
using Optional;
using SpecialApp.API.Filters;
using SpecialApp.Entity;
using SpecialApp.Service;
using SpecialApp.Service.Proxy.AddressTypeProxy;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SpecialApp.API.Controllers
{

    public class ValuesController : BaseApiController
    {
        private readonly Func<IAddressTypeServiceProxy> addressTypeServiceProxy;
        private readonly Func<IFileDataService> fileDataServiceFunc;

        public ValuesController(Func<IAddressTypeServiceProxy> tempServiceFunc,
            Func<IFileDataService> fileDataServiceFunc)
        {
            this.addressTypeServiceProxy = tempServiceFunc;
            this.fileDataServiceFunc = fileDataServiceFunc;
        }

        // GET api/values
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var fileList = await fileDataServiceFunc().Get();

            var data = fileList.ValueOr(default(IEnumerable<FileData>));

            return Ok(data);
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            using (var service = addressTypeServiceProxy().GetService())
            {
                var addressTypeOption = await service.Get(id);

                var addresType = addressTypeOption.ValueOr(default(IAddressType));

                return Ok(addresType);
            }
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