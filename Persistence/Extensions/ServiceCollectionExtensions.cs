using Domain.IRepositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Persistence.Context;
using Persistence.Repositories;

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
            services.AddTransient<ICategoriaRepository, CategoriaRepository>();
            services.AddTransient<IClienteRespoitory, ClienteRepository>();
            services.AddTransient<IExperienciaRepository, ExperienciaRepository>();
            services.AddTransient<IHistoriaClienteRepository, HistorialClienteRepository>();
            services.AddTransient<IMesaRepository, MesaRepository>();
            services.AddTransient<IPedidoDetalleRepository, PedidoDetalleRepository>();
            services.AddTransient<IPedidoRepository, PedidoRepository>();
            services.AddTransient<IReservaMesaRepositoy, ReservaMesaRepository>();
            services.AddTransient<IReservaRepository, ReservaRepository>();
            services.AddTransient<IRolRepository, RolRepository>();
            services.AddTransient<IUsuarioRepository, UsuarioRepository>();
            services.AddTransient<IUsuarioRolRepository, UsuarioRolRepository>();
            services.AddTransient<IUnitOfWork, UnitOfWork>();
        }
    }
}
