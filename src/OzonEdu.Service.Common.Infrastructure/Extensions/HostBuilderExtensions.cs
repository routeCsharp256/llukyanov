using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using OzonEdu.Service.Common.Infrastructure.Filters;
using OzonEdu.Service.Common.Infrastructure.Interceptors;
using OzonEdu.Service.Common.Infrastructure.StartupFilters;
using OzonEdu.Service.Common.Infrastructure.Swagger;

namespace OzonEdu.Service.Common.Infrastructure.Extensions
{
    public static class HostBuilderExtensions
    {
        public static IHostBuilder AddInfrastructure(this IHostBuilder builder)
        {
            builder.ConfigureServices(services =>
            {
                services.AddControllers(options => options.Filters.Add<GlobalExceptionFilter>());
                services.AddGrpc(options => options.Interceptors.Add<LoggingInterceptor>());
                services.AddSingleton<IStartupFilter, TerminalStartupFilter>();
                services.AddSingleton<IStartupFilter, SwaggerStartupFilter>();
                services.AddSwaggerGen(options =>
                {
                    options.SwaggerDoc("v1", new OpenApiInfo {Title = "OzonEdu.MerchandiseService", Version = "v1"});
                    options.CustomSchemaIds(x => x.FullName);
                    // TODO: убрать комментарий
                    // options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, $"{Assembly.GetExecutingAssembly().GetName().Name}.xml"));
                    options.OperationFilter<HeaderOperationFilter>();
                });
            });
            return builder;
        }
    }
}