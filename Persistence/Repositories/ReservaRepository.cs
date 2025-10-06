using Domain.Entity;
using Domain.IRepositories;
using Microsoft.EntityFrameworkCore;
using Persistence.Context;

namespace Persistence.Repositories
{
    public class ReservaRepository : IReservaRepository
    {
        private readonly IMaidoContext _maidoContext;

        public ReservaRepository(
            IMaidoContext maidoContext)
        {
            _maidoContext = maidoContext;
        }

        public async Task<List<Reserva>> GetAll()
        {
            List<Reserva> listReserva = await _maidoContext.Reservas
                                            .Include(r => r.Cliente)
                                            .ToListAsync();
            return listReserva;
        }

        public async Task<Reserva> GetById(int id)
        {
            Reserva reserva = await _maidoContext.Reservas
                                 .Include(r => r.Cliente)
                                 .FirstOrDefaultAsync(r => r.Id == id);
            return reserva;
        }

        public async Task Create(Reserva reserva)
        {
            await _maidoContext.Reservas.AddAsync(reserva);
        }

        public void Delete(Reserva reserva)
        {
            _maidoContext.Reservas.Remove(reserva);
        }
    }
}
