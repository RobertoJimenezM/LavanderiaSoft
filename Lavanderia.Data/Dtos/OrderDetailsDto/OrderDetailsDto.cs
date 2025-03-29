using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lavanderia.Data.Dtos.OrdenDto;
using Lavanderia.Data.Dtos.ProductoDto;

namespace Lavanderia.Data.Dtos.OrderDetailsDto
{
    public class OrderDetailsDto
    {
        public int OrdenDetailId { get; set; }
        public int OrdenId { get; set; }
        public int ProductoId { get; set; }
        public int Cantidad { get; set; }
        public decimal PrecioUnitario { get; set; }
        public decimal Subtotal { get; set; }
        public bool Estado { get; set; }

        public virtual ProductoDto.ProductoDto ProductoDto { get; set; }
        public virtual OrdenDto.OrdenDto OrdenDto {  get; set; } 
    }
}
