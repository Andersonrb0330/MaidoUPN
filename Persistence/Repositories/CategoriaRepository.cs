using Domain.Entity;
using Domain.IRepositories;
using Microsoft.EntityFrameworkCore;
using Persistence.Context;

namespace Persistence.Repositories
{
    public class CategoriaRepository : ICategoriaRepository
    {
        private readonly IMaidoContext _maidoContext;

        public CategoriaRepository(
            IMaidoContext maidoContext)
        {
            _maidoContext = maidoContext;
        }

        public async Task<List<Categoria>> GetAll()
        {
            List<Categoria> productos = await _maidoContext.Categorias
                                         .ToListAsync();
            return productos;
        }

        public async Task<Categoria> GetById(int id)
        {
            Categoria tipoProducto = await _maidoContext.Categorias
                                .FirstOrDefaultAsync(c => c.Id == id);
            return tipoProducto;
        }

        public async Task Create(Categoria categoria)
        {
            await _maidoContext.Categorias.AddAsync(categoria);
        }

        public void Delete(Categoria categoria)
        {
            _maidoContext.Categorias.Remove(categoria);
        }

    }
}
