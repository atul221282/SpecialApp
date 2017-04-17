using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using SpecialApp.Base;

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
                    Value = new { Errors = busEx.GetErrors() }
                };
            }
            else
            {
                context.Result = new JsonResult(exception)
                {
                    StatusCode = 500,
                    Value = new { Errors = exception.Message }
                };
            }
            context.ExceptionHandled = true;
        }
    }
}