using Domain.Entity;

namespace Domain.IRepositories
{
    public interface IPedidoRepository
    {
        Task<List<Pedido>> GetAll();
        Task<Pedido> GetById(int id);
        Task Create(Pedido pedido);
        void Delete(Pedido pedido);
    }
}
