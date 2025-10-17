using Application.Dtos.Request;
using Application.Dtos.Response;
using Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/rol")]
    [ApiController]
    public class RolController : ControllerBase
    {
        private readonly IRolService _rolService;

        public RolController(
            IRolService rolService
            )
        {
            _rolService = rolService;
        }

        [HttpGet]
        public async Task<ActionResult<List<RolDto>>> GetAll()
        {
            List<RolDto> rolDtos = await _rolService.GetAll();
            return rolDtos;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<RolDto>> GetById(int id)
        {
            RolDto rolDto = await _rolService.GetById(id);
            return rolDto;
        }

        [HttpPost]
        public async Task<ActionResult<int>> PostCreate([FromBody] RolParametroDto rolParametroDto)
        {
            int id = await _rolService.Create(rolParametroDto);
            return Ok(id);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, [FromBody] RolParametroDto rolParametroDto)
        {
            rolParametroDto.Id = id;
            await _rolService.Update(rolParametroDto);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            await _rolService.Delete(id);
            return Ok();
        }

    }
}
