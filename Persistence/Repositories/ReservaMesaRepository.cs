using Domain.Entity;
using Domain.IRepositories;
using Microsoft.EntityFrameworkCore;
using Persistence.Context;

namespace Persistence.Repositories
{
    public class ReservaMesaRepository : IReservaMesaRepositoy
    {
        private readonly IMaidoContext _maidoContext;

        public ReservaMesaRepository(
            IMaidoContext maidoContext)
        {
            _maidoContext = maidoContext;
        }

        public async Task<List<ReservaMesa>> GetAll()
        {
            List<ReservaMesa> listReservaMesas = await _maidoContext.ReservaMesas
                                            .Include(rm => rm.Reserva)
                                            .Include(rm => rm.Mesa)
                                            .ToListAsync();
            return listReservaMesas;
        }

        public async Task<ReservaMesa> GetById(int id)
        {
            ReservaMesa reservaMesa = await _maidoContext.ReservaMesas
                                 .Include(rm => rm.Reserva)
                                 .Include(rm => rm.Mesa)
                                 .FirstOrDefaultAsync(rm => rm.Id == id);
            return reservaMesa;
        }

        public async Task Create(ReservaMesa reservaMesa)
        {
            await _maidoContext.ReservaMesas.AddAsync(reservaMesa);
        }

        public void Delete(ReservaMesa reservaMesa)
        {
            _maidoContext.ReservaMesas.Remove(reservaMesa);
        }
    }
}
