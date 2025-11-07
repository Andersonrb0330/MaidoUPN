namespace Domain.Entity
{
    public class Usuario
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Estado { get; set; }
        public ICollection<UsuarioRol> UsuarioRols { get; set; }
    }
}
