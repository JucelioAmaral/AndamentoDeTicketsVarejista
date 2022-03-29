using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TesteHavan.Application.Dtos;
using TesteHavan.Domain;

namespace TesteHavan.Application.Contracts
{
    public interface ITicketService
    {     
        Task<TicketDto> AdicionaTicket(TicketDto model);        
        Task<bool> ConcluiTicketSitucaoDoCliente(Ticket ticket);
        Task<Ticket> GetTicket(int idTicket);        
    }
}
