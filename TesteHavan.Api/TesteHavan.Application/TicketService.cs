using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TesteHavan.Application.Contracts;
using TesteHavan.Application.Dtos;
using TesteHavan.Infrastructure.Contracts;

namespace TesteHavan.Application
{
    public class TicketService : ITicketService
    {
        private readonly ITicketRepo _ticketRepo;

        public TicketService(ITicketRepo ticketRepo)
        {
            _ticketRepo = ticketRepo;
        }

        public async Task<string> VerificaSitucaoTicket(int idTicketSituacao)
        {
            string status = await _ticketRepo.VerificaSitucaoTicketDB(idTicketSituacao);
            return status;
        }
        Task<TicketDto> ITicketService.AdicionaTicket(TicketDto model)
        {
            throw new NotImplementedException();
        }

        Task<TicketDto> ITicketService.AtualizaTicket(TicketDto model)
        {
            throw new NotImplementedException();
        }

        Task<bool> ITicketService.ConcluiTicket(TicketDto model)
        {
            throw new NotImplementedException();
        }

    }
}