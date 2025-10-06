using Domain.Entity;
using Domain.IRepositories;
using Microsoft.EntityFrameworkCore;
using Persistence.Context;

namespace Persistence.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly IMaidoContext _maidoContext;

        public UsuarioRepository(
            IMaidoContext maidoContext)
        {
            _maidoContext = maidoContext;
        }

        public async Task<List<Usuario>> GetAll()
        {
            List<Usuario> listUsuarios = await _maidoContext.Usuarios
                                            .ToListAsync();
            return listUsuarios;
        }

        public async Task<Usuario> GetById(int id)
        {
            Usuario usuario = await _maidoContext.Usuarios
                                 .FirstOrDefaultAsync(u => u.Id == id);
            return usuario;
        }

        public async Task Create(Usuario usuario)
        {
            await _maidoContext.Usuarios.AddAsync(usuario);
        }

        public void Delete(Usuario usuario)
        {
            _maidoContext.Usuarios.Remove(usuario);
        }
    }
}
