using System;

namespace TesteHavan.Domain
{
    public class Ticket
    {
        public int Id { get; set; }
        public int IdUsuarioAbertura { get; set; }        
        public int IdUsuarioConclusao { get; set; }
        public Usuario Usuario { get; set; }
        public int IdCliente { get; set; }
        public Cliente Cliente { get; set; }
        public int IdSituacao { get; set; }        
        public TicketSituacao TicketSituacao { get; set; }
        public int Codigo { get; set; }
        public DateTime? DataAbertura { get; set; }
        public DateTime? DataConclusao { get; set; }
    }
}
