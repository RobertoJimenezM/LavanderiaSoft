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


        [HttpGet]
        [Route("Obtener-Ordernes-id")]
        public async Task<ActionResult<OperationResult>> GetOrderById()
        {
            _result.SuccessMessage = "LO REALIZARE EN EL SERVICIO LA LOGICA";
            return Ok(_result);
        }

        [HttpPost]
        [Route("Crear-Orden")]
        public async Task<ActionResult<OperationResult>> CrearOrden()
        {
            _result.SuccessMessage = "LO REALIZARE EN EL SERVICIO LA LOGICA";
            return Ok(_result);
        }


        [HttpPost]
        [Route("Elimiar-Orden")]
        public async Task<ActionResult<OperationResult>> EliminarOrdenById(int OrdenId)
        {
            _result.SuccessMessage = "LO REALIZARE EN EL SERVICIO LA LOGICA";
            return Ok(_result);
        }

    }
}
