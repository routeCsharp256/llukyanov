using System;
using System.Reflection;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using OzonEdu.Service.Common.Infrastructure.Middlewares;

namespace OzonEdu.Service.Common.Infrastructure.StartupFilters
{
    public class TerminalStartupFilter : IStartupFilter
    {
        public Action<IApplicationBuilder> Configure(Action<IApplicationBuilder> next)
        {
            return app =>
            {
                app.Map("/version", b => b.Run(c => c.Response.WriteAsJsonAsync(GetVersion())));
                app.Map("/ready", b => b.Run(c => c.Response.WriteAsync("ready")));
                app.Map("/live", b => b.Run(c => c.Response.WriteAsync("live")));
                app.UseMiddleware<RequestLoggingMiddleware>();
                next(app);
            };
        }

        private object GetVersion()
        {
            var version = Assembly.GetEntryAssembly()?.GetName().Version?.ToString() ?? "No Version";
            var serviceName = Assembly.GetEntryAssembly()?.GetName().Name ?? "Unknown Service";

            return new
            {
                Version = version,
                ServiceName = serviceName
            };
        }
    }
}