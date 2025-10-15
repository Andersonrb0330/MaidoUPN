using Application.Dtos.Request;
using Application.Dtos.Response;
using Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PedidoController : ControllerBase
    {
        private readonly IPedidoService _pedidoService;

        public PedidoController(
            IPedidoService pedidoService
            )
        {
            _pedidoService = pedidoService;
        }

        [HttpGet]
        public async Task<ActionResult<List<PedidoDto>>> GetAll()
        {
            List<PedidoDto> pedidoDtos = await _pedidoService.GetAll();
            return pedidoDtos;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<PedidoDto>> GetById(int id)
        {
            PedidoDto pedidoDto = await _pedidoService.GetById(id);
            return pedidoDto;
        }

        [HttpPost]
        public async Task<ActionResult<int>> PostCreate([FromBody] PedidoParametroDto pedidoParametroDto)
        {
            int id = await _pedidoService.Create(pedidoParametroDto);
            return Ok(id);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, [FromBody] PedidoParametroDto pedidoParametroDto)
        {
            pedidoParametroDto.Id = id;
            await _pedidoService.Update(pedidoParametroDto);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            await _pedidoService.Delete(id);
            return Ok();
        }

    }
}
