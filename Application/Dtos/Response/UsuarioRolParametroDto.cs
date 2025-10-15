using Domain.Entity;

namespace Application.Dtos.Response
{
    public class UsuarioRolParametroDto
    {
        public int Id { get; set; }
        public int IdUsuario { get; set; }
        public int IdRol { get; set; }
    }
}
