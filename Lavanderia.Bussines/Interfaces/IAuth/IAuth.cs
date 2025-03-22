using Lavanderia.Bussines.Model;
using Lavanderia.Data.Dtos.UsuarioDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lavanderia.Bussines.Interfaces.IAuth
{
    public interface IAuth
    {
        Task<ResponseAuth> CrearUsuario(UsuarioDTO usuarioDTO);
        Task<ResponseAuth> Login(string usuario,string password);

    }
}
