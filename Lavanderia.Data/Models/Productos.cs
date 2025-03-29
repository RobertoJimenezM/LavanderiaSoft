using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lavanderia.Data.Models
{
    [Table("Productos")]
    public class Productos
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ProductoId { get; set; }
        public string? Nombre { get; set; }
        public string? Descripcion { get; set; }
        [Column(TypeName = "decimal(10,2)")]
        public decimal Precio { get; set; }
        public DateTime FechaCrea { get; set; }
        public DateTime FechaMod {  get; set; }
        public bool Estado { get; set; }
        public virtual ICollection<OrdenesDetails> OrdenesDetails { get; set; } = new List<OrdenesDetails>();


    }
}
