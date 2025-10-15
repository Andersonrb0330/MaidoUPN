using AutoMapper;
using Domain.Entity;

namespace Application.Dtos.Request
{
    public class UsuarioRolDto
    {
        public int Id { get; set; }
        public int IdUsuario { get; set; }
        public UsuarioDto Usuario { get; set; }

        public int IdRol { get; set; }
        public RolDto Rol { get; set; }
    }
    public class UsuarioRolProfile : Profile
    {
        public UsuarioRolProfile()
        {
            CreateMap<UsuarioRol, UsuarioRolDto>();
        }
    }
}
