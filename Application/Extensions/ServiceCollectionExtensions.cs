using Application.Implementations;
using Application.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Application.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void AddAplicationProject(this IServiceCollection services)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());

            services.AddTransient<ICategoriaService, CategoriaService>();
            services.AddTransient<IExperienciaService, ExperienciaService>();
            services.AddTransient<IHistorialClienteService, HistorialClienteService>();
            services.AddTransient<IMesaService, MesaService>();
            services.AddTransient<IPedidoService, PedidoService>();
            services.AddTransient<IPedidoDetalleService, PedidoDetalleService>();
            services.AddTransient<IReservaService, ReservaService>();
            services.AddTransient<IReservaMesaService, ReservaMesaService>();
            services.AddTransient<IRolService, RolService>();
            services.AddTransient<IUsuarioService, UsuarioService>();
            services.AddTransient<IUsuarioRolService, UsuarioRolService>();
        }
    }
}
