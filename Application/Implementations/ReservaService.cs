using Application.Dtos.Request;
using Application.Dtos.Response;
using Application.Interfaces;
using AutoMapper;
using Domain.Entity;
using Domain.IRepositories;

namespace Application.Implementations
{
    public class ReservaService : IReservaService
    {
        private readonly IReservaRepository _reservaRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ReservaService(
        IReservaRepository reservaRepository,
        IUnitOfWork unitOfWork,
        IMapper mapper)
        {
            _reservaRepository = reservaRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<List<ReservaDto>> GetAll()
        {
            List<Reserva> reservas = await _reservaRepository.GetAll();
            List<ReservaDto> reservaDtos = _mapper.Map<List<ReservaDto>>(reservas);
            return reservaDtos;
        }

        public async Task<ReservaDto> GetById(int id)
        {
            Reserva reserva = await _reservaRepository.GetById(id);
            ReservaDto reservaDto = _mapper.Map<ReservaDto>(reserva);
            return reservaDto;
        }

        public async Task<int> Create(ReservaParametroDto reservaParametroDto)
        {
            Reserva reserva = new Reserva
            {
                Fecha = reservaParametroDto.Fecha,
                Hora = reservaParametroDto.Hora,
                CantidadPersonas = reservaParametroDto.CantidadPersonas,
                Estado = reservaParametroDto.Estado,
                Notas = reservaParametroDto.Notas,
                CreatedAt = reservaParametroDto.CreatedAt,
                UpdatedAt = reservaParametroDto.UpdatedAt,
                IdCliente = reservaParametroDto.IdCliente,
            };

            await _reservaRepository.Create(reserva);
            await _unitOfWork.SaveChangesAsync();
            return reserva.Id;
        }

        public async Task Update(ReservaParametroDto reservaParametroDto)
        {
            Reserva reserva = await _reservaRepository.GetById(reservaParametroDto.Id);
            if (reserva == null)
            {
                throw new Exception($"No existe reserva con este ID:{reservaParametroDto.Id}");
            }

            reserva.Fecha = reservaParametroDto.Fecha;
            reserva.Hora = reservaParametroDto.Hora;
            reserva.CantidadPersonas = reservaParametroDto.CantidadPersonas;
            reserva.Estado = reservaParametroDto.Estado;
            reserva.Notas = reservaParametroDto.Notas;
            reserva.CreatedAt = reservaParametroDto.CreatedAt;
            reserva.UpdatedAt = reservaParametroDto.UpdatedAt;
            reserva.IdCliente = reservaParametroDto.IdCliente;

            await _unitOfWork.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            Reserva reserva = await _reservaRepository.GetById(id);
            if (reserva == null)
            {
                throw new Exception($"No existe reserva con este ID:{id}");
            }

            _reservaRepository.Delete(reserva);
            await _unitOfWork.SaveChangesAsync();
        }
    }
}
