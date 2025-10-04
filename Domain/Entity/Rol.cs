namespace Domain.Entity
{
    public class Rol
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public ICollection<UsuarioRol> UsuarioRols { get; set; }
    }
}
