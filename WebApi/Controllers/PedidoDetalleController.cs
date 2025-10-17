using Application.Dtos.Request;
using Application.Dtos.Response;
using Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/pedido_detalle")]
    [ApiController]
    public class PedidoDetalleController : ControllerBase
    {
        private readonly IPedidoDetalleService _pedidoDetalleService;

        public PedidoDetalleController(
            IPedidoDetalleService pedidoDetalleService
            )
        {
            _pedidoDetalleService = pedidoDetalleService;
        }

        [HttpGet]
        public async Task<ActionResult<List<PedidoDetalleDto>>> GetAll()
        {
            List<PedidoDetalleDto> pedidoDetalleDtos = await _pedidoDetalleService.GetAll();
            return pedidoDetalleDtos;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<PedidoDetalleDto>> GetById(int id)
        {
            PedidoDetalleDto pedidoDetalleDto = await _pedidoDetalleService.GetById(id);
            return pedidoDetalleDto;
        }

        [HttpPost]
        public async Task<ActionResult<int>> PostCreate([FromBody] PedidoDetalleParametroDto pedidoDetalleParametroDto)
        {
            int id = await _pedidoDetalleService.Create(pedidoDetalleParametroDto);
            return Ok(id);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, [FromBody] PedidoDetalleParametroDto pedidoDetalleParametroDto)
        {
            pedidoDetalleParametroDto.Id = id;
            await _pedidoDetalleService.Update(pedidoDetalleParametroDto);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            await _pedidoDetalleService.Delete(id);
            return Ok();
        }

    }
}
