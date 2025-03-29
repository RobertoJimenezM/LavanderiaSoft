using AutoMapper;
using Lavanderia.Bussines.Interfaces.IProductos;
using Lavanderia.Bussines.Model;
using Lavanderia.Data.Dtos.ProductoDto;
using Lavanderia.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lavanderia.Bussines.Services.SProductos
{
    public class SProductos : IProductos
    {
        private OperationResult _result;
        private IMapper _mapper;
        private LavanderiaContext _context;
        private string _sucessMessage = "Exito!!";
        private string _errorMessage = "Uuupps, Ha ocurrido un error.";
        private bool _success = true;
        public SProductos(IMapper mapper, LavanderiaContext lavanderiaContext)
        {
            _result = new OperationResult();
            _mapper = mapper;  
            _context = lavanderiaContext;
        }


        public async Task<OperationResult> CrearProducto(ProductoDto productoDto)
        {
            try
            {
                if(productoDto is null)
                {
                    _result.ErrorMessage = _errorMessage;
                    _result.Success = _success;
                    _result.Data = null;
                    return _result;
                }
                var produt = new Productos
                {
                    Nombre = productoDto.Nombre,
                    Descripcion = productoDto.Descripcion,
                    Precio = productoDto.Precio,
                    FechaCrea = DateTime.Now,
                    FechaMod = DateTime.Now,
                    Estado = true
                };
                await _context.Productos.AddAsync(produt);
                _context.SaveChanges();

                _result.SuccessMessage = _sucessMessage;
                _result.Success = true;
                _result.Data = null;
                return _result;
            }
            catch (Exception ex) 
            { 
                _result.ErrorMessage = _errorMessage;
                _result.Success = _success;
                _result.ExceptionError = ex.Message;
                _result.Data = null;
                return _result;
            }
            //return _result;
        }

        public async Task<OperationResult> DesactivarProducto(int productoId)
        {
            try
            {
                var producto = await _context.Productos.Where(x => x.ProductoId == productoId && x.Estado == true).FirstOrDefaultAsync();
                if (producto is null) 
                {
                    _result.ErrorMessage = _errorMessage;
                    _result.Success = false;
                    _result.Data = null;
                    return _result;
                }

                producto.Estado = false;

                //_context.Productos.Update(producto);
                _context.Entry(producto).State = EntityState.Modified;
                await _context.SaveChangesAsync();
                _result.Success = _success;
                _result.SuccessMessage = _sucessMessage;
                _result.Data = null;
                return _result;
            }
            catch (Exception ex) 
            {
                _result.ErrorMessage = _errorMessage;
                _result.Success = false;
                _result.Data = null;
                _result.ExceptionError = ex.Message;
                return _result;
            }
            
        }

        public async Task<OperationResult> ObtenerProductos()
        {
            try
            {
                var product = await _context.Productos.Where(x => x.Estado == true).ToListAsync();


                var productDto = _mapper.Map<List<ProductoDto>>(product);
                if (product.Count() == 0) 
                { 
                    _result.ErrorMessage = "No tenemos productos disponibles";
                    _result.Success = false;
                    _result.Data = null;
                    return _result;

                }
                _result.SuccessMessage = _sucessMessage;
                _result.Success = _success;
                _result.Data = productDto;

                return _result;
            }
            catch (Exception ex) 
            {
                _result.ExceptionError = ex.Message;
                _result.Success = false;
                _result.Data = null;
                return _result;
            }
        }
    }
}
