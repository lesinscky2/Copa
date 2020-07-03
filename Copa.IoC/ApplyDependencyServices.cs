using Copa.Domain.Interfaces.Services;
using Copa.Domain.Services.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Copa.IoC
{
    public static class ApplyDependencyServices
    {
        public static IServiceCollection ApplyDependencies(IServiceCollection services)
        {
            services.AddTransient<IEquipeService, EquipeService>();

            return services;
        }
    }
}
