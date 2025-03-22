using Lavanderia.Bussines.Model;
using Lavanderia.Data.Dtos.ProductoDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lavanderia.Bussines.Interfaces.IProductos
{
    public interface IProductos
    {
        Task<OperationResult> ObtenerProductos();
        Task<OperationResult> CrearProducto(ProductoDto productoDto);
        Task<OperationResult> DesactivarProducto(int productoId);
    }
}
