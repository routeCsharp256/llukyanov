using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace OzonEdu.Service.Common.Infrastructure.Middlewares
{
    public class LiveMiddleware
    {
        public LiveMiddleware(RequestDelegate next)
        {
        }

        public async Task InvokeAsync(HttpContext context)
        {
            context.Response.StatusCode = (int) HttpStatusCode.OK;
        }
    }
}