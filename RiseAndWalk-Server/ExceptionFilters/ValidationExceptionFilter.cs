using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Net;

namespace RiseAndWalk_Server.ExceptionFilters
{
    public class ValidationExceptionFilter : Attribute, IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            if (!(context.Exception is ValidationException)) return;

            ValidationException exception = (ValidationException)context.Exception;

            context.Result = new JsonResult(exception.ErrorType)
            {
                StatusCode = (int) HttpStatusCode.BadRequest
            };

            context.ExceptionHandled = true;
        }
    }
}
