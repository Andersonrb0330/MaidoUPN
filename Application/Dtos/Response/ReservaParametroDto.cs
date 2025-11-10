using Domain.Entity;

namespace Application.Dtos.Response
{
    public class ReservaParametroDto
    {
        public int Id { get; set; }
        public string NombreCompleto { get; set; }
        public string CorreoElectronico { get; set; }
        public DateTime Fecha { get; set; }
        public TimeSpan Hora { get; set; }
        public int CantidadPersonas { get; set; }
        public string Notas { get; set; }
    }
}
