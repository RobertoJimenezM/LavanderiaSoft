using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lavanderia.Data.Models
{
    [Table("Pagos")]
    public class Pagos
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PagoId { get; set; }
        public int OrdenId { get; set; }
        [Column(TypeName = "decimal(10,2)")]
        public decimal Monto { get; set; }
        public string? MetodoDePago { get; set; }
        public DateTime FechaCrea { get; set; }
        public DateTime FechaMod { get; set; }
        public bool Estado { get; set; }

    }
}
