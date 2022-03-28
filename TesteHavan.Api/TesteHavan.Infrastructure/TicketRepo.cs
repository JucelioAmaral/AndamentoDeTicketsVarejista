

using Dapper;
using System.Threading.Tasks;
using TesteHavan.Domain;
using TesteHavan.Infrastructure.Context;
using TesteHavan.Infrastructure.Contracts;

namespace TesteHavan.Infrastructure
{
    public class TicketRepo : ITicketRepo
    {
        private readonly TesteHavanContext _context;

        public TicketRepo(TesteHavanContext context)
        {
            _context = context;
        }

        public async Task<string> VerificaSitucaoTicketDB(int idTicketSituacao)
        {
            using (var conn = _context.Connection)
            {
                string query = @"SELECT * FROM TicketSituacao WHERE Id = @idTicketSituacao";
                TicketSituacao ticketSituacao = await conn.QueryFirstOrDefaultAsync<TicketSituacao>
                    (sql: query, param: new { idTicketSituacao });
                return ticketSituacao.Nome;
            }
        }
    }
}
