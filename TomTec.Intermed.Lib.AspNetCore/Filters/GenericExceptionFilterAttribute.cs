using Microsoft.AspNetCore.Mvc.Filters;
using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace TomTec.Intermed.Lib.AspNetCore.Filters
{
    public class GenericExceptionFilterAttribute : ExceptionFilterAttribute
    {
        private ILogger<GenericExceptionFilterAttribute> _logger;

        public GenericExceptionFilterAttribute(ILogger<GenericExceptionFilterAttribute> logger)
        {
            _logger = logger;
        }

        public override void OnException(ExceptionContext actionExecutedContext)
        {
            if (actionExecutedContext.Exception is Exception)
            {
                _logger.LogError(new EventId(0), actionExecutedContext.Exception, actionExecutedContext.Exception.Message);
                actionExecutedContext.Result = new BadRequestResult();
                return;
            }
        }
    }
}
