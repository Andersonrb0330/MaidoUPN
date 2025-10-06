using Domain.Entity;

namespace Domain.IRepositories
{
    public interface IRolRepository
    {
        Task<List<Rol>> GetAll();
        Task<Rol> GetById(int id);
        Task Create(Rol rol);
        void Delete(Rol rol);
    }
}
