namespace Domain.Entity
{
    public class UsuarioRol
    {
        public int Id { get; set; }
        public int IdUsuario { get; set; }
        public virtual Usuario Usuario { get; set; }

        public int IdRol { get; set; }
        public virtual Rol Rol { get; set; }

    }
}
