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

        public async Task<Ticket> AdicionaTicketAsync(Ticket ticket)
        {
            var conn = _context.Connection;

            using (conn)
            {
                string command = @"INSERT INTO Ticket(IdUsuarioAbertura, IdUsuarioConclusao, IdCliente, IdSituacao, Codigo, DataAbertura, DataConclusao) 
                                              VALUES(@IdUsuarioAbertura, @IdUsuarioConclusao, @IdCliente, @IdSituacao, NEXT VALUE FOR SQ_TicketHAVAN_SQL, @DataAbertura, @DataConclusao)";

                var result = await conn.ExecuteAsync(sql: command, param: ticket);                
                if (result > 0)
                {
                    return ticket;
                }
                return null;
            }
        }

        public async Task<bool> ConcluiTicketAsync(int idTicket)
        {
            throw new System.NotImplementedException();
        }
    }
}
