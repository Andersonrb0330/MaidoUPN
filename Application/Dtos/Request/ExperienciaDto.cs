using AutoMapper;
using Domain.Entity;

namespace Application.Dtos.Request
{
    public class ExperienciaDto
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public decimal Precio { get; set; }
        public bool Disponible { get; set; }

        public int IdCategoria { get; set; }
        public CategoriaDto Categoria { get; set; }
    }

    public class ExperienciaProfile : Profile
    {
        public ExperienciaProfile()
        {
            CreateMap<Experiencia, ExperienciaDto>();
        }
    }
}
