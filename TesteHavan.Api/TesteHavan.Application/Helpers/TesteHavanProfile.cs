using AutoMapper;
using System;
using TesteHavan.Application.Dtos;
using TesteHavan.Domain;

namespace TesteHavan.Application
{
    public class TesteHavanProfile : Profile
    {
        public TesteHavanProfile()
        {

            CreateMap<Usuario, UsuarioDto>().ReverseMap();
            CreateMap<Cliente, ClienteDto>().ReverseMap();
            CreateMap<Ticket, TicketDto>().ReverseMap();
        }
    }
}
