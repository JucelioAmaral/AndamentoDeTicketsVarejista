using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TesteHavan.Application.Contracts;
using TesteHavan.Application.Dtos;

namespace TesteHavan.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TicketController : ControllerBase
    {
        private readonly ITicketService _ticketService;        
        private readonly ITicketSituacaoService _ticketSitService;

        public TicketController(ITicketService ticketService, ITicketSituacaoService ticketSitService)
        {
            _ticketService = ticketService;            
            _ticketSitService = ticketSitService;
        }

        [HttpPost("CriaTicket")]
        public async Task<IActionResult> CriaTicket(TicketDto model)
        {
            try
            {
                if ("Em andamento" == await _ticketSitService.VerificaSitucaoDosTicketsDoCliente(model.IdSituacao))
                {
                    return BadRequest($"O cliente com o Id {model.IdCliente} tem ticket com status Em andamento.");
                }
                else
                {
                    var ticket = await _ticketService.AdicionaTicket(model);
                    if (ticket == null) return NoContent();

                    return Ok(model);
                }                
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                    $"Erro ao tentar adicionar o ticket. Erro: {ex.Message}");
            }
        }


        [HttpPut("ConcluiTicket/{IdTicket}")]
        public async Task<IActionResult> ConcluiTicket(int IdTicket)
        {
            try
            {
                var ticket = await _ticketService.GetTicket(IdTicket);
                var result = await _ticketService.ConcluiTicketSitucaoDoCliente(ticket);
                if (result == false) return NoContent();

                return Ok($"Ticket Id {IdTicket} concluído ");

            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                    $"Erro ao tentar Atualizar situação do ticket. Erro: {ex.Message}");
            }
        }
    }
}
