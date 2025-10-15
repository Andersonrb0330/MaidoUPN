using AutoMapper;
using Domain.Entity;

namespace Application.Dtos.Request
{
    public class HistorialClienteDto
    {
        public int Id { get; set; }
        public DateTime FechaVisita { get; set; }
        public string Observaciones { get; set; }

        public int IdCliente { get; set; }
        public ClienteDto Cliente { get; set; }
    }

    public class HistorialClienteProfile : Profile
    {
        public HistorialClienteProfile()
        {
            CreateMap<HistorialCliente, HistorialClienteDto>();
        }
    }
}
