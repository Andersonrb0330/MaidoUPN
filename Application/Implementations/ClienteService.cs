using Application.Dtos.Request;
using Application.Dtos.Response;
using Application.Interfaces;
using AutoMapper;
using Domain.Entity;
using Domain.IRepositories;

namespace Application.Implementations
{
    public class ClienteService : IClienteService
    {
        private readonly IClienteRespoitory _clienteRespoitory;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ClienteService(
        IClienteRespoitory clienteRespoitory,
        IUnitOfWork unitOfWork,
        IMapper mapper)
        {
            _clienteRespoitory = clienteRespoitory;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<List<ClienteDto>> GetAll()
        {
            List<Cliente> clientes = await _clienteRespoitory.GetAll();
            List<ClienteDto> clienteDtos = _mapper.Map<List<ClienteDto>>(clientes);
            return clienteDtos;
        }

        public async Task<ClienteDto> GetById(int id)
        {
            Cliente cliente = await _clienteRespoitory.GetById(id);
            ClienteDto clienteDto = _mapper.Map<ClienteDto>(cliente);
            return clienteDto;
        }

        public async Task<int> Create(ClienteParametroDto clienteParametroDto)
        {
            Cliente cliente = new Cliente
            {
                Nombre = clienteParametroDto.Nombre,
                ApellidoPaterno = clienteParametroDto.ApellidoPaterno,
                ApellidoMaterno = clienteParametroDto.ApellidoMaterno,
                Email = clienteParametroDto.Email,
                Telefono = clienteParametroDto.Telefono,
                Alergias = clienteParametroDto.Alergias,
                Preferencias = clienteParametroDto.Preferencias,
                FechaNacimiento = clienteParametroDto.FechaNacimiento,
                FechaRegistro = clienteParametroDto.FechaRegistro,
            };

            await _clienteRespoitory.Create(cliente);
            await _unitOfWork.SaveChangesAsync();
            return cliente.Id;
        }

        public async Task Update(ClienteParametroDto clienteParametroDto)
        {
            Cliente cliente = await _clienteRespoitory.GetById(clienteParametroDto.Id);
            if (cliente == null)
            {
                throw new Exception($"No existe cliente con este ID:{clienteParametroDto.Id}");
            }

            cliente.Nombre = clienteParametroDto.Nombre;
            cliente.ApellidoPaterno = clienteParametroDto.ApellidoPaterno;
            cliente.ApellidoMaterno = clienteParametroDto.ApellidoMaterno;
            cliente.Email = clienteParametroDto.Email;
            cliente.Telefono = clienteParametroDto.Telefono;
            cliente.Alergias = clienteParametroDto.Alergias;
            cliente.Preferencias = clienteParametroDto.Preferencias;
            cliente.FechaNacimiento = clienteParametroDto.FechaNacimiento;
            cliente.FechaRegistro = clienteParametroDto.FechaRegistro;

            await _unitOfWork.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            Cliente cliente = await _clienteRespoitory.GetById(id);
            if (cliente == null)
            {
                throw new Exception($"No existe cliente con este ID:{id}");
            }

            _clienteRespoitory.Delete(cliente);
            await _unitOfWork.SaveChangesAsync();
        }
    }
}
