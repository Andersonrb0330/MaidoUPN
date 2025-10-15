using AutoMapper;
using Domain.Entity;

namespace Application.Dtos.Request
{
    public class PedidoDto
    {
        public int Id { get; set; }
        public DateTime Fecha { get; set; }
        public string Estado { get; set; }

        public int IdReserva { get; set; }
        public ReservaDto Reserva { get; set; }

        public int? IdCliente { get; set; }
        public ClienteDto Cliente { get; set; }
    }
    public class PedidoProfile : Profile
    {
        public PedidoProfile()
        {
            CreateMap<Pedido, PedidoDto>();
        }
    }
}
