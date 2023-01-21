using NaiveEmr.ApplicationCore.Interfaces;
using NaiveEmr.ApplicationCore.Services;
using NaiveEmr.Infrastructure.Data;

namespace NaiveEmr.WebApi.Configuration
{
    public static class ConfigureCoreServices
    {
        public static IServiceCollection AddCoreServices(this IServiceCollection services,
        IConfiguration configuration)
        {
            services.AddScoped(typeof(IReadRepository<>), typeof(EfRepository<>));
            services.AddScoped(typeof(IRepository<>), typeof(EfRepository<>));

            services.AddScoped<IEmrDocumentService, EmrDocumentService>();

            return services;
        }
    }
}
