using Domain.Entity;
using Domain.IRepositories;
using Microsoft.EntityFrameworkCore;
using Persistence.Context;

namespace Persistence.Repositories
{
    public class PedidoDetalleRepository : IPedidoDetalleRepository
    {
        private readonly IMaidoContext _maidoContext;

        public PedidoDetalleRepository(
            IMaidoContext maidoContext)
        {
            _maidoContext = maidoContext;
        }

        public async Task<List<PedidoDetalle>> GetAll()
        {
            List<PedidoDetalle> listPedidoDetalles = await _maidoContext.PedidoDetalles
                                            .Include(pd => pd.Pedido)
                                            .Include(pd => pd.Experiencia)
                                            .ToListAsync();
            return listPedidoDetalles;
        }

        public async Task<PedidoDetalle> GetById(int id)
        {
            PedidoDetalle pedidoDetalle = await _maidoContext.PedidoDetalles
                                 .Include(pd => pd.Pedido)
                                 .Include(pd => pd.Experiencia)
                                 .FirstOrDefaultAsync(pd => pd.Id == id);
            return pedidoDetalle;
        }

        public async Task Create(PedidoDetalle pedidoDetalle)
        {
            await _maidoContext.PedidoDetalles.AddAsync(pedidoDetalle);
        }

        public void Delete(PedidoDetalle pedidoDetalle)
        {
            _maidoContext.PedidoDetalles.Remove(pedidoDetalle);
        }
    }
}
