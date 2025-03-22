using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lavanderia.Data.Models
{
    [Table("Facturas")]
    public class Facturas
    {
        [Key,DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int FacturaId { get; set; }
        public int OrdenId { get; set; }
        public string? Ruta {  get; set; }
        public DateTime FechaCrea { get; set; }
        public DateTime FechaMod {  get; set; }
        public bool Estado { get; set; }

    }
}
