using AutoMapper;
using Lavanderia.Bussines.Interfaces.IAuth;
using Lavanderia.Bussines.Model;
using Lavanderia.Data.Dtos.UsuarioDto;
using Lavanderia.Data.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Lavanderia.Bussines.Services.SAuth
{
    public class SAuth : IAuth
    {
        private ResponseAuth _responseAuth;
        private IConfiguration _configuration;
        private IMapper _mapper;
        private LavanderiaContext _context;
        public SAuth(IConfiguration configuration, IMapper mapper, LavanderiaContext context) 
        { 
            _configuration = configuration;
            _mapper = mapper;
            _responseAuth = new ResponseAuth();
            _context = context;
        }

        public async Task<ResponseAuth> CrearUsuario(UsuarioDTO usuarioDTO)
        {
            try
            {

                if(usuarioDTO is null)
                {
                    _responseAuth.sucess = false;
                    _responseAuth.Token = null;
                    _responseAuth.RefreshToken = null;
                    return _responseAuth;
                }
                var password = EncriptarPassword(usuarioDTO.Password);
                var user = new Usuarios
                {
                    Usuario = usuarioDTO.Usuario,
                    Password = password,
                    IdentificadorUsuario = Guid.NewGuid(),
                    Email = usuarioDTO.Email,
                    FechaCrea = DateTime.Now,
                    FechaMod = DateTime.Now,
                    Estado = true

                };
                await _context.Usuarios.AddRangeAsync(user);
                await _context.SaveChangesAsync();
                var token = GenerateToken(usuarioDTO.Usuario);

                _responseAuth.sucess = true;
                _responseAuth.Token = token;
                return _responseAuth;

            }
            catch(Exception ex)
            {
                _responseAuth.sucess = false;
                _responseAuth.Token = null;
                _responseAuth.RefreshToken = null;
                return _responseAuth;
            }

        }

        public async Task<ResponseAuth> Login(string usuario,string password)
        {
            try
            {
                if (usuario is null || password is null)
                {
                    _responseAuth.sucess = false;
                    _responseAuth.Token = null;
                    _responseAuth.RefreshToken = null;
                    _responseAuth.message = "Todos los campos son obligatorios";
                    return _responseAuth;
                }


                var user = await _context.Usuarios.Where(x => x.Usuario == usuario && x.Estado == true).FirstOrDefaultAsync(); 
                if(user is null)
                {
                    _responseAuth.sucess = false;
                    _responseAuth.Token = null;
                    _responseAuth.RefreshToken = null;
                    _responseAuth.message = "Usuario o Contraseña incorrecto, favor de ingreselo otra vez.";
                    return _responseAuth;
                }

                bool verificarPass = DesencriptarPassword(password, user.Password);

                if(user.Password != null && verificarPass == false)
                {
                    //var token = GenerateToken(usuario);
                    _responseAuth.sucess = false;
                    _responseAuth.Token = null;
                    _responseAuth.RefreshToken = null;
                    _responseAuth.message = "Contraseña incorrecta";
                    return _responseAuth;
                }

                var token = GenerateToken(usuario);
                _responseAuth.sucess = true;
                _responseAuth.Token = token;
                _responseAuth.RefreshToken = null;
                _responseAuth.message = "Inicio de sección exitoso.";
                return _responseAuth
;
            }
            catch (Exception ex) 
            {
                _responseAuth.sucess = false;
                _responseAuth.Token = null;
                _responseAuth.RefreshToken = null;
                _responseAuth.message = ex.Message;
                return _responseAuth;
            }

        }

        private string GenerateToken(string usuario)
        {
            var claims = new []
            {
                new Claim("user",usuario),
                new Claim(JwtRegisteredClaimNames.Jti,Guid.NewGuid().ToString()),
               
            };
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
            var credencial = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            //var minutos = int.Parse(_configuration["Jwt:Minutos"]);
            var token = new JwtSecurityToken
             (
                issuer: _configuration["Jwt:Issues"],              
                audience: _configuration["Jwt:Audience"],
                claims: claims,
                expires: DateTime.UtcNow.AddMinutes(int.Parse(_configuration["Jwt:Minutos"])),
                signingCredentials: credencial

             );
            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        private string EncriptarPassword(string password) 
        {
            string passEncrip = BCrypt.Net.BCrypt.HashPassword(password);
            return passEncrip;
        }

        private bool DesencriptarPassword(string pass, string password)
        {
            bool passwordmatch = BCrypt.Net.BCrypt.Verify(pass, password);
            if(passwordmatch == false)
            {
                return false;
            }
            return true;
        }
    }
}
