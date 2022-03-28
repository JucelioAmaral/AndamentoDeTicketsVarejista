using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TesteHavan.Infrastructure.Contracts
{
    public interface ITicketRepo
    {
        Task<string> VerificaSitucaoTicketDB(int idTicketSituacao);
    }
}
