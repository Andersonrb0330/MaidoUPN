using Application.Dtos.Request;
using Application.Dtos.Response;

namespace Application.Interfaces
{
    public interface IUsuarioRolService
    {
        Task<List<UsuarioRolDto>> GetAll();
        Task<UsuarioRolDto> GetById(int id);
        Task<int> Create(UsuarioRolParametroDto usuarioRolParametroDto);
        Task Update(UsuarioRolParametroDto usuarioRolParametroDto);
        Task Delete(int id);
    }
}
