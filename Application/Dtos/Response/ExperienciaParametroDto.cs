using Domain.Entity;

namespace Application.Dtos.Response
{
    public class ExperienciaParametroDto
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public decimal Precio { get; set; }
        public bool Disponible { get; set; }

        public int IdCategoria { get; set; }
    }
}
