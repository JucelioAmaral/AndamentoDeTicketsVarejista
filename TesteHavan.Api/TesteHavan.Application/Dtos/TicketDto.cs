using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TesteHavan.Application.Dtos
{
    public class TicketDto
    {        
        public int IdUsuarioAbertura { get; set; }
        public int IdUsuarioConclusao { get; set; }     
        public int IdCliente { get; set; }        
        public int IdSituacao { get; set; }                
        public DateTime? DataAbertura { get; set; }
        public DateTime? DataConclusao { get; set; }
    }
}
