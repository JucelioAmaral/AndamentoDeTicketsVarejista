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
    public class ClienteRepo : IClienteRepo
    {
        private readonly TesteHavanContext _context;

        public ClienteRepo(TesteHavanContext context)
        {
            _context = context;
        }

        public async Task<Cliente> SalvaClienteAsync(Cliente cliente)
        {
            using (var conn = _context.Connection)
            {
                string command = @"INSERT INTO Cliente(Codigo, CPF) VALUES(@Codigo, @CPF)";

                var result = await conn.ExecuteAsync(sql: command, param: cliente);
                if (result > 0)
                {
                    return cliente;
                }
                return null;
            }
        }

        public Task<Cliente> VerificaTicketsDoClienteAsync(int idCliente)
        {
            throw new NotImplementedException();
        }
    }
}
