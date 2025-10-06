using Domain.Entity;
using Domain.IRepositories;
using Microsoft.EntityFrameworkCore;
using Persistence.Context;

namespace Persistence.Repositories
{
    public class MesaRepository : IMesaRepository
    {
        private readonly IMaidoContext _maidoContext;

        public MesaRepository(
            IMaidoContext maidoContext)
        {
            _maidoContext = maidoContext;
        }

        public async Task<List<Mesa>> GetAll()
        {
            List<Mesa> listMesas = await _maidoContext.Mesas
                                            .ToListAsync();
            return listMesas;
        }

        public async Task<Mesa> GetById(int id)
        {
            Mesa mesa = await _maidoContext.Mesas
                                 .FirstOrDefaultAsync(m => m.Id == id);
            return mesa;
        }

        public async Task Create(Mesa mesa)
        {
            await _maidoContext.Mesas.AddAsync(mesa);
        }

        public void Delete(Mesa mesa)
        {
            _maidoContext.Mesas.Remove(mesa);
        }
    }
}
