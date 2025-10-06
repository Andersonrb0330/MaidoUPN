using Domain.Entity;

namespace Domain.IRepositories
{
    public interface IExperienciaRepository
    {
        Task<List<Experiencia>> GetAll();
        Task<Experiencia> GetById(int id);
        Task Create(Experiencia experiencia);
        void Delete(Experiencia experiencia);
    }
}
