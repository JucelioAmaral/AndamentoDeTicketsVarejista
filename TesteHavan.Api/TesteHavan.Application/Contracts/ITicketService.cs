using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TesteHavan.Application.Dtos;

namespace TesteHavan.Application.Contracts
{
    public interface ITicketService
    {        
        Task<string> VerificaSitucaoTicket(int idTicketSituacao);
        Task<TicketDto> AdicionaTicket(TicketDto model);
        Task<TicketDto> AtualizaTicket(TicketDto model);
        Task<bool> ConcluiTicket(TicketDto model);
    }
}
