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
    public class TicketService : ITicketService
    {
        private readonly IMapper _mapper;
        private readonly ITicketRepo _ticketRepo;       
        

        public TicketService(IMapper mapper, ITicketRepo ticketRepo, ITicketSituacaoRepo ticketSitRepo)
        {
            _mapper = mapper;
            _ticketRepo = ticketRepo;            
        }

        public async Task<TicketDto> AdicionaTicket(TicketDto model)
        {
            try
            {
                var ticket = _mapper.Map<Ticket>(model);
                var clienteAdded = await _ticketRepo.AdicionaTicketAsync(ticket);
                if (clienteAdded == null)
                {
                    return null;
                }
                else
                {
                    return _mapper.Map<TicketDto>(clienteAdded);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<bool> ConcluiTicket(TicketDto model)
        {
            throw new NotImplementedException();
        }

    }
}