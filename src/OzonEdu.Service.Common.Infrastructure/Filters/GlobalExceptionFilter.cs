using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;

namespace OzonEdu.Service.Common.Infrastructure.Filters
{
    public class GlobalExceptionFilter : ExceptionFilterAttribute
    {
        private readonly ILogger<GlobalExceptionFilter> _logger;

        public GlobalExceptionFilter(ILogger<GlobalExceptionFilter> logger)
        {
            _logger = logger;
        }

        public override void OnException(ExceptionContext context)
        {
            var resultObject = new
            {
                ExceptionType = context.Exception.GetType().FullName,
                context.Exception.Message,
                context.Exception.StackTrace
            };
            var jsonResult = new JsonResult(resultObject)
            {
                StatusCode = StatusCodes.Status500InternalServerError
            };
            context.Result = jsonResult;
        }
    }
}