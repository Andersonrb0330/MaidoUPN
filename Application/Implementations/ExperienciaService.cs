using Application.Dtos.Request;
using Application.Dtos.Response;
using Application.Interfaces;
using AutoMapper;
using Domain.Entity;
using Domain.IRepositories;

namespace Application.Implementations
{
    public class ExperienciaService : IExperienciaService
    {
        private readonly IExperienciaRepository _experienciaRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ExperienciaService(
        IExperienciaRepository experienciaRepository,
        IUnitOfWork unitOfWork,
        IMapper mapper)
        {
            _experienciaRepository = experienciaRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<List<ExperienciaDto>> GetAll()
        {
            List<Experiencia> experiencias = await _experienciaRepository.GetAll();
            List<ExperienciaDto> experienciaDtos = _mapper.Map<List<ExperienciaDto>>(experiencias);
            return experienciaDtos;
        }

        public async Task<ExperienciaDto> GetById(int id)
        {
            Experiencia experiencia = await _experienciaRepository.GetById(id);
            ExperienciaDto experienciaDto = _mapper.Map<ExperienciaDto>(experiencia);
            return experienciaDto;
        }

        public async Task<int> Create(ExperienciaParametroDto experienciaParametroDto)
        {
            Experiencia experiencia = new Experiencia
            {
                Nombre = experienciaParametroDto.Nombre,
                Descripcion = experienciaParametroDto.Descripcion,
                Precio = experienciaParametroDto.Precio,
                Disponible = experienciaParametroDto.Disponible,
                IdCategoria = experienciaParametroDto.IdCategoria
            };

            await _experienciaRepository.Create(experiencia);
            await _unitOfWork.SaveChangesAsync();
            return experiencia.Id;
        }

        public async Task Update(ExperienciaParametroDto experienciaParametroDto)
        {
            Experiencia experiencia = await _experienciaRepository.GetById(experienciaParametroDto.Id);
            if (experiencia == null)
            {
                throw new Exception($"No existe experiencia con este ID:{experienciaParametroDto.Id}");
            }

            experiencia.Nombre = experienciaParametroDto.Nombre;
            experiencia.Descripcion = experienciaParametroDto.Descripcion;
            experiencia.Precio = experienciaParametroDto.Precio;
            experiencia.Disponible = experienciaParametroDto.Disponible;
            experiencia.IdCategoria = experienciaParametroDto.IdCategoria;

            await _unitOfWork.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            Experiencia experiencia = await _experienciaRepository.GetById(id);
            if (experiencia == null)
            {
                throw new Exception($"No existe experiencia con este ID:{id}");
            }

            _experienciaRepository.Delete(experiencia);
            await _unitOfWork.SaveChangesAsync();
        }

    }
}
