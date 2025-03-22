using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Net.Cache;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Lavanderia.Data.Models
{
    [Table("Clientes")]
    public class Clientes
    {

        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ClienteId { get; set; }
        public Guid Identificador { get; set; }
        //[Required]
        //[MaxLength(65)]
        public required string Nombre { get; set; }
        [MaxLength(15)]
        public string? Identificacion { get; set; }
        //[MaxLength(15)]
        public string? Telefono { get; set; }
        //[MaxLength(255)]
        [EmailAddress(ErrorMessage ="Debe ser una direccion de Email valido")]
        public string? Email { get; set; }
        //[Required]
        //[MaxLength(255)]
        public required string Direccion { get; set; }
        public DateTime FechaCrea { get; set; }
        public DateTime FechaMod { get; set; }
        public bool Activo { get; set; }


    }
}
