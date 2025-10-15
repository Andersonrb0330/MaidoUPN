using Application.Dtos.Request;
using Application.Dtos.Response;
using Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExperienciaController : ControllerBase
    {
        private readonly IExperienciaService _experienciaService;

        public ExperienciaController(
            IExperienciaService experienciaService
            )
        {
            _experienciaService = experienciaService;
        }

        [HttpGet]
        public async Task<ActionResult<List<ExperienciaDto>>> GetAll()
        {
            List<ExperienciaDto> experienciaDtos = await _experienciaService.GetAll();
            return experienciaDtos;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ExperienciaDto>> GetById(int id)
        {
            ExperienciaDto experienciaDto = await _experienciaService.GetById(id);
            return experienciaDto;
        }

        [HttpPost]
        public async Task<ActionResult<int>> PostCreate([FromBody] ExperienciaParametroDto experienciaParametroDto)
        {
            int id = await _experienciaService.Create(experienciaParametroDto);
            return Ok(id);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, [FromBody] ExperienciaParametroDto experienciaParametroDto)
        {
            experienciaParametroDto.Id = id;
            await _experienciaService.Update(experienciaParametroDto);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            await _experienciaService.Delete(id);
            return Ok();
        }

    }
}
