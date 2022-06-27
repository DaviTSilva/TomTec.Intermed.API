using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Mvc;

namespace TomTec.Intermed.Lib.AspNetCore.Filters
{
    public class UnauthorizedAccessExceptionFilterAttribute : ExceptionFilterAttribute
    {
        public override void OnException(ExceptionContext actionExecutedContext)
        {
            if (actionExecutedContext.Exception is UnauthorizedAccessException)
            {
                actionExecutedContext.Result = new UnauthorizedResult();
                return;
            }
        }
    }
}
