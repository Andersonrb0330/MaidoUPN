using Application.Dtos.Request;
using Application.Dtos.Response;
using Application.Interfaces;
using AutoMapper;
using Domain.Entity;
using Domain.IRepositories;

namespace Application.Implementations
{
    public class ReservaMesaService : IReservaMesaService
    {
        private readonly IReservaMesaRepositoy _reservaMesaRepositoy;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ReservaMesaService(
        IReservaMesaRepositoy reservaMesaRepositoy,
        IUnitOfWork unitOfWork,
        IMapper mapper)
        {
            _reservaMesaRepositoy = reservaMesaRepositoy;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<List<ReservaMesaDto>> GetAll()
        {
            List<ReservaMesa> reservaMesas = await _reservaMesaRepositoy.GetAll();
            List<ReservaMesaDto> reservaMesaDtos = _mapper.Map<List<ReservaMesaDto>>(reservaMesas);
            return reservaMesaDtos;
        }

        public async Task<ReservaMesaDto> GetById(int id)
        {
            ReservaMesa reservaMesa = await _reservaMesaRepositoy.GetById(id);
            ReservaMesaDto reservaMesaDto = _mapper.Map<ReservaMesaDto>(reservaMesa);
            return reservaMesaDto;
        }

        public async Task<int> Create(ReservaMesaParametroDto reservaMesaParametroDto)
        {
            ReservaMesa reservaMesa = new ReservaMesa
            {
                IdReserva = reservaMesaParametroDto.IdReserva,
                IdMesa = reservaMesaParametroDto.IdMesa,
            };

            await _reservaMesaRepositoy.Create(reservaMesa);
            await _unitOfWork.SaveChangesAsync();
            return reservaMesa.Id;
        }

        public async Task Update(ReservaMesaParametroDto reservaMesaParametroDto)
        {
            ReservaMesa reservaMesa = await _reservaMesaRepositoy.GetById(reservaMesaParametroDto.Id);
            if (reservaMesa == null)
            {
                throw new Exception($"No existe reserva mesa con este ID:{reservaMesaParametroDto.Id}");
            }

            reservaMesa.IdReserva = reservaMesaParametroDto.IdReserva;
            reservaMesa.IdMesa = reservaMesaParametroDto.IdMesa;
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            ReservaMesa reservaMesa = await _reservaMesaRepositoy.GetById(id);
            if (reservaMesa == null)
            {
                throw new Exception($"No existe reserva mesa con este ID:{id}");
            }

            _reservaMesaRepositoy.Delete(reservaMesa);
            await _unitOfWork.SaveChangesAsync();
        }
    }
}
