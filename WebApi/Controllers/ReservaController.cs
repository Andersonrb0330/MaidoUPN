using Application.Dtos.Request;
using Application.Dtos.Response;
using Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReservaController : ControllerBase
    {
        private readonly IReservaService _reservaService;

        public ReservaController(
            IReservaService reservaService
            )
        {
            _reservaService = reservaService;
        }

        [HttpGet]
        public async Task<ActionResult<List<ReservaDto>>> GetAll()
        {
            List<ReservaDto> reservaDtos = await _reservaService.GetAll();
            return reservaDtos;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ReservaDto>> GetById(int id)
        {
            ReservaDto categoriaDto = await _reservaService.GetById(id);
            return categoriaDto;
        }

        [HttpPost]
        public async Task<ActionResult<int>> PostCreate([FromBody] ReservaParametroDto reservaParametroDto)
        {
            int id = await _reservaService.Create(reservaParametroDto);
            return Ok(id);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, [FromBody] ReservaParametroDto reservaParametroDto)
        {
            reservaParametroDto.Id = id;
            await _reservaService.Update(reservaParametroDto);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            await _reservaService.Delete(id);
            return Ok();
        }

    }
}