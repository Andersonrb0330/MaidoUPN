namespace Domain.Entity
{
    public class Reserva
    {
        public int Id { get; set; }
        public DateTime Fecha { get; set; }
        public TimeSpan Hora { get; set; }
        public int CantidadPersonas { get; set; }
        public string Estado { get; set; }
        public string Notas { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        public int IdCliente { get; set; }
        public Cliente Cliente { get; set; }

        public ICollection<ReservaMesa> ReservaMesas { get; set; }
        public ICollection<Pedido> Pedidos { get; set; }
    }
}
