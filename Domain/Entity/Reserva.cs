namespace Domain.Entity
{
    public class Reserva
    {
        public int Id { get; set; }
        public string NombreCompleto{ get; set; }
        public string CorreoElectronico { get; set; }
        public string Telefono { get; set; }
        public string Dni { get; set; }
        public int CantidadPersonas { get; set; }
        public string Notas { get; set; }
        public DateTime Fecha { get; set; }
        public TimeSpan Hora { get; set; }

        public ICollection<HistorialCliente> HistorialClientes { get; set; }
        public ICollection<ReservaMesa> ReservaMesas { get; set; }
        public ICollection<Pedido> Pedidos { get; set; }
    }
}
