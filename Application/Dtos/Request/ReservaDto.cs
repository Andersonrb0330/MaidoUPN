﻿using AutoMapper;
using Domain.Entity;

namespace Application.Dtos.Request
{
    public class ReservaDto
    {
        public int Id { get; set; }
        public DateTime Fecha { get; set; }
        public TimeSpan Hora { get; set; }
        public int CantidadPersonas { get; set; }
        public string Estado { get; set; }
        public string Notas { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        public int IdCliente { get; set; }
        public ClienteDto Cliente { get; set; }
    }

    public class ReservaProfile : Profile
    {
        public ReservaProfile()
        {
            CreateMap<Reserva, ReservaDto>();
        }
    }
}
