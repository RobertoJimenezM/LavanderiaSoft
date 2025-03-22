using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lavanderia.Data.Dtos.ClienteDto
{
    public class ClienteDto
    {
        //public int ClienteId { get; set; }
        public string? Identificacion { get; set; }
        public required string Nombre { get; set; }
        public string? Telefono { get; set; }
        public string? Email { get; set; }
        public required string Direccion { get; set; }

    }
}
