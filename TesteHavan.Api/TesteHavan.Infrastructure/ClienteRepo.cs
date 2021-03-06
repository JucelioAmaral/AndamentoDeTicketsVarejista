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
    public class ClienteRepo : IClienteRepo
    {
        private readonly TesteHavanContext _context;

        public ClienteRepo(TesteHavanContext context)
        {
            _context = context;
        }

        public async Task<Cliente> SalvaClienteAsync(Cliente cliente)
        {
            IDbConnection conn = _context.GetConnection();

            using (conn)
            {
                conn.Open();
                string command = @"INSERT INTO Cliente(Codigo, CPF) VALUES(@Codigo, @CPF)";

                var result = await conn.ExecuteAsync(sql: command, param: cliente);
                if (result > 0)
                {
                    conn.Close();
                    return cliente;
                }
                conn.Close();
                return null;
            }
        }
    }
}
