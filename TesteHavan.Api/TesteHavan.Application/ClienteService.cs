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
    public class ClienteService : IClienteService
    {
        private readonly IClienteRepo _clienteRepo;
        private readonly IMapper _mapper;

        public ClienteService(IMapper mapper,
            IClienteRepo clienteRepo)
        {
            _mapper = mapper;
            _clienteRepo = clienteRepo;
        }


        public async Task<ClienteDto> AddCliente(ClienteDto model)
        {
            try
            {
                var cliente = _mapper.Map<Cliente>(model);
                var clienteAdded = await _clienteRepo.SalvaClienteAsync(cliente);
                if (clienteAdded == null)
                {
                    return null;
                }
                else
                {
                    return _mapper.Map<ClienteDto>(cliente);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
