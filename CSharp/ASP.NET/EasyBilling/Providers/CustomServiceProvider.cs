using EasyBilling.Services;
using Microsoft.Extensions.DependencyInjection;

namespace EasyBilling.Providers
{
    public static class CustomServiceProvider
    {
        public static void AddAccessRightsManager(this IServiceCollection services)
        {
            services.AddScoped<AccessRightsManager>();
        }
    }
}
