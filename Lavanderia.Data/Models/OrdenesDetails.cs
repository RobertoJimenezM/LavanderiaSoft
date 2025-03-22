using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lavanderia.Data.Models
{
    [Table("OrdenesDetails")]   
    
    public class OrdenesDetails
    {
        [Key,DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int OrdenDetailId { get; set; }
        public int OrdenId { get; set; }
        public int ProductoId { get; set; }
        public int Cantidad { get; set; }
        [Column(TypeName ="decimal(10,2)")]
        public decimal PrecioUnitario { get; set; }
        [Column(TypeName = "decimal(10,2)")]
        public decimal Subtotal { get; set; }
        public bool Estado { get; set; }
    }
}
