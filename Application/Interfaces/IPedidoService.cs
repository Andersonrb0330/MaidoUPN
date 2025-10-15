using Application.Dtos.Request;
using Application.Dtos.Response;

namespace Application.Interfaces
{
    public interface IPedidoService
    {
        Task<List<PedidoDto>> GetAll();
        Task<PedidoDto> GetById(int id);
        Task<int> Create(PedidoParametroDto pedidoParametroDto);
        Task Update(PedidoParametroDto pedidoParametroDto);
        Task Delete(int id);
    }
}
