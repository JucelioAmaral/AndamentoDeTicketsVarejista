using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TesteHavan.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ViewController : ControllerBase
    {
        public ViewController()
        {

        }

        [HttpGet("ConsultaViewBD")]
        public async Task<IActionResult> ConsultaViewBD()
        {
            return null;
        }
    }
}
