using Domain.Entity;

namespace Domain.IRepositories
{
    public interface ICategoriaRepository
    {
        Task<List<Categoria>> GetAll();
        Task<Categoria> GetById(int id);
        Task Create(Categoria categoria);
        void Delete(Categoria categoria);
    }
}
