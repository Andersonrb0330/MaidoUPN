namespace Domain.Entity
{
    public class HistorialCliente
    {
        public int Id { get; set; }
        public DateTime FechaVisita { get; set; }
        public string Observaciones { get; set; }

        public int IdCliente { get; set; }
        public virtual Cliente Cliente { get; set; }

    }
}
