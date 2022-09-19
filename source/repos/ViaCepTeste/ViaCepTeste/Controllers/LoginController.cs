using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using ViaCepTeste.Data;
using ViaCepTeste.Models;
using ViaCepTeste.Services;

namespace ViaCepTeste.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LoginController : ControllerBase
    {
        private readonly DatabaseContext _context;

        public LoginController(DatabaseContext context)
        {
            _context = context;
        }

        [HttpPost]
        [Route("login")]
        public async Task<ActionResult<dynamic>> Authenticate([FromBody] User user)
        {
            user = _context.Get(user.Usuario, user.Senha);

            if (user == null)
                return NotFound(new { message = "Usuário ou senha inválidos." });

            var token = await TokenService.GenerateToken(user);
            user.Senha = "";
            user.Token = token;

            return Ok(new
            {
                usuario = user.Usuario,
                tokenDeAcesso = token
            });
        }
    }
}
