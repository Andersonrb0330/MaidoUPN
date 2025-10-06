using Domain.Entity;

namespace Domain.IRepositories
{
    public interface IMesaRepository
    {
        Task<List<Mesa>> GetAll();
        Task<Mesa> GetById(int id);
        Task Create(Mesa mesa);
        void Delete(Mesa mesa);
    }
}
