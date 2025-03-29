using Lavanderia.Data.Dtos.OrderDetailsDto;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lavanderia.Data.Dtos.ProductoDto
{
    public class ProductoDto
    {
        public int ProductoId { get; set; }
        public string? Nombre { get; set; }
        public string? Descripcion { get; set; }
        public decimal Precio { get; set; }
        public virtual ICollection<OrderDetailsDto.OrderDetailsDto> orderDetails { get; set; } = new List<OrderDetailsDto.OrderDetailsDto>();
    }
}
