using Application.Dtos.Request;
using Application.Dtos.Response;
using Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/historia_cliente")]
    [ApiController]
    public class HistoriaClienteController : ControllerBase
    {
        private readonly IHistorialClienteService _historialClienteService;

        public HistoriaClienteController(
            IHistorialClienteService historialClienteService
            )
        {
            _historialClienteService = historialClienteService;
        }

        [HttpGet]
        public async Task<ActionResult<List<HistorialClienteDto>>> GetAll()
        {
            List<HistorialClienteDto> historialClienteDtos = await _historialClienteService.GetAll();
            return historialClienteDtos;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<HistorialClienteDto>> GetById(int id)
        {
            HistorialClienteDto historialClienteDto = await _historialClienteService.GetById(id);
            return historialClienteDto;
        }

        [HttpPost]
        public async Task<ActionResult<int>> PostCreate([FromBody] HistorialClienteParametroDto historialClienteParametroDto)
        {
            int id = await _historialClienteService.Create(historialClienteParametroDto);
            return Ok(id);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, [FromBody] HistorialClienteParametroDto historialClienteParametroDto)
        {
            historialClienteParametroDto.Id = id;
            await _historialClienteService.Update(historialClienteParametroDto);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            await _historialClienteService.Delete(id);
            return Ok();
        }

    }
}

