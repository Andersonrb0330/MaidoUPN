using Application.Dtos.Request;
using Application.Dtos.Response;

namespace Application.Interfaces
{
    public interface IPedidoDetalleService
    {
        Task<List<PedidoDetalleDto>> GetAll();
        Task<PedidoDetalleDto> GetById(int id);
        Task<int> Create(PedidoDetalleParametroDto pedidoDetalleParametroDto);
        Task Update(PedidoDetalleParametroDto pedidoDetalleParametroDto);
        Task Delete(int id);
    }
}
