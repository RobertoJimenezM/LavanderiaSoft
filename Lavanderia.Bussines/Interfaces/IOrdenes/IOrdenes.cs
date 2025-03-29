using Lavanderia.Bussines.Model;
using Lavanderia.Data.Dtos.OrdenDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lavanderia.Bussines.Interfaces.IOrdenes
{
    public interface IOrdenes
    {
        Task<OperationResult> ObtenerOrdenes();
        Task<OperationResult> ObtenerOrdenesById(int OrdenId);
        Task<OperationResult> CrearOrden(OrdenDto ordenDto);
        Task<OperationResult> EliminarOrden(int OrdenId);
        //Task<OperationResult> ObtenerOrdenes();

    }
}
