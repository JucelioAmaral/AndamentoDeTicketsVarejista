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
    public class TicketAnotacoesController : ControllerBase
    {
        private readonly ITicketAnotacoesService _ticketAnotService;        

        public TicketAnotacoesController(ITicketAnotacoesService ticketAnotervice)
        {
            _ticketAnotService = ticketAnotervice;            
        }

        [HttpPost("AnotacoesTicket")]
        public async Task<IActionResult> TicketAnotacoes(TicketAnotDto model)
        {
            try
            {             
                var anotacoesInfoTicket = await _ticketAnotService.AnotaInfoTicket(model);
                if (anotacoesInfoTicket == null) return NoContent();

                return Ok(anotacoesInfoTicket);

            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                    $"Erro ao tentar adicionar anotações de ticket. Erro: {ex.Message}");
            }
        }
    }
}
