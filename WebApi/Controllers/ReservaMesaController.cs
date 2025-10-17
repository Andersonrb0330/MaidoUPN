using Application.Dtos.Request;
using Application.Dtos.Response;
using Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/reserva_mesa")]
    [ApiController]
    public class ReservaMesaController : ControllerBase
    {
        private readonly IReservaMesaService _reservaMesaService;

        public ReservaMesaController(
            IReservaMesaService reservaMesaService
            )
        {
            _reservaMesaService = reservaMesaService;
        }

        [HttpGet]
        public async Task<ActionResult<List<ReservaMesaDto>>> GetAll()
        {
            List<ReservaMesaDto> reservaMesaDtos = await _reservaMesaService.GetAll();
            return reservaMesaDtos;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ReservaMesaDto>> GetById(int id)
        {
            ReservaMesaDto reservaMesaDto = await _reservaMesaService.GetById(id);
            return reservaMesaDto;
        }

        [HttpPost]
        public async Task<ActionResult<int>> PostCreate([FromBody] ReservaMesaParametroDto reservaMesaParametroDto)
        {
            int id = await _reservaMesaService.Create(reservaMesaParametroDto);
            return Ok(id);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, [FromBody] ReservaMesaParametroDto reservaMesaParametroDto)
        {
            reservaMesaParametroDto.Id = id;
            await _reservaMesaService.Update(reservaMesaParametroDto);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            await _reservaMesaService.Delete(id);
            return Ok();
        }

    }
}
