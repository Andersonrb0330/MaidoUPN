namespace Domain.Entity
{
    public class ReservaMesa
    {
        public int Id { get; set; }
        public int IdReserva { get; set; }
        public virtual Reserva Reserva { get; set; }

        public int IdMesa { get; set; }
        public virtual Mesa Mesa { get; set; }
    }
}
