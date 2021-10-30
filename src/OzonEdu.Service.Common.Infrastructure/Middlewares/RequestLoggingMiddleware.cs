using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.Extensions.Logging;

namespace OzonEdu.Service.Common.Infrastructure.Middlewares
{
    public class RequestLoggingMiddleware
    {
        private readonly ILogger<RequestLoggingMiddleware> _logger;
        private readonly RequestDelegate _next;

        public RequestLoggingMiddleware(RequestDelegate next, ILogger<RequestLoggingMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            await LogRequest(context);
            await _next(context);
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
                    var bodyAsText = reader.ReadToEndAsync();
                    _logger.LogInformation("Request Body: " + bodyAsText);

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
                if (context.Response.ContentLength > 0)
                {
                    using var reader = new StreamReader(context.Response.Body, leaveOpen: true);
                    var bodyAsText = reader.ReadToEndAsync();
                    _logger.LogInformation("Response Body: " + bodyAsText);
                }
            }
            catch (Exception e)
            {
                _logger.LogError(e, "Could not log response body");
            }
        }
    }
}