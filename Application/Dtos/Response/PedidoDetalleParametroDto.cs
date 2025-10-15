namespace Application.Dtos.Response
{
    public class PedidoDetalleParametroDto
    {
        public int Id { get; set; }
        public int Cantidad { get; set; }
        public decimal PrecioUnitario { get; set; }
        public string Comentarios { get; set; }

        public int IdPedido { get; set; }

        public int IdExperiencia { get; set; }
    }
}
