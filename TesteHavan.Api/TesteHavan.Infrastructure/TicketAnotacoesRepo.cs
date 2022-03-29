using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TesteHavan.Domain;
using TesteHavan.Infrastructure.Context;
using TesteHavan.Infrastructure.Contracts;

namespace TesteHavan.Infrastructure
{
    public class TicketAnotacoesRepo : ITicketAnotacoesRepo
    {
        private readonly TesteHavanContext _context;

        public TicketAnotacoesRepo(TesteHavanContext context)
        {
            _context = context;
        }

        public async Task<TicketAnotacao> SalvaAnotacoesAsync(TicketAnotacao ticketComAnotacoes)
        {
            using (var conn = _context.Connection)
            {
                string command = @"INSERT INTO TicketAnotacao(IdTicket, IdUsuario, Texto, Data) VALUES(@IdTicket, @IdUsuario, @Texto, @Data)";

                var result = await conn.ExecuteAsync(sql: command, param: ticketComAnotacoes);
                if (result > 0)
                {
                    return ticketComAnotacoes;
                }
                return null;
            }
        }
    }
}
