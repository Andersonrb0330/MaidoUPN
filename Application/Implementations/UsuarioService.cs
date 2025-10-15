using Application.Dtos.Request;
using Application.Dtos.Response;
using Application.Interfaces;
using AutoMapper;
using Domain.Entity;
using Domain.IRepositories;

namespace Application.Implementations
{
    public class UsuarioService : IUsuarioService
    {
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UsuarioService(
        IUsuarioRepository usuarioRepository,
        IUnitOfWork unitOfWork,
        IMapper mapper)
        {
            _usuarioRepository = usuarioRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<List<UsuarioDto>> GetAll()
        {
            List<Usuario> usuarios = await _usuarioRepository.GetAll();
            List<UsuarioDto> usuarioDtos = _mapper.Map<List<UsuarioDto>>(usuarios);
            return usuarioDtos;
        }

        public async Task<UsuarioDto> GetById(int id)
        {
            Usuario rol = await _usuarioRepository.GetById(id);
            UsuarioDto rolDto = _mapper.Map<UsuarioDto>(rol);
            return rolDto;
        }

        public async Task<int> Create(UsuarioParametroDto usuarioParametroDto)
        {
            Usuario usuario = new Usuario
            {
                Username = usuarioParametroDto.Username,
                Email = usuarioParametroDto.Email,
                Password = usuarioParametroDto.Password,
                Estado = usuarioParametroDto.Estado,
                CreadoEn = usuarioParametroDto.CreadoEn,
            };

            await _usuarioRepository.Create(usuario);
            await _unitOfWork.SaveChangesAsync();
            return usuario.Id;
        }

        public async Task Update(UsuarioParametroDto usuarioParametroDto)
        {
            Usuario usuario = await _usuarioRepository.GetById(usuarioParametroDto.Id);
            if (usuario == null)
            {
                throw new Exception($"No existe rol con este ID:{usuarioParametroDto.Id}");
            }

            usuario.Username = usuarioParametroDto.Username;
            usuario.Email = usuarioParametroDto.Email;
            usuario.Password = usuarioParametroDto.Password;
            usuario.Estado = usuarioParametroDto.Estado;
            usuario.CreadoEn = usuarioParametroDto.CreadoEn;

            await _unitOfWork.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            Usuario usuario = await _usuarioRepository.GetById(id);
            if (usuario == null)
            {
                throw new Exception($"No existe rol con este ID:{id}");
            }

            _usuarioRepository.Delete(usuario);
            await _unitOfWork.SaveChangesAsync();
        }
    }
}
