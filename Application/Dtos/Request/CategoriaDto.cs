using AutoMapper;
using Domain.Entity;

namespace Application.Dtos.Request
{
    public class CategoriaDto
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
    }

    public class CategoriaProfile : Profile
    {
        public CategoriaProfile()
        {
            CreateMap<Categoria, CategoriaDto>();
        }
    }
}
