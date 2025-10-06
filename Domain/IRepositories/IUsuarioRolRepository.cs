using Domain.Entity;

namespace Domain.IRepositories
{
    public interface IUsuarioRolRepository
    {
        Task<List<UsuarioRol>> GetAll();
        Task<UsuarioRol> GetById(int id);
        Task Create(UsuarioRol usuarioRol);
        void Delete(UsuarioRol usuarioRol);
    }
}
