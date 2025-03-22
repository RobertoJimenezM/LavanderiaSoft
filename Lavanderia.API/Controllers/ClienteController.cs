using Lavanderia.Bussines.Model;
using Lavanderia.Bussines.Services.SClientes;
using Lavanderia.Data.Dtos.ClienteDto;
using Microsoft.AspNetCore.Mvc;
using System.Reflection.Emit;

namespace Lavanderia.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ClienteController : Controller
    {
        private SCliente _SCliente;
        private OperationResult _result;
        public ClienteController(SCliente sCliente)
        {
            _SCliente = sCliente;
            _result = new OperationResult();
            
        }

        [HttpGet]
        public async Task<ActionResult<OperationResult>> AllCLiente()
        {
            _result = await _SCliente.ObtenerClientes();
            if (_result.Success)
            {
                return Ok(_result);
            }
            return BadRequest(_result);
        }

        [HttpGet]
        [Route("Obtener-ClienteId")]
        public async Task<ActionResult<OperationResult>> ObtenerClienteById(int ClienteId)
        {
            _result = await _SCliente.ObtenerClientesById(ClienteId);
            if (_result.Success) 
            {
                return Ok(_result);
            }
            return NotFound();
        }

        [HttpGet("{nombreCliente}")]
        public async Task<ActionResult<OperationResult>> ObtenerClienteByNombre(string nombreCliente)
        {
            _result = await _SCliente.ObtenerClienteByNombre(nombreCliente);
            if (_result.Success)
            {
                return Ok(_result);
            }
            return NotFound(_result);
        }



        [HttpPost]
        [Route("Crear-Cliente")]
        public async Task<ActionResult<OperationResult>> CrearCliente([FromBody] ClienteDto clienteDto)
        {
            _result = await _SCliente.CrearCliente(clienteDto);

            if (_result.Success)
            {
                return Ok(_result);
            }
            return BadRequest(_result);
        }

        [HttpPut]
        [Route("Actualizar/Cliente/{ClienteId}")]
        public async Task<ActionResult<OperationResult>> ActualizarCliente([FromBody] ClienteDto clienteDto, int ClienteId)
        {
            _result = await _SCliente.ActualizarCliente(clienteDto, ClienteId);
            if (_result.Success)
            {
                //return NoContent();
                return Ok(_result);
            }
            return BadRequest(_result);
        }

        [HttpDelete]
        [Route("Eliminar/cliente/{ClienteId}")]
        public async Task<ActionResult<OperationResult>> EliminarCliente(int ClienteId)
        {
            _result = await _SCliente.EliminarClientesById(ClienteId);
            if (_result.Success) 
            { 
                return NoContent();
            }
            return BadRequest();
        }


        

    }
}
