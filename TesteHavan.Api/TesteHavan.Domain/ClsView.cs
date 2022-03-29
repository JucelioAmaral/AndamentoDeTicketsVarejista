using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TesteHavan.Domain
{
    public class ClsView
    {
        public int Id { get; set; }
        public int IdUsuarioAbertura { get; set; }
        public int IdUsuarioConclusao { get; set; }
        public int IdCliente { get; set; }
        public int IdSituacao { get; set; }
        public int CodigoDoTicket { get; set; }
        public DateTime DataAbertura { get; set; }
        public DateTime DataConclusao { get; set; }
        public string CodigoDoCliente { get; set; }
        public string CPF { get; set; }
        public string TicketSitucao { get; set; }
        public string CodigoDoUsuario { get; set; }
        public string NomeDoUsuario { get; set; }
        public int QtdeAnotaçõesTicket { get; set; }
    }
}
