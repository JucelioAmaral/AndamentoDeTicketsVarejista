using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TesteHavan.Domain;

namespace TesteHavan.Infrastructure.Context
{
    public class TesteHavanContext
    {
        public DbSet<Cliente> Cliente { get; set; }
        public DbSet<Usuario> Usuario { get; set; }
        public DbSet<Ticket> Ticket { get; set; }
        public DbSet<TicketAnotacao> TicketAnotacao { get; set; }
        public DbSet<TicketSituacao> TicketSituacao { get; set; }

        static string connectionString;

        public TesteHavanContext(IConfiguration configuration)
        {
            connectionString = configuration
                     .GetConnectionString("DefaultConnection").ToString();

        }

        public IDbConnection GetConnection()
        {
            return new SqlConnection(connectionString);
        }
    }
}
