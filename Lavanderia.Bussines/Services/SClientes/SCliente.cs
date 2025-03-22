using AutoMapper;
using Lavanderia.Bussines.Interfaces.IClientes;
using Lavanderia.Bussines.Model;
using Lavanderia.Data.Dtos.ClienteDto;
using Lavanderia.Data.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lavanderia.Bussines.Services.SClientes
{
    public class SCliente : ICliente
    {
        private OperationResult _result;
        private IMapper _mapper;
        private LavanderiaContext _context;
        private string _errorMessage = "Ocurrio un error";
        private string _sucessMessage = "Exitoso";
        public SCliente(IMapper mapper, LavanderiaContext lavanderiaContext)
        {
            _context = lavanderiaContext;
            _mapper = mapper;
            _result = new OperationResult();
        }

        public async Task<OperationResult> ActualizarCliente(ClienteDto clienteDto, int ClienteId)
        {
            try
            {
                var cliente = await _context.Clientes.Where(x => x.ClienteId == ClienteId && x.Activo == true).FirstOrDefaultAsync();

                if (cliente is null)
                {
                    _result.Success = false;
                    _result.ErrorMessage = _errorMessage;
                    _result.Data = null;
                    return _result;
                }

                cliente.Identificacion = clienteDto.Identificacion;
                cliente.Email = clienteDto.Email;
                cliente.Telefono = clienteDto.Telefono;
                cliente.Nombre = clienteDto.Nombre;
                cliente.Direccion = clienteDto.Direccion;
                cliente.FechaMod = DateTime.Now;

                _context.Entry(cliente).State = EntityState.Modified;
                await _context.SaveChangesAsync();

                var dtoR = _mapper.Map<ClienteDto>(clienteDto);
                _result.Success = true;
                _result.SuccessMessage = _sucessMessage;
                _result.Data = dtoR;
                return _result;

            }catch(Exception ex)
            {
                _result.ExceptionError = ex.Message;
                _result.ErrorMessage = _errorMessage;
                _result.Success = false;
                _result.Data = null;
                return _result;
            }

        }

        public async Task<OperationResult> CrearCliente(ClienteDto clienteDto)
        {

            try
            {
                if (clienteDto is null)
                {
                    _result.ErrorMessage = _errorMessage;
                    _result.Success = false;
                    _result.Data = null;
                    return _result;
                }
                var newClient = new Clientes
                {
                    Nombre = clienteDto.Nombre,
                    Telefono = clienteDto.Telefono,
                    Direccion = clienteDto.Direccion,
                    Email = clienteDto.Email,
                    Identificacion = clienteDto.Identificacion,
                    Identificador = Guid.NewGuid(),
                    FechaCrea = DateTime.Now,
                    FechaMod = DateTime.Now,
                    Activo = true
                };

                await _context.Clientes.AddAsync(newClient);
                await _context.SaveChangesAsync();

                var client = _mapper.Map<ClienteDto>(newClient);

                _result.SuccessMessage = _sucessMessage;
                _result.Success = true;
                _result.Data = client;

            }
            catch (Exception ex)
            {
                _result.ExceptionError = ex.Message;
                _result.Success = false;
                _result.Data = null;
                return _result;
            }


            return _result;
        }

        public async Task<OperationResult> EliminarClientesById(int ClienteId)
        {
            try
            {
                if (ClienteId == 0)
                {
                    _result.ErrorMessage = _errorMessage;
                    _result.Success = false;
                    _result.Data = null;
                    return _result;
                }
                var usuario = await _context.Clientes.Where(x => x.ClienteId == ClienteId).FirstOrDefaultAsync();

                if (usuario == null)
                {
                    _result.ErrorMessage = _errorMessage;
                    _result.Success = false;
                    _result.Data = null;
                    return _result;
                }

                usuario.Activo = false;
                usuario.FechaMod = DateTime.Now;

                _context.Entry(usuario).State = EntityState.Modified;
                await _context.SaveChangesAsync();
                _result.SuccessMessage = _sucessMessage;
                _result.Success = true;
                _result.Data = null;
                return _result;
            }
            catch (Exception ex) 
            {
                _result.ErrorMessage = _errorMessage;
                _result.ErrorMessage = ex.Message;
                _result.Success = false;
                _result.Data = null;
                return _result;
            }
            
        }

        public async Task<OperationResult> ObtenerClienteByNombre(string nombreCliente)
        {
            try
            {
                var buscar = await _context.Clientes.Where(x => x.Nombre.ToLower().Contains(nombreCliente.ToLower()) && x.Activo == true).ToListAsync();

                if (buscar.Count == 0) 
                {
                    _result.ErrorMessage = _errorMessage;
                    _result.Success = false;
                    return _result;
                }
                var dtoreturn = _mapper.Map<List<ClienteDto>>(buscar);

                _result.SuccessMessage = _sucessMessage;
                _result.Success = true;
                _result.Data = dtoreturn;
                return _result;

            }
            catch (Exception ex)
            {
                _result.ExceptionError = ex.Message;
                _result.ErrorMessage = _errorMessage;
                _result.Success = false;
                return _result;
            }
        }

        public async Task<OperationResult> ObtenerClientes()
        {
            try
            {
                var cliente = await _context.Clientes.Where(x => x.Activo == true).ToListAsync();

                if (cliente.Count() == 0)
                {
                    _result.ErrorMessage = _errorMessage;
                    _result.Success = false;
                    _result.Data = null;
                    return _result;
                }
                
                var clienteDto = _mapper.Map<List<ClienteDto>>(cliente);
                _result.Success = true;
                _result.SuccessMessage = _sucessMessage;
                _result.Data = clienteDto;
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

        public async Task<OperationResult> ObtenerClientesById(int ClienteId)
        {

            try
            {
                var obtCliente = await _context.Clientes.Where(x => x.ClienteId == ClienteId && x.Activo == true).FirstOrDefaultAsync();

                if(obtCliente is not null)
                {
                    var clientR = _mapper.Map<ClienteDto>(obtCliente);
                    _result.SuccessMessage = _sucessMessage;
                    _result.Success = true;
                    _result.Data = clientR;
                    return _result;
                }

                _result.ErrorMessage = _errorMessage;
                _result.Success = false;
                _result.Data = null;
                return _result;

            }catch(Exception ex)
            {
                _result.ErrorMessage = _errorMessage;
                _result.ExceptionError = ex.Message;
                _result.Success = false;
                _result.Data = null;
                return _result;
            }
        }
    }
}
