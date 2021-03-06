using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TesteHavan.Domain;

namespace TesteHavan.Infrastructure.Contracts
{
    public interface ITicketRepo
    {        
        Task<Ticket> AdicionaTicketAsync(Ticket ticket);
        Task<int> AtualizaTicketSitucaoAsync(Ticket ticket);
        Task<Ticket> GetTicketAsync(int idTicket);
    }
}
