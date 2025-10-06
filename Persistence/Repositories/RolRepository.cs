using Domain.Entity;
using Domain.IRepositories;
using Microsoft.EntityFrameworkCore;
using Persistence.Context;

namespace Persistence.Repositories
{
    public class RolRepository : IRolRepository
    {
        private readonly IMaidoContext _maidoContext;

        public RolRepository(
            IMaidoContext maidoContext)
        {
            _maidoContext = maidoContext;
        }

        public async Task<List<Rol>> GetAll()
        {
            List<Rol> listRol = await _maidoContext.Roles
                                            .ToListAsync();
            return listRol;
        }

        public async Task<Rol> GetById(int id)
        {
            Rol rol = await _maidoContext.Roles
                                 .FirstOrDefaultAsync(r => r.Id == id);
            return rol;
        }

        public async Task Create(Rol rol)
        {
            await _maidoContext.Roles.AddAsync(rol);
        }

        public void Delete(Rol rol)
        {
            _maidoContext.Roles.Remove(rol);
        }
    }
}
