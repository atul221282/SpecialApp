﻿using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Monad;
using SpecialApp.API.Filters;
using SpecialApp.API.Helpers;
using SpecialApp.Base;
using SpecialApp.Base.ServiceResponse;
using System;
using System.Collections.Generic;

namespace SpecialApp.API.Controllers
{
    [Route("api/[controller]")]
    [Produces("application/json")]
    [Consumes("application/json")]
    [ExceptionHandlerFilter]
    [EnableCors(APIGlobalConstants.CorsPolicy)]
    public abstract class BaseApiController : Controller
    {
        protected virtual object SetError(string message)
        {
            return new
            {
                Errors = new Dictionary<string, string>
                {
                    ["Error"] = message
                }
            };
        }

        /// <summary>
        /// Create file response with proper header
        /// </summary>
        /// <param name="data">File byte array</param>
        /// <param name="contentType">By default it is application/pdf</param>
        /// <param name="nameWithExtension">file name</param>
        /// <returns></returns>
        protected virtual FileContentResult SendFile(byte[] data, string contentType = "", string nameWithExtension = "")
        {
            byte[] doc = data;
            string mimeType = "application/pdf" ?? contentType;
            string name = nameWithExtension ?? Guid.NewGuid().ToString();
            Response.Headers.Append("Content-Disposition", $"inline; filename={name}");
            return File(data, mimeType, nameWithExtension);
        }

        /// <summary>
        /// Return Http Response based upon the either type
        /// </summary>
        /// <typeparam name="TRight">The expected value from user</typeparam>
        /// <param name="eitherResponse">Response value with correct right value and error left value</param>
        /// <returns></returns>
        protected virtual IActionResult EitherResponse<TRight>(Either<IErrorResponse, TRight> eitherResponse)
        {
            var either = eitherResponse();

            if (either.IsNullOrDefault())
                return StatusCode(500);

            if (either.IsRight)
                return Ok(either.Right);

            return StatusCode(either.Left.Code, SetError(either.Left.Error));
        }
    }
}