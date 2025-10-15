using AutoMapper;
using Domain.Entity;

namespace Application.Dtos.Request
{
    public class ReservaMesaDto
    {
        public int Id { get; set; }
        public int IdReserva { get; set; }
        public ReservaDto Reserva { get; set; }

        public int IdMesa { get; set; }
        public MesaDto Mesa { get; set; }
    }
    public class ReservaMesaProfile : Profile
    {
        public ReservaMesaProfile()
        {
            CreateMap<ReservaMesa, ReservaMesaDto>();
        }
    }
}
