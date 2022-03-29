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
    public class  UsuarioRepo : IUsuarioRepo
    {
        private readonly TesteHavanContext _context;

        public UsuarioRepo(TesteHavanContext context)
        {
            _context = context;
        }

        public async Task<Usuario> SalvaUsuario(Usuario usuario)
        {
            IDbConnection conn = _context.GetConnection();

            using (conn)
            {
                conn.Open();
                string command = @"INSERT INTO Usuario(Codigo, Nome) VALUES(@Codigo, @Nome)";

                var result = await conn.ExecuteAsync(sql: command, param: usuario);
                if (result > 0)
                {
                    conn.Close();
                    return usuario;
                }
                conn.Close();
                return null;
            }
        }
    }
}
