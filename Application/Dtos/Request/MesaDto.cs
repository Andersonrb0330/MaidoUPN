using AutoMapper;
using Domain.Entity;

namespace Application.Dtos.Request
{
    public class MesaDto
    {
        public int Id { get; set; }
        public int Numero { get; set; }
        public int Capacidad { get; set; }
        public string Ubicacion { get; set; }
        public string Estado { get; set; }
        public int Piso { get; set; }
    }
    public class MesaProfile : Profile
    {
        public MesaProfile()
        {
            CreateMap<Mesa, MesaDto>();
        }
    }
}
