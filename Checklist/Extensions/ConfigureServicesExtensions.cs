using Checklist.DAL;
using Microsoft.Extensions.DependencyInjection;

namespace Checklist.Extensions
{
    public static class ConfigureServicesExtensions
    {
        public static IServiceCollection AddCustomTypes(this IServiceCollection services)
        {
            services.AddScoped<IXTaskManager, XTaskService>();

            return services;
        }
    }
}