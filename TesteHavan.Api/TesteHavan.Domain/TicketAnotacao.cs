using System;

namespace TesteHavan.Domain
{
    public class TicketAnotacao
    {
        public int Id { get; set; }
        public int IdTicket { get; set; }
        public Ticket Ticket { get; set; }
        public int IdUsuario { get; set; }
        public Usuario Usuario { get; set; }        
        public string Texto { get; set; }
        public DateTime? Data { get; set; }
    }
}
