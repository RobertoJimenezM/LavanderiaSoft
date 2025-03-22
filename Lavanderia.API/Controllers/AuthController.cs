using Lavanderia.Bussines.Model;
using Lavanderia.Bussines.Services.SAuth;
using Lavanderia.Data.Dtos.UsuarioDto;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client;

namespace Lavanderia.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : Controller
    {
        private ResponseAuth _responseAuth;
        private SAuth _auth;
        public AuthController(SAuth auth) 
        {
            _responseAuth = new ResponseAuth();
            _auth = auth;
        }

        [HttpPost]
        [Route("Crear-Usuario")]
        public async Task<ActionResult<ResponseAuth>> CrearUsuario([FromBody] UsuarioDTO usuarioDTO)
        {
            _responseAuth = await _auth.CrearUsuario(usuarioDTO);
            if (_responseAuth.sucess)
            {
                return Ok(_responseAuth);
            }

            return BadRequest(_responseAuth);
        }

        [HttpPost]
        [Route("Login")]
        public async Task<ActionResult<ResponseAuth>> Login(string usuario, string password)
        {
            _responseAuth = await _auth.Login(usuario, password);
            if (_responseAuth.sucess) 
            {
                return Ok(_responseAuth);
            }
            return NotFound(_responseAuth);
        }
    }
}
