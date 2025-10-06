using Domain.Entity;

namespace Domain.IRepositories
{
    public interface IClienteRespoitory
    {
        Task<List<Cliente>> GetAll();
        Task<Cliente> GetById(int id);
        Task Create(Cliente cliente);
        void Delete(Cliente cliente);
    }
}
