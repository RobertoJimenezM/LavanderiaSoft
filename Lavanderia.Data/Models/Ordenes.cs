using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lavanderia.Data.Models
{
    [Table("Ordenes")]
    public class Ordenes
    {
        [Key,DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int OrdenId { get; set; }
        public int ClienteId { get; set; }
        public DateTime FechaCrea { get; set; }
        public DateTime FechaMod { get; set; }
        public bool Estado { get; set; }
        [Column(TypeName = "decimal(10,2)")]
        public decimal Total { get; set; }
    }
}
