using Domain.Entity;

namespace Domain.IRepositories
{
    public interface IReservaRepository
    {
        Task<List<Reserva>> GetAll();
        Task<Reserva> GetById(int id);
        Task Create(Reserva reserva);
        void Delete(Reserva reserva);
    }
}
