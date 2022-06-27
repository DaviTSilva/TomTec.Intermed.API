using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace TomTec.Intermed.Lib.AspNetCore.Filters
{
    public class KeyNotFoundExceptionFilterAttribute : ExceptionFilterAttribute
    {
        public override void OnException(ExceptionContext actionExecutedContext)
        {
            if (actionExecutedContext.Exception is KeyNotFoundException)
            {
                actionExecutedContext.Result = new NotFoundResult();
                return;
            }
        }
    }
}
