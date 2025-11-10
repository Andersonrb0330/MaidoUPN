using Domain.Entity;

namespace Application.Dtos.Response
{
    public class HistorialClienteParametroDto
    {
        public int Id { get; set; }
        public DateTime FechaVisita { get; set; }
        public string Observaciones { get; set; }

        public int IdReserva { get; set; }
    }
}
