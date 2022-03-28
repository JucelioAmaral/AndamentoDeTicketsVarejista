using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TesteHavan.Domain;

namespace TesteHavan.Infrastructure.Contracts
{
    public interface IClienteRepo
    {
        Task<Cliente>SalvaCliente(Cliente cliente);     
    }
}
