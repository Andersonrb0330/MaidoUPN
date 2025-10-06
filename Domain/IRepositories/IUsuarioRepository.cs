using Domain.Entity;

namespace Domain.IRepositories
{
    public interface IUsuarioRepository
    {
        Task<List<Usuario>> GetAll();
        Task<Usuario> GetById(int id);
        Task Create(Usuario usuario);
        void Delete(Usuario usuario);
    }
}
