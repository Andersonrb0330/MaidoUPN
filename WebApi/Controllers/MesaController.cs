using Application.Dtos.Request;
using Application.Dtos.Response;
using Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MesaController : ControllerBase
    {
        private readonly IMesaService _mesaService;

        public MesaController(
            IMesaService mesaService
            )
        {
            _mesaService = mesaService;
        }

        [HttpGet]
        public async Task<ActionResult<List<MesaDto>>> GetAll()
        {
            List<MesaDto> mesaDtos = await _mesaService.GetAll();
            return mesaDtos;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<MesaDto>> GetById(int id)
        {
            MesaDto mesaDto = await _mesaService.GetById(id);
            return mesaDto;
        }

        [HttpPost]
        public async Task<ActionResult<int>> PostCreate([FromBody] MesaParametroDto mesaParametroDto)
        {
            int id = await _mesaService.Create(mesaParametroDto);
            return Ok(id);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, [FromBody] MesaParametroDto mesaParametroDto)
        {
            mesaParametroDto.Id = id;
            await _mesaService.Update(mesaParametroDto);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            await _mesaService.Delete(id);
            return Ok();
        }

    }
}
