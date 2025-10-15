using AutoMapper;
using Domain.Entity;

namespace Application.Dtos.Request
{
    public class PedidoDetalleDto
    {
        public int Id { get; set; }
        public int Cantidad { get; set; }
        public decimal PrecioUnitario { get; set; }
        public string Comentarios { get; set; }

        public int IdPedido { get; set; }
        public PedidoDto Pedido { get; set; }

        public int IdExperiencia { get; set; }
        public ExperienciaDto Experiencia { get; set; }
    }
    public class PedidoDetalleProfile : Profile
    {
        public PedidoDetalleProfile()
        {
            CreateMap<PedidoDetalle, PedidoDetalleDto>();
        }
    }
}
