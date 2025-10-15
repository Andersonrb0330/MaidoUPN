using Application.Dtos.Request;
using Application.Dtos.Response;
using Application.Interfaces;
using AutoMapper;
using Domain.Entity;
using Domain.IRepositories;

namespace Application.Implementations
{
    public class CategoriaService : ICategoriaService
    {
        private readonly ICategoriaRepository _categoriaRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CategoriaService(
        ICategoriaRepository categoriaRepository,
        IUnitOfWork unitOfWork,
        IMapper mapper)
        {
            _categoriaRepository = categoriaRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<List<CategoriaDto>> GetAll()
        {
            List<Categoria> categorias = await _categoriaRepository.GetAll();
            List<CategoriaDto> categoriaDtos = _mapper.Map<List<CategoriaDto>>(categorias);
            return categoriaDtos;
        }

        public async Task<CategoriaDto> GetById(int id)
        {
            Categoria categoria = await _categoriaRepository.GetById(id);
            CategoriaDto categoriaDto = _mapper.Map<CategoriaDto>(categoria);
            return categoriaDto;
        }

        public async Task<int> Create(CategoriaParametroDto categoriaParametroDto)
        {
            Categoria categoria = new Categoria
            {
                Nombre = categoriaParametroDto.Nombre,
                Descripcion = categoriaParametroDto.Descripcion
            };

            await _categoriaRepository.Create(categoria);
            await _unitOfWork.SaveChangesAsync();
            return categoria.Id;
        }

        public async Task Update(CategoriaParametroDto categoriaParametroDto)
        {
            Categoria categoria = await _categoriaRepository.GetById(categoriaParametroDto.Id);
            if (categoria == null)
            {
                throw new Exception($"No existe categoria con este ID:{categoriaParametroDto.Id}");
            }

            categoria.Nombre = categoriaParametroDto.Nombre;
            categoria.Descripcion = categoriaParametroDto.Descripcion;

            await _unitOfWork.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            Categoria categoria = await _categoriaRepository.GetById(id);
            if (categoria == null)
            {
                throw new Exception($"No existe categoria con este ID:{id}");
            }

            _categoriaRepository.Delete(categoria);
            await _unitOfWork.SaveChangesAsync();
        }
    }
}
