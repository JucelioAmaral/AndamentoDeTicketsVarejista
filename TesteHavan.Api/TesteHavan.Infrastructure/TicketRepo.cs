using Dapper;
using System.Data;
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

        public async Task<Ticket> AdicionaTicketAsync(Ticket ticket)
        {
            IDbConnection conn = _context.GetConnection();

            using (conn)
            {
                conn.Open();
                string command = @"INSERT INTO Ticket(IdUsuarioAbertura, IdUsuarioConclusao, IdCliente, IdSituacao, Codigo, DataAbertura, DataConclusao) 
                                              VALUES(@IdUsuarioAbertura, @IdUsuarioConclusao, @IdCliente, @IdSituacao, NEXT VALUE FOR SQ_TicketHAVAN_SQL, GETDATE(), NULL)";

                var result = await conn.ExecuteAsync(sql: command, param: ticket);                
                if (result > 0)
                {
                    conn.Close();
                    return ticket;
                }
                conn.Close();
                return null;
            }
        }

        public async Task<int> AtualizaTicketSitucaoAsync(Ticket ticket)
        {
            IDbConnection conn = _context.GetConnection();

            using (conn)
            {
                conn.Open();
                string command = @"UPDATE Ticket
                                  SET IdSituacao = 1,
                                  DataConclusao = GETDATE()
                                  WHERE Id = @Id";
                var result = await conn.ExecuteAsync(sql: command, param: ticket);
                conn.Close();
                return result;
            }
        }

        public async Task<Ticket> GetTicketAsync(int idTicket)
        {
            IDbConnection conn = _context.GetConnection();

            using (conn)
            {
                conn.Open();
                string query = @"SELECT * FROM Ticket WHERE Id = @idTicket";
                Ticket ticket = await conn.QueryFirstOrDefaultAsync<Ticket>
                    (sql: query, param: new { idTicket });
                conn.Close();
                return ticket;
            }
        }
    }
}
