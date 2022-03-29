using Dapper;
using System.Data;
using System.Threading.Tasks;
using TesteHavan.Domain;
using TesteHavan.Infrastructure.Context;
using TesteHavan.Infrastructure.Contracts;

namespace TesteHavan.Infrastructure
{
    public class TicketSituacaoRepo : ITicketSituacaoRepo
    {
        private readonly TesteHavanContext _context;

        public TicketSituacaoRepo(TesteHavanContext context)
        {
            _context = context;
        }

        public async Task<string> VerificaTicketSitucaoAsync(int idTicketSituacao)
        {
            IDbConnection conn = _context.GetConnection();

            using (conn)
            {
                conn.Open();
                string query = @"SELECT * FROM TicketSituacao WHERE Id = @idTicketSituacao";
                TicketSituacao ticketSituacao = await conn.QueryFirstOrDefaultAsync<TicketSituacao>
                    (sql: query, param: new { idTicketSituacao });

                if (ticketSituacao == null)
                {
                    conn.Close();
                    return "Sem status";
                }
                conn.Close();
                return ticketSituacao.Nome;
            }
        }
    }
}
