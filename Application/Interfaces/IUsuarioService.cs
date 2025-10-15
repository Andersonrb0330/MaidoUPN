using Application.Dtos.Request;
using Application.Dtos.Response;

namespace Application.Interfaces
{
    public interface IUsuarioService
    {
        Task<List<UsuarioDto>> GetAll();
        Task<UsuarioDto> GetById(int id);
        Task<int> Create(UsuarioParametroDto usuarioParametroDto);
        Task Update(UsuarioParametroDto usuarioParametroDto);
        Task Delete(int id);
    }
}
