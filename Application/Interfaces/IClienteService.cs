using Application.Dtos.Request;
using Application.Dtos.Response;

namespace Application.Interfaces
{
    public interface IClienteService
    {
        Task<List<ClienteDto>> GetAll();
        Task<ClienteDto> GetById(int id);
        Task<int> Create(ClienteParametroDto clienteParametroDto);
        Task Update(ClienteParametroDto clienteParametroDto);
        Task Delete(int id);
    }
}
