using Application.Dtos.Request;
using Application.Dtos.Response;
using Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/cliente")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        private readonly IClienteService _clienteService;

        public ClienteController(
            IClienteService clienteService
            )
        {
            _clienteService = clienteService;
        }

        [HttpGet]
        public async Task<ActionResult<List<ClienteDto>>> GetAll()
        {
            List<ClienteDto> clienteDtos = await _clienteService.GetAll();
            return clienteDtos;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ClienteDto>> GetById(int id)
        {
            ClienteDto clienteDto = await _clienteService.GetById(id);
            return clienteDto;
        }

        [HttpPost]
        public async Task<ActionResult<int>> PostCreate([FromBody] ClienteParametroDto clienteParametroDto)
        {
            int id = await _clienteService.Create(clienteParametroDto);
            return Ok(id);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, [FromBody] ClienteParametroDto clienteParametroDto)
        {
            clienteParametroDto.Id = id;
            await _clienteService.Update(clienteParametroDto);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            await _clienteService.Delete(id);
            return Ok();
        }

    }
}