using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TesteHavan.Application.Dtos;
using TesteHavan.Domain;

namespace TesteHavan.Application.Contracts
{
    public interface IViewBDService
    {
        Task<ClsView> GetValoresViewBD(int CodigoDoTicket, string NomeDoUsuario, string CPF);
    }
}
