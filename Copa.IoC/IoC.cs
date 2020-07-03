using Microsoft.Extensions.DependencyInjection;

namespace Copa.IoC
{
    public static class IoC
    {
        public static IServiceCollection ConfigureDependencies(this IServiceCollection services)
        {
            services = ApplyDependencyServices.ApplyDependencies(services);
            services = ApplyDependencyRepositories.ApplyDependencies(services);

            return services;
        }
    }
}
