using Application.Dtos.Request;
using Application.Dtos.Response;
using Application.Interfaces;
using AutoMapper;
using Domain.Entity;
using Domain.IRepositories;

namespace Application.Implementations
{
    public class HistorialClienteService : IHistorialClienteService
    {
        private readonly IHistoriaClienteRepository _historiaClienteRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public HistorialClienteService(
        IHistoriaClienteRepository historiaClienteRepository,
        IUnitOfWork unitOfWork,
        IMapper mapper)
        {
            _historiaClienteRepository = historiaClienteRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<List<HistorialClienteDto>> GetAll()
        {
            List<HistorialCliente> historialClientes = await _historiaClienteRepository.GetAll();
            List<HistorialClienteDto> historialClienteDtos = _mapper.Map<List<HistorialClienteDto>>(historialClientes);
            return historialClienteDtos;
        }

        public async Task<HistorialClienteDto> GetById(int id)
        {
            HistorialCliente historialCliente = await _historiaClienteRepository.GetById(id);
            HistorialClienteDto historialClienteDto = _mapper.Map<HistorialClienteDto>(historialCliente);
            return historialClienteDto;
        }

        public async Task<int> Create(HistorialClienteParametroDto historialClienteParametroDto)
        {
            HistorialCliente historialCliente = new HistorialCliente
            {
                FechaVisita = historialClienteParametroDto.FechaVisita,
                Observaciones = historialClienteParametroDto.Observaciones,
                IdCliente = historialClienteParametroDto.IdCliente,
            };

            await _historiaClienteRepository.Create(historialCliente);
            await _unitOfWork.SaveChangesAsync();
            return historialCliente.Id;
        }

        public async Task Update(HistorialClienteParametroDto historialClienteParametroDto)
        {
            HistorialCliente historialCliente = await _historiaClienteRepository.GetById(historialClienteParametroDto.Id);
            if (historialCliente == null)
            {
                throw new Exception($"No existe historil cliente con este ID:{historialClienteParametroDto.Id}");
            }

            historialCliente.FechaVisita = historialClienteParametroDto.FechaVisita;
            historialCliente.Observaciones = historialClienteParametroDto.Observaciones;
            historialCliente.IdCliente = historialClienteParametroDto.IdCliente;
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            HistorialCliente historialCliente = await _historiaClienteRepository.GetById(id);
            if (historialCliente == null)
            {
                throw new Exception($"No existe historil cliente con este ID:{id}");
            }

            _historiaClienteRepository.Delete(historialCliente);
            await _unitOfWork.SaveChangesAsync();
        }
    }
}
