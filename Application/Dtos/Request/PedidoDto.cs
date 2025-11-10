using AutoMapper;
using Domain.Entity;

namespace Application.Dtos.Request
{
    public class PedidoDto
    {
        public int Id { get; set; }
        public DateTime Fecha { get; set; }
        public string Estado { get; set; }
        public double Total { get; set; }
        public int IdReserva { get; set; }
        public ReservaDto Reserva { get; set; }
    }
    public class PedidoProfile : Profile
    {
        public PedidoProfile()
        {
            CreateMap<Pedido, PedidoDto>();
        }
    }
}
