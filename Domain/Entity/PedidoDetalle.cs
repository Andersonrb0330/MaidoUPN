namespace Domain.Entity
{
    public class PedidoDetalle
    {
        public int Id { get; set; }
        public int Cantidad { get; set; }
        public decimal PrecioUnitario { get; set; }
        public string Comentarios { get; set; }

        public int IdPedido { get; set; }
        public virtual Pedido Pedido { get; set; }

        public int IdExperiencia { get; set; }
        public virtual Experiencia Experiencia { get; set; }

    }
}

