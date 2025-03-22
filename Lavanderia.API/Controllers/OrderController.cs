using Lavanderia.Bussines.Model;
using Lavanderia.Bussines.Services.SClientes;
using Lavanderia.Data.Dtos.ClienteDto;
using Microsoft.AspNetCore.Mvc;

namespace Lavanderia.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrderController : Controller
    {
        private OperationResult _result;
        private SCliente _SCliente;
        public OrderController(SCliente sCliente)
        {
            _SCliente = sCliente;
            _result = new OperationResult();
        }


        [HttpGet]
        public async Task<ActionResult<OperationResult>> GetOrder()
        {
            _result.SuccessMessage = "El mejor esto esta funcionando";
            return Ok(_result);
        }

        //[HttpPost]
        //[Route("Crear-Cliente")]
        //public async Task<ActionResult<OperationResult>> CrearCliente([FromBody] ClienteDto clienteDto)
        //{

        //    _result = await _SCliente.CrearCliente(clienteDto);
        //    if (_result.Success)
        //    {
        //        return Ok(_result);
        //    }
        //    return BadRequest(_result);


        //}



    }
}
