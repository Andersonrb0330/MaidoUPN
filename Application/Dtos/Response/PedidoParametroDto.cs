using Domain.Entity;

namespace Application.Dtos.Response
{
    public class PedidoParametroDto
    {
        public int Id { get; set; }
        public DateTime Fecha { get; set; }
        public string Estado { get; set; }
        public double Total { get; set; }
        public int IdReserva { get; set; }
    }
}
