using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TesteHavan.Application.Dtos
{
    public class TicketAnotDto
    {        
        public int IdTicket { get; set; }        
        public int IdUsuario { get; set; }        
        public string Texto { get; set; }
        public DateTime? Data { get; set; }
    }
}
