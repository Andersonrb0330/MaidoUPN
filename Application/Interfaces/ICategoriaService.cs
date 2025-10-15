using Application.Dtos.Request;
using Application.Dtos.Response;

namespace Application.Interfaces
{
    public interface ICategoriaService
    {
        Task<List<CategoriaDto>> GetAll();
        Task<CategoriaDto> GetById(int id);
        Task<int> Create(CategoriaParametroDto categoriaParametroDto);
        Task Update(CategoriaParametroDto categoriaParametroDto);
        Task Delete(int id);
    }
}
