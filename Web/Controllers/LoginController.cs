using Dominio.Dto;
using Dominio.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly LoginService _loginService;
        public LoginController(LoginService loginService)
        {
            _loginService = loginService;
        }

        [HttpGet]
        public OkResult Login([FromBody] ClienteDto clienteDto)
        {
            _loginService.Login(clienteDto);
            return Ok();
        }
    }
}
