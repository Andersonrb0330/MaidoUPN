namespace Domain.Entity
{
    public class HistorialCliente
    {
        public int Id { get; set; }
        public DateTime FechaVisita { get; set; }
        public string Observaciones { get; set; }

        public int IdReserva { get; set; }
        public virtual Reserva Reserva { get; set; }

    }
}
