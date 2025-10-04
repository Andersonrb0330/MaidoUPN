using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Persistence.Context;

namespace Persistence.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void AddPersistenceProject(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<MaidoContext>(
                options => options.UseSqlServer(configuration.GetConnectionString("SqlMaido"),
                builder => builder.MigrationsAssembly(typeof(MaidoContext).Assembly.FullName)));
            services.AddScoped<IMaidoContext>(provider => provider.GetService<MaidoContext>());

            AddRepositories(services);
        }

        public static void AddRepositories(this IServiceCollection services)
        {
            
        }
    }
}
