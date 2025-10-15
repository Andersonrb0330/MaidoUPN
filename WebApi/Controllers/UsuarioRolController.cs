using Application.Dtos.Request;
using Application.Dtos.Response;
using Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioRolController : ControllerBase
    {
        private readonly IUsuarioRolService _usuarioRolService;

        public UsuarioRolController(
            IUsuarioRolService usuarioRolService
            )
        {
            _usuarioRolService = usuarioRolService;
        }

        [HttpGet]
        public async Task<ActionResult<List<UsuarioRolDto>>> GetAll()
        {
            List<UsuarioRolDto> usuarioRolDtos = await _usuarioRolService.GetAll();
            return usuarioRolDtos;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<UsuarioRolDto>> GetById(int id)
        {
            UsuarioRolDto usuarioRolDto = await _usuarioRolService.GetById(id);
            return usuarioRolDto;
        }

        [HttpPost]
        public async Task<ActionResult<int>> PostCreate([FromBody] UsuarioRolParametroDto usuarioRolParametroDto)
        {
            int id = await _usuarioRolService.Create(usuarioRolParametroDto);
            return Ok(id);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, [FromBody] UsuarioRolParametroDto usuarioRolParametroDto)
        {
            usuarioRolParametroDto.Id = id;
            await _usuarioRolService.Update(usuarioRolParametroDto);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            await _usuarioRolService.Delete(id);
            return Ok();
        }

    }
}
