using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TesteHavan.Application.Contracts
{
    public interface ITicketSituacaoService
    {        
        Task<string> VerificaSitucaoDosTicketsDoCliente(int idTicketSituacao);
    }
}
