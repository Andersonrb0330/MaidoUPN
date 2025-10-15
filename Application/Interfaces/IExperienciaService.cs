using Application.Dtos.Request;
using Application.Dtos.Response;

namespace Application.Interfaces
{
    public interface IExperienciaService
    {
        Task<List<ExperienciaDto>> GetAll();
        Task<ExperienciaDto> GetById(int id);
        Task<int> Create(ExperienciaParametroDto experienciaParametroDto);
        Task Update(ExperienciaParametroDto experienciaParametroDto);
        Task Delete(int id);
    }
}
