using Lavanderia.Bussines.Model;
using Lavanderia.Data.Dtos.ClienteDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lavanderia.Bussines.Interfaces.IClientes
{
    public interface ICliente
    {
        Task<OperationResult> CrearCliente(ClienteDto clienteDto);
        Task<OperationResult> ObtenerClientes();
        Task<OperationResult> ObtenerClientesById(int ClienteId);
        Task<OperationResult> EliminarClientesById(int ClienteId);
        Task<OperationResult> ActualizarCliente(ClienteDto clienteDto, int ClienteId);
        Task<OperationResult> ObtenerClienteByNombre(string nombreCliente);
        



    }
}
