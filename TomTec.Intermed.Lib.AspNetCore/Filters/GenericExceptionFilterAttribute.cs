using Microsoft.AspNetCore.Mvc.Filters;
using System;
using Microsoft.AspNetCore.Mvc;

namespace TomTec.Intermed.Lib.AspNetCore.Filters
{
    public class GenericExceptionFilterAttribute : ExceptionFilterAttribute
    {
        public override void OnException(ExceptionContext actionExecutedContext)
        {
            if (actionExecutedContext.Exception is Exception)
            {
                actionExecutedContext.Result = new BadRequestResult();
                return;
            }
        }
    }
}
