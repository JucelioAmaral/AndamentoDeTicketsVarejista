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
    public class TicketSituacaoService : ITicketSituacaoService
    {
        private readonly IMapper _mapper;
        private readonly ITicketSituacaoRepo _ticketSitRepo;

        public TicketSituacaoService(IMapper mapper, ITicketSituacaoRepo ticketSitRepo)
        {
            _mapper = mapper;
            _ticketSitRepo = ticketSitRepo;
        }

        public async  Task<string> VerificaSitucaoDosTicketsDoCliente(int idTicketSituacao)
        {
            try
            {
                string status = await _ticketSitRepo.VerificaTicketSitucaoAsync(idTicketSituacao);
                return status;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }            
        }
    }
}