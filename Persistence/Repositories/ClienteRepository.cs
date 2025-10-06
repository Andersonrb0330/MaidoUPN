using Domain.Entity;
using Domain.IRepositories;
using Microsoft.EntityFrameworkCore;
using Persistence.Context;

namespace Persistence.Repositories
{ 
    public class ClienteRepository : IClienteRespoitory
    {
        private readonly IMaidoContext _maidoContext;

        public ClienteRepository(
            IMaidoContext maidoContext)
        {
            _maidoContext = maidoContext;
        }

        public async Task<List<Cliente>> GetAll()
        {
            List<Cliente> listClientes = await _maidoContext.Clientes
                                           .ToListAsync();
            return listClientes;
        }

        public async Task<Cliente> GetById(int id)
        {
            Cliente cliente = await _maidoContext.Clientes
                                .FirstOrDefaultAsync(c => c.Id == id);
            return cliente;
        }

        public async Task Create(Cliente cliente)
        {
            await _maidoContext.Clientes.AddAsync(cliente);
        }

        public void Delete(Cliente cliente)
        {
            _maidoContext.Clientes.Remove(cliente);
        }
    }
}
