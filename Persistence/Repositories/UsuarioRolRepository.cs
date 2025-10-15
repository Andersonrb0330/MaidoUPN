using Domain.Entity;
using Domain.IRepositories;
using Microsoft.EntityFrameworkCore;
using Persistence.Context;

namespace Persistence.Repositories
{
    public class UsuarioRolRepository : IUsuarioRolRepository
    {
        private readonly IMaidoContext _maidoContext;

        public UsuarioRolRepository(
            IMaidoContext maidoContext)
        {
            _maidoContext = maidoContext;
        }

        public async Task<List<UsuarioRol>> GetAll()
        {
            List<UsuarioRol> listUsuarioRoles = await _maidoContext.UsuarioRoles
                                            .Include(ur => ur.Usuario)
                                            .Include(ur => ur.Rol)
                                            .ToListAsync();
            return listUsuarioRoles;
        }

        public async Task<UsuarioRol> GetById(int id)
        {
            UsuarioRol usuarioRol = await _maidoContext.UsuarioRoles
                                 .Include(ur => ur.Usuario)
                                 .Include(ur => ur.Rol)
                                 .FirstOrDefaultAsync(ur => ur.Id == id);
            return usuarioRol; 
        }

        public async Task Create(UsuarioRol usuarioRol)
        {
            await _maidoContext.UsuarioRoles.AddAsync(usuarioRol);
        }

        public void Delete(UsuarioRol usuarioRol)
        {
            _maidoContext.UsuarioRoles.Remove(usuarioRol);
        }
    }
}
