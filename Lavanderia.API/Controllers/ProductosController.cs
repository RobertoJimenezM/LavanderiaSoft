using Lavanderia.Bussines.Model;
using Lavanderia.Bussines.Services.SProductos;
using Lavanderia.Data.Dtos.ProductoDto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Lavanderia.API.Controllers
{
    //[Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ProductosController : ControllerBase
    {
        private OperationResult _result;
        private SProductos _SProductos;
        public ProductosController(SProductos sProductos )
        {
            _SProductos = sProductos;
            _result = new OperationResult();
            
        }

        [HttpGet]
        public async Task<ActionResult<OperationResult>> ObtenerProductos()
        {
            _result = await _SProductos.ObtenerProductos();
            if (_result.Success)
            {
                return Ok(_result);
            }
            return BadRequest(_result);
        }

        [HttpPost]
        [Route("Crea-Producto")]
        public async Task<ActionResult<OperationResult>> CrearPorducto([FromBody] ProductoDto productoDto)
        {
            _result = await _SProductos.CrearProducto(productoDto);

            if (_result.Success)
            {
                return NoContent();
            }

            return BadRequest(_result);

        }

        [HttpPost]
        [Route("Eliminar")]
        public async Task<ActionResult<OperationResult>> EliminarProducto(int productoId)
        {
            _result = await _SProductos.DesactivarProducto(productoId);
            if (_result.Success) 
            {
                return Ok(_result);
            }
            return NotFound(_result);
        }



    }
}
