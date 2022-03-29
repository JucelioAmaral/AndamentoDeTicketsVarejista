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
    public class ViewController : ControllerBase
    {
        private readonly IViewBDService _viewBDService;

        public ViewController(IViewBDService viewBDService)
        {
            _viewBDService = viewBDService;
        }

        [HttpGet("ConsultaViewBD")]
        public async Task<IActionResult> ConsultaViewBD(int CodigoDoTicket, string NomeDoUsuario, string CPF)
        {
            try
            {
                var returnoConsultaView = await _viewBDService.GetValoresViewBD(CodigoDoTicket, NomeDoUsuario, CPF);
                if (returnoConsultaView == null) return NoContent();

                return Ok(returnoConsultaView);

            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                    $"Erro ao buscar os dados na Function FN_DADOS_HAVAN. Erro: {ex.Message}");
            }
        }
    }
}
