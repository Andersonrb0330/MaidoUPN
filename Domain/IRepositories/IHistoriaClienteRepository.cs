using Domain.Entity;

namespace Domain.IRepositories
{
    public interface IHistoriaClienteRepository
    {
        Task<List<HistorialCliente>> GetAll();
        Task<HistorialCliente> GetById(int id);
        Task Create(HistorialCliente historialCliente);
        void Delete(HistorialCliente historialCliente);
    }
}
