using Domain.Entity;
using Domain.IRepositories;
using Microsoft.EntityFrameworkCore;
using Persistence.Context;

namespace Persistence.Repositories
{
    public class ExperienciaRepository : IExperienciaRepository
    {
        private readonly IMaidoContext _maidoContext;

        public ExperienciaRepository(
            IMaidoContext maidoContext)
        {
            _maidoContext = maidoContext;
        }

        public async Task<List<Experiencia>> GetAll()
        {
            List<Experiencia> listExperiencias = await _maidoContext.Experiencias
                                            .Include(e => e.Categoria)
                                            .ToListAsync();
            return listExperiencias;
        }

        public async Task<Experiencia> GetById(int id)
        {
            Experiencia experiencia = await _maidoContext.Experiencias
                                 .Include(e => e.Categoria)
                                 .FirstOrDefaultAsync(e => e.Id == id);
            return experiencia;
        }

        public async Task Create(Experiencia experiencia)
        {
            await _maidoContext.Experiencias.AddAsync(experiencia);
        }

        public void Delete(Experiencia experiencia)
        {
            _maidoContext.Experiencias.Remove(experiencia);
        }

    }
}
