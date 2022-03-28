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

        public TicketController(ITicketService ticketService)
        {
            _ticketService = ticketService;
        }

        [HttpPost("CriaTicket")]
        public async Task<IActionResult> CriaTicket(TicketDto model)
        {
            try
            {
                if("Em andamento" == await _ticketService.VerificaSitucaoTicket(model.IdSituacao))
                {
                    return BadRequest($"Ticket {model.Codigo} está com o status Em andamento.");
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
                    $"Erro ao tentar adicionar o cliente. Erro: {ex.Message}");
            }
        }

        [HttpPut("AtualizaTicket")]
        public async Task<IActionResult> AtualizaTicket()
        {
            return null;
        }

        [HttpPut("ConcluiTicket")]
        public async Task<IActionResult> ConcluiTicket()
        {
            return null;
        }
    }
}
