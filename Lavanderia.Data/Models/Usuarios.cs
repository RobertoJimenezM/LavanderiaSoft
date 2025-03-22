using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lavanderia.Data.Models
{
    [Table("Usuarios")]
    public class Usuarios
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int UsuarioId { get; set; }
        public Guid IdentificadorUsuario { get; set; }
        public string? Usuario { get; set; }
        //[EmailAddress(ErrorMessage = "Debe ser una direccion de Email valido")]
        public string? Password { get; set; }
        public string? Email { get; set; }
        public DateTime FechaCrea { get; set; }
        public DateTime FechaMod {  get; set; }
        public bool Estado { get; set; }

    }
}
