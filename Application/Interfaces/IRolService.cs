using Application.Dtos.Request;
using Application.Dtos.Response;

namespace Application.Interfaces
{
    public interface IRolService
    {
        Task<List<RolDto>> GetAll();
        Task<RolDto> GetById(int id);
        Task<int> Create(RolParametroDto rolParametroDto);
        Task Update(RolParametroDto rolParametroDto);
        Task Delete(int id);
    }
}
