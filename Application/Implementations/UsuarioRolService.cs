using Application.Dtos.Request;
using Application.Dtos.Response;
using Application.Interfaces;
using AutoMapper;
using Domain.Entity;
using Domain.IRepositories;

namespace Application.Implementations
{
    public class UsuarioRolService : IUsuarioRolService
    {
        private readonly IUsuarioRolRepository _usuarioRolRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UsuarioRolService(
        IUsuarioRolRepository usuarioRolRepository,
        IUnitOfWork unitOfWork,
        IMapper mapper)
        {
            _usuarioRolRepository = usuarioRolRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<List<UsuarioRolDto>> GetAll()
        {
            List<UsuarioRol> usuarioRols = await _usuarioRolRepository.GetAll();
            List<UsuarioRolDto> usuarioRolDtos = _mapper.Map<List<UsuarioRolDto>>(usuarioRols);
            return usuarioRolDtos;
        }

        public async Task<UsuarioRolDto> GetById(int id)
        {
            UsuarioRol usuarioRol = await _usuarioRolRepository.GetById(id);
            UsuarioRolDto usuarioRolDto = _mapper.Map<UsuarioRolDto>(usuarioRol);
            return usuarioRolDto;
        }

        public async Task<int> Create(UsuarioRolParametroDto usuarioRolParametroDto)
        {
            UsuarioRol usuarioRol = new UsuarioRol
            {
                IdUsuario = usuarioRolParametroDto.IdUsuario,
                IdRol = usuarioRolParametroDto.IdRol,
            };

            await _usuarioRolRepository.Create(usuarioRol);
            await _unitOfWork.SaveChangesAsync();
            return usuarioRol.Id;
        }

        public async Task Update(UsuarioRolParametroDto usuarioRolParametroDto)
        {
            UsuarioRol usuarioRol = await _usuarioRolRepository.GetById(usuarioRolParametroDto.Id);
            if (usuarioRol == null)
            {
                throw new Exception($"No existe usuario rol con este ID:{usuarioRolParametroDto.Id}");
            }

            usuarioRol.IdUsuario = usuarioRolParametroDto.IdUsuario;
            usuarioRol.IdRol = usuarioRolParametroDto.IdRol;
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            UsuarioRol usuarioRol = await _usuarioRolRepository.GetById(id);
            if (usuarioRol == null)
            {
                throw new Exception($"No existe usuario rol con este ID:{id}");
            }

            _usuarioRolRepository.Delete(usuarioRol);
            await _unitOfWork.SaveChangesAsync();
        }
    }
}
