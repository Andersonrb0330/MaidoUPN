using AutoMapper;
using Domain.Entity;

namespace Application.Dtos.Request
{
    public class ClienteDto
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string ApellidoPaterno { get; set; }
        public string ApellidoMaterno { get; set; }
        public string Email { get; set; }
        public string Telefono { get; set; }
        public string Alergias { get; set; }
        public string Preferencias { get; set; }
        public DateTime? FechaNacimiento { get; set; }
        public DateTime FechaRegistro { get; set; }
    }

    public class ClienteProfile : Profile
    {
        public ClienteProfile()
        {
            CreateMap<Cliente, ClienteDto>();
        }
    }
}
