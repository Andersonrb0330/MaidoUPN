using AutoMapper;
using Domain.Entity;

namespace Application.Dtos.Request
{
    public class RolDto
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
    }
    public class RolProfile : Profile
    {
        public RolProfile()
        {
            CreateMap<Rol, RolDto>();
        }
    }
}
