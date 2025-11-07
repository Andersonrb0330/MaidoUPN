using Application.Dtos.Request;
using Application.Dtos.Response;
using Application.Interfaces;
using AutoMapper;
using Domain.Entity;
using Domain.IRepositories;

namespace Application.Implementations
{
    public class MesaService : IMesaService
    {
        private readonly IMesaRepository _mesaRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public MesaService(
        IMesaRepository mesaRepository,
        IUnitOfWork unitOfWork,
        IMapper mapper)
        {
            _mesaRepository = mesaRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<List<MesaDto>> GetAll()
        {
            List<Mesa> mesas = await _mesaRepository.GetAll();
            List<MesaDto> mesaDtos = _mapper.Map<List<MesaDto>>(mesas);
            return mesaDtos;
        }

        public async Task<MesaDto> GetById(int id)
        {
            Mesa mesa = await _mesaRepository.GetById(id);
            MesaDto mesaDto = _mapper.Map<MesaDto>(mesa);
            return mesaDto;
        }

        public async Task<int> Create(MesaParametroDto mesaParametroDto)
        {
            Mesa mesa = new Mesa
            {
                Numero = mesaParametroDto.Numero,
                Capacidad = mesaParametroDto.Capacidad,
                Ubicacion = mesaParametroDto.Ubicacion,
                Estado = mesaParametroDto.Estado,
                Piso = mesaParametroDto.Piso,
            };

            await _mesaRepository.Create(mesa);
            await _unitOfWork.SaveChangesAsync();
            return mesa.Id;
        }

        public async Task Update(MesaParametroDto mesaParametroDto)
        {
            Mesa mesa = await _mesaRepository.GetById(mesaParametroDto.Id);
            if (mesa == null)
            {
                throw new Exception($"No existe mesa con este ID:{mesaParametroDto.Id}");
            }

            mesa.Numero = mesaParametroDto.Numero;
            mesa.Capacidad = mesaParametroDto.Capacidad;
            mesa.Ubicacion = mesaParametroDto.Ubicacion;
            mesa.Estado = mesaParametroDto.Estado;
            mesa.Piso = mesaParametroDto.Piso;

            await _unitOfWork.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            Mesa mesa = await _mesaRepository.GetById(id);
            if (mesa == null)
            {
                throw new Exception($"No existe mesa con este ID:{id}");
            }

            _mesaRepository.Delete(mesa);
            await _unitOfWork.SaveChangesAsync();
        }
    }
}
