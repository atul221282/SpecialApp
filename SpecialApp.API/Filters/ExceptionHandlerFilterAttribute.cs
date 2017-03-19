using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using SpecialApp.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SpecialApp.API.Filters
{
    public sealed class ExceptionHandlerFilterAttribute : ExceptionFilterAttribute
    {
        public override void OnException(ExceptionContext context)
        {
            var exception = context.Exception;

            if (exception.GetType() == typeof(BusinessException))
            {
                var busEx = exception as BusinessException;
                context.Result = new JsonResult(exception)
                {
                    StatusCode = 500,
                    Value = new { Data = busEx.GetErrors() }
                };
            }
            else
            {
                context.Result = new JsonResult(exception)
                {
                    StatusCode = 500,
                    Value = new { Data = exception.Message }
                };
            }
            context.ExceptionHandled = true;
        }
    }
}
