using Application.Dtos.Request;
using Application.Dtos.Response;

namespace Application.Interfaces
{
    public interface IReservaService
    {
        Task<List<ReservaDto>> GetAll();
        Task<ReservaDto> GetById(int id);
        Task<int> Create(ReservaParametroDto reservaParametroDto);
        Task Update(ReservaParametroDto reservaParametroDto);
        Task Delete(int id);
    }
}
