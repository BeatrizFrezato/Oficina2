using ELLP_Project.Models;
using ELLP_Project.Services;
using ELLP_Project.Interfaces.InterfacesServices;
using Microsoft.AspNetCore.Mvc;

namespace ELLP_Project.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LoginController : ControllerBase
    {
        private readonly LoginServices _loginServices;

        public LoginController(ILoginServices loginServices)
        {
            _loginServices = loginServices;
        }

        [HttpPost]
        public IActionResult Login([FromBody] LoginModel login)
        {
            var resultado = _loginServices.Autenticar(login);

            if (resultado == null)
                return Unauthorized("Login ou senha inválidos.");

            return Ok(new
            {
                mensagem = "Login realizado com sucesso!",
                perfil = resultado.Value.perfil
            });
        }
    }
}