using AutoMapper;
using Domain.Entity;

namespace Application.Dtos.Request
{
    public class UsuarioDto
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Estado { get; set; }
        public DateTime CreadoEn { get; set; }
    }
    public class UsuarioProfile : Profile
    {
        public UsuarioProfile()
        {
            CreateMap<Usuario, UsuarioDto>();
        }
    }
}
