using AutoMapper;
using Domain.Entity;

namespace Application.Dtos.Request
{
    public class HistorialClienteDto
    {
        public int Id { get; set; }
        public DateTime FechaVisita { get; set; }
        public string Observaciones { get; set; }

        public int IdReserva { get; set; }
        public ReservaDto Rerserva { get; set; }
    }

    public class HistorialClienteProfile : Profile
    {
        public HistorialClienteProfile()
        {
            CreateMap<HistorialCliente, HistorialClienteDto>();
        }
    }
}
