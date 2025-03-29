using AutoMapper;
using Lavanderia.Bussines.Interfaces.IOrdenes;
using Lavanderia.Bussines.Model;
using Lavanderia.Data.Dtos.OrdenDto;
using Lavanderia.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lavanderia.Bussines.Services.SOrdenes
{
    public class SOrdenes : IOrdenes
    {

        private LavanderiaContext _context;
        private OperationResult _result;
        private IMapper _mapper;
        private string _sucessMessage = "Exito!!";
        private string _errorMessage = "Uuupps, Ha ocurrido un error.";
        private bool _success = true;

        public SOrdenes(LavanderiaContext context, IMapper mapper)
        {
            _mapper = mapper;
            _context = context;
            _result = new OperationResult();
        }

        public async Task<OperationResult> CrearOrden(OrdenDto ordenDto)
        {
            try
            {
                if (ordenDto is null)
                {
                    _result.Success = false;
                    _result.ErrorMessage = _errorMessage;
                    _result.Data = null;
                    return _result;
                }


                var crearOrden = new Ordenes
                {
                    ClienteId = ordenDto.ClienteId,
                    Estado = true,
                    FechaCrea = DateTime.Now,
                    FechaMod = DateTime.Now,
                    OrdenesDetails = new List<OrdenesDetails>() 
                };

                decimal totalOrden = 0; 
                foreach (var item in ordenDto.OrderDetailsDtos)
                {
                    var producto = await _context.Productos.FindAsync(item.ProductoId);


                    if (producto is null)
                    {
                        _result.Success = false;
                        _result.ErrorMessage = _errorMessage;
                        _result.Data = null;
                        return _result;
                    }

                    var ordenDetail = new OrdenesDetails
                    {
                        Cantidad = item.Cantidad,
                        Estado = true,
                        ProductoId = item.ProductoId,
                        PrecioUnitario = producto.Precio,
                        Subtotal = producto.Precio * item.Cantidad 
                    };


                    crearOrden.OrdenesDetails.Add(ordenDetail);

                    totalOrden += ordenDetail.Subtotal;
                }


                crearOrden.Total = totalOrden;


                await _context.Ordenes.AddAsync(crearOrden);
                await _context.SaveChangesAsync();


                foreach (var detalle in crearOrden.OrdenesDetails)
                {
                    detalle.OrdenId = crearOrden.OrdenId;
                }

                await _context.SaveChangesAsync();
                var ordenDtoResult = _mapper.Map<OrdenDto>(crearOrden);


                _result.Success = true;
                _result.SuccessMessage = _sucessMessage;
                _result.Data = ordenDtoResult; 

                return _result;

            }
            catch (Exception ex) 
            { 
                _result.ExceptionError = ex.Message;
                _result.ErrorMessage = _errorMessage;
                _success = false;
                return _result;
            }
        }

        public Task<OperationResult> EliminarOrden(int OrdenId)
        {
            throw new NotImplementedException();
        }

        public async Task<OperationResult> ObtenerOrdenes()
        {
            try
            {
                var orden = await _context.Ordenes.Include(o => o.OrdenesDetails).ThenInclude(p => p.Productos).ToListAsync();
                
                if(orden.Count() == 0)
                {
                    _result.Success = false;
                    _result.ErrorMessage = _errorMessage;
                    _result.Data = null;
                    return _result;
                }

                var ordenR = _mapper.Map<List<OrdenDto>>(orden);
                return _result;
            }
            catch (Exception ex) 
            {

                _result.ErrorMessage = _errorMessage;
                _result.ExceptionError = ex.Message;
                _result.Success = false;
                _result.Data = null;
                return _result;
            
            }
        }

        public Task<OperationResult> ObtenerOrdenesById(int OrdenId)
        {
            throw new NotImplementedException();
        }
    }
}
