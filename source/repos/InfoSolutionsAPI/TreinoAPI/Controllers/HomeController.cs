using AutoMapper;
using TreinoAPI.Ativos;
using TreinoAPI.Data;
using TreinoAPI.Data.Dto.Carteira;
using TreinoAPI.Data.Dto.User;
using TreinoAPI.Models;
using TreinoAPI.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TreinoAPI.Interfaces;

namespace TreinoAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LoginController : ControllerBase
    {
        private IMapper _mapper;
        private DatabaseContext _context;
        private IHomeInterface _homeService;

        public LoginController(IHomeInterface service, IMapper mapper, DatabaseContext context)
        {
            _homeService = service;
            _mapper = mapper;
            _context = context;
        }

        [HttpPost]
        [Route("login")]
        public async Task<ActionResult<dynamic>> Authenticate([FromBody] LoginUserDto userDto)
        {

            User user = _mapper.Map<User>(userDto);

            user = _context.Get(user.Usuario, user.Senha);
            if (user == null)
                return NotFound(new { message = "Usuário ou senha inválidos." });

            var token = await TokenService.GenerateToken(user);

            user.Senha = "";
            user.Token = token;
            return new
            {
                user = userDto,
                token = token
            };
        }

        [HttpPost]
        [Route("cadastroAdmin")]
        [Authorize(Roles = "admin")]
        public IActionResult CadastroMaster([FromBody] CadastroUserDto userDto)
        {

            return Ok(_homeService.CadastroMaster(userDto));
        }

        [HttpPost]
        [Route("cadastroCliente")]
        [Authorize(Roles = "admin,gerente")]
        public IActionResult CadastroClientes([FromBody] CadastroUserDto userDto)
        {
            return Ok(_homeService.CadastroClientes(userDto));
        }

        [HttpPost]
        [Route("cadastroAtivos/{usuario}")]
        [Authorize(Roles = "cliente")]
        public IActionResult AdicionaAtivos([FromBody] Ativo ativo, string usuario)
        {
            if (User.Identity.Name == usuario)
            {
                return Ok(_homeService.AdicionaAtivos(ativo, usuario));
            }
            return BadRequest();
        }

        [HttpGet]
        [Route("usuarios/{nome}")]
        [Authorize(Roles = "gerente,admin")]
        public IActionResult RecebeUsarioNome(string usuario)
        {
            return Ok(_homeService.RecebeUsarioNome(usuario));
        }

        [HttpGet]
        [Route("ativos")]
        [Authorize(Roles = "admin")]
        public IActionResult RecuperaAtivos()
        {
            return Ok(_homeService.RecuperaAtivos());
        }

        [HttpGet]
        [Route("buscaclientes")]
        [Authorize(Roles = "admin,gerente")]
        public IActionResult RecuperaClientes(string role)
        {
            return Ok(_homeService.RecuperaClientes(role));
        }

        [HttpGet]
        [Route("buscagerente")]
        [Authorize(Roles = "admin")]
        public IActionResult RecuperaGerentes(string role)
        {
            return Ok(_homeService.RecuperaGerentes(role));
        }
    }
}
