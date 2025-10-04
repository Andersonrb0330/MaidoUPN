namespace Domain.Entity
{
    public class Experiencia
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public decimal Precio { get; set; }
        public bool Disponible { get; set; }

        public int IdCategoria { get; set; }
        public virtual Categoria Categoria { get; set; }

        public ICollection<PedidoDetalle> PedidoDetalles { get; set; }
    }
}
