using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.Extensions.Logging;
using OzonEdu.Service.Common.Infrastructure.Tools;
using ServiceStack.Text;

namespace OzonEdu.Service.Common.Infrastructure.Middlewares
{
    public class RequestLoggingMiddleware
    {
        private readonly ILogger<RequestLoggingMiddleware> _logger;
        private readonly RequestDelegate _next;
        private readonly RecyclableMemoryStreamManager _responseStreamManager;

        public RequestLoggingMiddleware(RequestDelegate next, ILogger<RequestLoggingMiddleware> logger)
        {
            _next = next;
            _logger = logger;
            _responseStreamManager = new RecyclableMemoryStreamManager();
        }

        public async Task InvokeAsync(HttpContext context)
        {
            await LogRequest(context);
            await LogResponse(context);
        }

        private async Task LogRequest(HttpContext context)
        {
            try
            {
                _logger.LogInformation("Request logged");
                _logger.LogInformation("Request Headers: " + string.Join(";", context.Request.Headers));
                _logger.LogInformation("Request URL: " + context.Request.GetDisplayUrl());
                if (context.Request.ContentLength > 0)
                {
                    context.Request.EnableBuffering();
                    using var reader = new StreamReader(context.Request.Body, leaveOpen: true);
                    var bodyAsText = await reader.ReadToEndAsync();
                    _logger.LogInformation("Request Body: " + TextTools.RemoveWhitespaces(bodyAsText));

                    context.Request.Body.Position = 0;
                }
            }
            catch (Exception e)
            {
                _logger.LogError(e, "Could not log request body");
            }
        }

        private async Task LogResponse(HttpContext context)
        {
            try
            {
                _logger.LogInformation("Response logged");
                _logger.LogInformation("Response Headers: " + string.Join(";", context.Response.Headers));

                var originalBodyStream = context.Response.Body;
                await using var responseBody = _responseStreamManager.GetStream();
                context.Response.Body = responseBody;

                await _next(context);

                context.Response.Body.Seek(0, SeekOrigin.Begin);
                var bodyAsText = await new StreamReader(context.Response.Body).ReadToEndAsync();
                context.Response.Body.Seek(0, SeekOrigin.Begin);
                _logger.LogInformation("Response Body: " + TextTools.RemoveWhitespaces(bodyAsText));

                await responseBody.CopyToAsync(originalBodyStream);
            }
            catch (Exception e)
            {
                _logger.LogError(e, "Could not log response body");
            }
        }
    }
}