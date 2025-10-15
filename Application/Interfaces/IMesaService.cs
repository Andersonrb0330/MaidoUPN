using Application.Dtos.Request;
using Application.Dtos.Response;

namespace Application.Interfaces
{
    public interface IMesaService
    {
        Task<List<MesaDto>> GetAll();
        Task<MesaDto> GetById(int id);
        Task<int> Create(MesaParametroDto mesaParametroDto);
        Task Update(MesaParametroDto mesaParametroDto);
        Task Delete(int id);
    }
}
