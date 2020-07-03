using Copa.Domain.Interfaces.Repositories;
using Copa.Infra.Data.Repository.SqlServer;
using Microsoft.Extensions.DependencyInjection;

namespace Copa.IoC
{
    public static class ApplyDependencyRepositories
    {
        public static IServiceCollection ApplyDependencies(IServiceCollection services)
        {
            services.AddTransient<IEquipeRepository, EquipeRepository>();
            return services;
        }
    }
}
