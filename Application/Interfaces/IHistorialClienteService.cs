using Application.Dtos.Request;
using Application.Dtos.Response;

namespace Application.Interfaces
{
    public interface IHistorialClienteService
    {
        Task<List<HistorialClienteDto>> GetAll();
        Task<HistorialClienteDto> GetById(int id);
        Task<int> Create(HistorialClienteParametroDto historialClienteParametroDto);
        Task Update(HistorialClienteParametroDto historialClienteParametroDto);
        Task Delete(int id);
    }
}
