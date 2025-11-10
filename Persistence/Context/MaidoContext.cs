using Domain.Entity;
using Microsoft.EntityFrameworkCore;

namespace Persistence.Context
{
    public class MaidoContext : DbContext, IMaidoContext
    {
        public MaidoContext(DbContextOptions<MaidoContext> options) : base(options)
        {
        }

        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Experiencia> Experiencias { get; set; }
        public DbSet<HistorialCliente> HistorialClientes { get; set; }
        public DbSet<Mesa> Mesas { get; set; }
        public DbSet<Pedido> Pedidos { get; set; }
        public DbSet<PedidoDetalle> PedidoDetalles { get; set; }
        public DbSet<Reserva> Reservas { get; set; }
        public DbSet<ReservaMesa> ReservaMesas { get; set; }
        public DbSet<Rol> Roles { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<UsuarioRol> UsuarioRoles { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);
        }
        public override int SaveChanges()
        {
            return base.SaveChanges();
        }
    }
}
