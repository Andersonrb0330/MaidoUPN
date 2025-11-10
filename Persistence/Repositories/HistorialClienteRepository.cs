using Domain.Entity;
using Domain.IRepositories;
using Microsoft.EntityFrameworkCore;
using Persistence.Context;

namespace Persistence.Repositories
{
    public class HistorialClienteRepository : IHistoriaClienteRepository
    {
        private readonly IMaidoContext _maidoContext;

        public HistorialClienteRepository(
            IMaidoContext maidoContext)
        {
            _maidoContext = maidoContext;
        }

        public async Task<List<HistorialCliente>> GetAll()
        {
            List<HistorialCliente> listHistorialClientes = await _maidoContext.HistorialClientes
                                            .Include(h => h.Reserva)
                                            .ToListAsync();
            return listHistorialClientes;
        }

        public async Task<HistorialCliente> GetById(int id)
        {
            HistorialCliente historialCliente = await _maidoContext.HistorialClientes
                                 .Include(h => h.Reserva)
                                 .FirstOrDefaultAsync(h => h.Id == id);
            return historialCliente;
        }

        public async Task Create(HistorialCliente historialCliente)
        {
            await _maidoContext.HistorialClientes.AddAsync(historialCliente);
        }

        public void Delete(HistorialCliente historialCliente)
        {
            _maidoContext.HistorialClientes.Remove(historialCliente);
        }
    }
}
