using Application.Dtos.Request;
using Application.Dtos.Response;
using Application.Interfaces;
using AutoMapper;
using Domain.Entity;
using Domain.IRepositories;

namespace Application.Implementations
{
    public class PedidoDetalleService : IPedidoDetalleService
    {
        private readonly IPedidoDetalleRepository _pedidoDetalleRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public PedidoDetalleService(
        IPedidoDetalleRepository pedidoDetalleRepository,
        IUnitOfWork unitOfWork,
        IMapper mapper)
        {
            _pedidoDetalleRepository = pedidoDetalleRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<List<PedidoDetalleDto>> GetAll()
        {
            List<PedidoDetalle> pedidoDetalles = await _pedidoDetalleRepository.GetAll();
            List<PedidoDetalleDto> pedidoDetalleDtos = _mapper.Map<List<PedidoDetalleDto>>(pedidoDetalles);
            return pedidoDetalleDtos;
        }

        public async Task<PedidoDetalleDto> GetById(int id)
        {
            PedidoDetalle pedidoDetalle = await _pedidoDetalleRepository.GetById(id);
            PedidoDetalleDto pedidoDetalleDto = _mapper.Map<PedidoDetalleDto>(pedidoDetalle);
            return pedidoDetalleDto;
        }

        public async Task<int> Create(PedidoDetalleParametroDto pedidoDetalleParametroDto)
        {
            PedidoDetalle pedidoDetalle = new PedidoDetalle
            {
                Cantidad = pedidoDetalleParametroDto.Cantidad,
                PrecioUnitario = pedidoDetalleParametroDto.PrecioUnitario,
                Comentarios = pedidoDetalleParametroDto.Comentarios,
                IdPedido = pedidoDetalleParametroDto.IdPedido,
            };

            await _pedidoDetalleRepository.Create(pedidoDetalle);
            await _unitOfWork.SaveChangesAsync();
            return pedidoDetalle.Id;
        }

        public async Task Update(PedidoDetalleParametroDto pedidoDetalleParametroDto)
        {
            PedidoDetalle pedidoDetalle = await _pedidoDetalleRepository.GetById(pedidoDetalleParametroDto.Id);
            if (pedidoDetalle == null)
            {
                throw new Exception($"No existe pedido detalle con este ID:{pedidoDetalleParametroDto.Id}");
            }

            pedidoDetalle.Cantidad = pedidoDetalleParametroDto.Cantidad;
            pedidoDetalle.PrecioUnitario = pedidoDetalleParametroDto.PrecioUnitario;
            pedidoDetalle.Comentarios = pedidoDetalleParametroDto.Comentarios;
            pedidoDetalle.IdPedido = pedidoDetalleParametroDto.IdPedido;
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            PedidoDetalle pedidoDetalle = await _pedidoDetalleRepository.GetById(id);
            if (pedidoDetalle == null)
            {
                throw new Exception($"No existe pedido detalle con este ID:{id}");
            }

            _pedidoDetalleRepository.Delete(pedidoDetalle);
            await _unitOfWork.SaveChangesAsync();
        }
    }
}
