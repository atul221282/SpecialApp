using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.WebUtilities;
using SpecialApp.Base;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace SpecialApp.API.Controllers
{
    public class UploadFileController : BaseApiController
    {
        private readonly IHostingEnvironment _hostingEnvironment;


        public UploadFileController(IHostingEnvironment hostingEnvironment)
        {
            _hostingEnvironment = hostingEnvironment;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            //using (Service)
            //{
            //    //return File(stream, "application/pdf", id.ToString());
            //    byte[] doc = await Service.GetDocument(id);
            return SendFile(null, null, $"{id}.pdf");
            //}
        }


        //https://docs.microsoft.com/en-us/aspnet/core/mvc/models/file-uploads
        [HttpPost("UploadFiles")]
        public async Task<IActionResult> Post()
        {
            var multipartBoundary = Request.GetMultipartBoundary();
            if (string.IsNullOrEmpty(multipartBoundary))
            {
                return StatusCode(500, SetError($"Expected a multipart request, but got '{Request.ContentType}'."));
            }

            // Used to accumulate all the form url encoded key value pairs in the request.
            var formAccumulator = new KeyValueAccumulator();
            var reader = new MultipartReader(multipartBoundary, HttpContext.Request.Body);
            var section = await reader.ReadNextSectionAsync();
            byte[] doc = null;
            int id = 0;
            while (section != null)
            {
                // This will reparse the content disposition header
                // Create a FileMultipartSection using it's constructor to pass
                // in a cached disposition header
                var fileSection = section.AsFileSection();

                if (fileSection != null && !fileSection.FileName.IsPDF())
                {
                    return StatusCode(500, SetError("Invalid file. Only PDF's are allowed"));
                }
                if (fileSection != null)
                {
                    using (var targetStream = new MemoryStream())
                    {
                        await fileSection.FileStream.CopyToAsync(targetStream);
                        doc = targetStream.ToByteArray();
                    }
                }
                else
                {
                    var formSection = section.AsFormDataSection();
                    if (formSection != null)
                    {
                        var name = formSection.Name;
                        var value = await formSection.GetValueAsync();

                        if (int.TryParse(value, out id) == false)
                        {
                            return StatusCode(500, SetError("Invalid data"));
                        }

                        formAccumulator.Append(name, value);

                        if (formAccumulator.ValueCount > FormReader.DefaultValueCountLimit)
                        {
                            throw new InvalidDataException(
                                $"Form key count limit {FormReader.DefaultValueCountLimit} exceeded.");
                        }
                    }
                }
                // Drains any remaining section body that has not been consumed and
                // reads the headers for the next section.
                section = await reader.ReadNextSectionAsync();
            }

            //using (Service)
            //{
            //    if (doc.IsNullOrDefault() || id.IsNullOrDefault())
            //    {
            //        return StatusCode(500, SetError("Invalid request"));
            //    }
            //    var result = await Service.UpdateDocument(doc, id);
            return Ok();
            //}
        }
    }
}
