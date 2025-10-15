using Application.Dtos.Request;
using Application.Dtos.Response;

namespace Application.Interfaces
{
    public interface IReservaMesaService
    {
        Task<List<ReservaMesaDto>> GetAll();
        Task<ReservaMesaDto> GetById(int id);
        Task<int> Create(ReservaMesaParametroDto reservaMesaParametroDto);
        Task Update(ReservaMesaParametroDto reservaMesaParametroDto);
        Task Delete(int id);
    }
}
