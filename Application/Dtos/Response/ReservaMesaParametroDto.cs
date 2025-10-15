using Domain.Entity;

namespace Application.Dtos.Response
{
    public class ReservaMesaParametroDto
    {
        public int Id { get; set; }
        public int IdReserva { get; set; }
        public int IdMesa { get; set; }
    }
}
