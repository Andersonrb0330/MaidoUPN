using Application.Dtos.Request;
using Application.Dtos.Response;
using Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/categoria")]
    [ApiController]
    public class CategoriaController : ControllerBase
    {
        private readonly ICategoriaService _categoriaService;

        public CategoriaController(
            ICategoriaService categoriaService
            )
        {
            _categoriaService = categoriaService;
        }

        [HttpGet]
        public async Task<ActionResult<List<CategoriaDto>>> GetAll()
        {
            List<CategoriaDto> categoriaDtos = await _categoriaService.GetAll();
            return categoriaDtos;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CategoriaDto>> GetById(int id)
        {
            CategoriaDto categoriaDto = await _categoriaService.GetById(id);
            return categoriaDto == null
                ? NotFound("No se encontro la categoria")
                : Ok(categoriaDto);
        }

        [HttpPost]
        public async Task<ActionResult<int>> PostCreate([FromBody] CategoriaParametroDto categoriaParametroDto)
        {
            int id = await _categoriaService.Create(categoriaParametroDto);
            return Ok(id);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, [FromBody] CategoriaParametroDto categoriaParametroDto)
        {
            categoriaParametroDto.Id = id;
            await _categoriaService.Update(categoriaParametroDto);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            await _categoriaService.Delete(id);
            return Ok();
        }

    }
}
