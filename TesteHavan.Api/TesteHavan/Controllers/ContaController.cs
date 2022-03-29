using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Threading.Tasks;
using TesteHavan.Application;
using TesteHavan.Application.Contracts;
using TesteHavan.Domain.ModelLogin;
using TesteHavan.Infrastructure.RepoLogin;

namespace TesteHavan.Controllers
{
    [AllowAnonymous]
    [ApiController]
    [Route("api/[controller]")]
    public class ContaController : ControllerBase
    {        
        private readonly IConfiguration _configuration;

        public ContaController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpPost]
        [Route("Login")]
        public async Task<ActionResult<dynamic>> Login([FromBody] UsuarioLogin model)
        {
            // Recupera o usuário
            var user = UsarioLoginRepositpory.Get(model.Username, model.Password);

            // Verifica se o usuário existe
            if (user == null)
                return NotFound(new { message = "Usuário ou senha inválidos" });

            TokenService t = new TokenService(_configuration);
            // Gera o Token
            var token = t.GenerateToken(user);

            // Oculta a senha
            user.Password = "";

            // Retorna os dados
            return new
            {
                user = user,
                token = token
            };
        }

    }
}
