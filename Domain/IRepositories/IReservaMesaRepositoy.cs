using Domain.Entity;

namespace Domain.IRepositories
{
    public interface IReservaMesaRepositoy
    {
        Task<List<ReservaMesa>> GetAll();
        Task<ReservaMesa> GetById(int id);
        Task Create(ReservaMesa reservaMesa);
        void Delete(ReservaMesa reservaMesa);
    }
}
