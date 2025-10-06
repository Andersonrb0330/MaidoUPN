using Domain.Entity;

namespace Domain.IRepositories
{
    public interface IPedidoDetalleRepository
    {
        Task<List<PedidoDetalle>> GetAll();
        Task<PedidoDetalle> GetById(int id);
        Task Create(PedidoDetalle pedidoDetalle);
        void Delete(PedidoDetalle pedidoDetalle);
    }
}
