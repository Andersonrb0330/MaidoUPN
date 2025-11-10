namespace Domain.Entity
{
    public class Pedido
    {
        public int Id { get; set; }
        public DateTime Fecha { get; set; }
        public string Estado { get; set; }
        public double Total { get; set; }
        public int IdReserva { get; set; }
        public virtual Reserva Reserva { get; set; }

        public ICollection<PedidoDetalle> PedidoDetalles { get; set; }
    }
}
