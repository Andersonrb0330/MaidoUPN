using Domain.Entity;

namespace Application.Dtos.Response
{
    public class ReservaParametroDto
    {
        public int Id { get; set; }
        public DateTime Fecha { get; set; }
        public TimeSpan Hora { get; set; }
        public int CantidadPersonas { get; set; }
        public string Estado { get; set; }
        public string Notas { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        public int IdCliente { get; set; }
    }
}
