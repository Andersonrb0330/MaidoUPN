namespace Domain.Entity
{
    public class Mesa
    {
        public int Id { get; set; }
        public int Numero { get; set; }
        public int Capacidad { get; set; }
        public string Ubicacion { get; set; }
        public string Estado { get; set; }

        public ICollection<ReservaMesa> ReservaMesas { get; set; }
    }
}
