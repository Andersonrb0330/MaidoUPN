using Application.Dtos.Request;
using Application.Dtos.Response;
using Application.Interfaces;
using AutoMapper;
using Domain.Entity;
using Domain.IRepositories;

namespace Application.Implementations
{
    public class PedidoService : IPedidoService
    {
        private readonly IPedidoRepository _pedidoRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public PedidoService(
        IPedidoRepository pedidoRepository,
        IUnitOfWork unitOfWork,
        IMapper mapper)
        {
            _pedidoRepository = pedidoRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<List<PedidoDto>> GetAll()
        {
            List<Pedido> pedidos = await _pedidoRepository.GetAll();
            List<PedidoDto> pedidoDtos = _mapper.Map<List<PedidoDto>>(pedidos);
            return pedidoDtos;
        }

        public async Task<PedidoDto> GetById(int id)
        {
            Pedido pedidos = await _pedidoRepository.GetById(id);
            PedidoDto pedidoDtos = _mapper.Map<PedidoDto>(pedidos);
            return pedidoDtos;
        }

        public async Task<int> Create(PedidoParametroDto pedidoParametroDto)
        {
            Pedido Pedido = new Pedido
            {
                Fecha = pedidoParametroDto.Fecha,
                Estado = pedidoParametroDto.Estado,
                IdReserva = pedidoParametroDto.IdReserva,
                IdCliente = pedidoParametroDto.IdCliente,
            };

            await _pedidoRepository.Create(Pedido);
            await _unitOfWork.SaveChangesAsync();
            return Pedido.Id;
        }

        public async Task Update(PedidoParametroDto pedidoParametroDto)
        {
            Pedido pedido = await _pedidoRepository.GetById(pedidoParametroDto.Id);
            if (pedido == null)
            {
                throw new Exception($"No existe pedido con este ID:{pedidoParametroDto.Id}");
            }

            pedido.Fecha = pedidoParametroDto.Fecha;
            pedido.Estado = pedidoParametroDto.Estado;
            pedido.IdReserva = pedidoParametroDto.IdReserva;
            pedido.IdCliente = pedidoParametroDto.IdCliente;
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            Pedido pedido = await _pedidoRepository.GetById(id);
            if (pedido == null)
            {
                throw new Exception($"No existe pedido con este ID:{id}");
            }

            _pedidoRepository.Delete(pedido);
            await _unitOfWork.SaveChangesAsync();
        }
    }
}
