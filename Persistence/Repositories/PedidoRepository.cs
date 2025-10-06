using Domain.Entity;
using Domain.IRepositories;
using Microsoft.EntityFrameworkCore;
using Persistence.Context;

namespace Persistence.Repositories
{
    public class PedidoRepository : IPedidoRepository
    {
        private readonly IMaidoContext _maidoContext;

        public PedidoRepository(
            IMaidoContext maidoContext)
        {
            _maidoContext = maidoContext;
        }

        public async Task<List<Pedido>> GetAll()
        {
            List<Pedido> listPedidos = await _maidoContext.Pedidos
                                            .Include(p => p.Reserva)
                                            .Include(p => p.Cliente)
                                            .ToListAsync();
            return listPedidos;
        }

        public async Task<Pedido> GetById(int id)
        {
            Pedido Pedido = await _maidoContext.Pedidos
                                 .Include(p => p.Reserva)
                                 .Include(p => p.Cliente)
                                 .FirstOrDefaultAsync(p => p.Id == id);
            return Pedido;
        }

        public async Task Create(Pedido pedido)
        {
            await _maidoContext.Pedidos.AddAsync(pedido);
        }

        public void Delete(Pedido pedido)
        {
            _maidoContext.Pedidos.Remove(pedido);
        }
    }
}
