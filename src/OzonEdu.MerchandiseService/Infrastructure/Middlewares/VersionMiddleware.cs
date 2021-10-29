using System.Reflection;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace OzonEdu.MerchandiseService.Infrastructure.Middlewares
{
    public class VersionMiddleware
    {
        public VersionMiddleware(RequestDelegate next)
        {
        }

        public async Task InvokeAsync(HttpContext context)
        {
            var version = Assembly.GetExecutingAssembly().GetName().Version?.ToString() ?? "No Version";
            var serviceName = Assembly.GetExecutingAssembly().GetName().Name ?? "Unknown Service";

            await context.Response.WriteAsJsonAsync(new
            {
                Version = version,
                ServiceName = serviceName
            });
        }
    }
}