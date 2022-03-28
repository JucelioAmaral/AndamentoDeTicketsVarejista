using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TesteHavan.Application.Contracts;
using TesteHavan.Application.Dtos;
using TesteHavan.Domain;
using TesteHavan.Infrastructure.Contracts;

namespace TesteHavan.Application
{
    public class UsuarioService : IUsuarioService
    {

        private readonly IUsuarioRepo _usuarioRepo;
        private readonly IMapper _mapper;

        public UsuarioService(IUsuarioRepo geralRepo, IMapper mapper)
        {
            _mapper = mapper;
            _usuarioRepo = geralRepo;
        }

        public async Task<UsuarioDto> AddUsuario(UsuarioDto model)
        {
            try
            {
                var usuario = _mapper.Map<Usuario>(model);
                var usuarioAdded = await _usuarioRepo.SalvaUsuario(usuario);
                if (usuarioAdded == null)
                {
                    return null;
                }
                else
                {
                    return _mapper.Map<UsuarioDto>(usuario);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
