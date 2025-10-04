namespace Domain.Entity
{
    public class Pedido
    {
        public int Id { get; set; }
        public DateTime Fecha { get; set; }
        public string Estado { get; set; }

        public int IdReserva { get; set; }
        public virtual Reserva Reserva { get; set; }

        public int? IdCliente { get; set; }
        public virtual Cliente Cliente { get; set; }

        public ICollection<PedidoDetalle> PedidoDetalles { get; set; }
    }
}
