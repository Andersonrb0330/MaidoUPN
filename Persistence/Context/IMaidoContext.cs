using Domain.Entity;
using Microsoft.EntityFrameworkCore;

namespace Persistence.Context
{
    public interface IMaidoContext
    {
        DbSet<Categoria> Categorias { get; set; }
        DbSet<Experiencia> Experiencias { get; set; }
        DbSet<HistorialCliente> HistorialClientes { get; set; }
        DbSet<Mesa> Mesas { get; set; }
        DbSet<Pedido> Pedidos { get; set; }
        DbSet<PedidoDetalle> PedidoDetalles { get; set; }
        DbSet<Reserva> Reservas { get; set; }
        DbSet<ReservaMesa> ReservaMesas { get; set; }
        DbSet<Rol> Roles { get; set; }
        DbSet<Usuario> Usuarios { get; set; }
        DbSet<UsuarioRol> UsuarioRoles { get; set; }

        int SaveChanges();
    }
}
