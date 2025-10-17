using Application.Dtos.Request;
using Application.Dtos.Response;
using Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/usuario")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioService _usuarioService;

        public UsuarioController(
            IUsuarioService usuarioService
            )
        {
            _usuarioService = usuarioService;
        }

        [HttpGet]
        public async Task<ActionResult<List<UsuarioDto>>> GetAll()
        {
            List<UsuarioDto> usuarioDtos = await _usuarioService.GetAll();
            return usuarioDtos;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<UsuarioDto>> GetById(int id)
        {
            UsuarioDto usuarioDto = await _usuarioService.GetById(id);
            return usuarioDto;
        }

        [HttpPost]
        public async Task<ActionResult<int>> PostCreate([FromBody] UsuarioParametroDto usuarioParametroDto)
        {
            int id = await _usuarioService.Create(usuarioParametroDto);
            return Ok(id);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, [FromBody] UsuarioParametroDto usuarioParametroDto)
        {
            usuarioParametroDto.Id = id;
            await _usuarioService.Update(usuarioParametroDto);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            await _usuarioService.Delete(id);
            return Ok();
        }

    }
}
