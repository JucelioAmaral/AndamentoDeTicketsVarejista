using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TesteHavan.Domain;
using TesteHavan.Infrastructure.Context;
using TesteHavan.Infrastructure.Contracts;

namespace TesteHavan.Infrastructure
{
    public class  ViewRepo : IViewRepo
    {
        private readonly TesteHavanContext _context;

        public ViewRepo(TesteHavanContext context)
        {
            _context = context;
        }

        public async Task<ClsView> GetViewAsync(ClsView dados)
        {
            IDbConnection conn = _context.GetConnection();

            using (conn)
            {
                conn.Open();
                string query = @"SELECT * FROM FN_DADOS_HAVAN (@CodigoDoTicket, @NomeDoUsuario, @CPF)";
                ClsView view = await conn.QueryFirstOrDefaultAsync<ClsView>
                    (sql: query, param: dados);

                if (view == null)
                {
                    conn.Close();
                    return null;
                }
                conn.Close();
                return view;
            }
        }
    }
}
