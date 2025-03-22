using Lavanderia.Data.Dtos.OrderDetailsDto;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks; 
namespace Lavanderia.Data.Dtos.OrdenDto
{
    public class OrdenDto
    {
        public int OrdenId { get; set; }
        public int ClienteId { get; set; }
        public bool Estado { get; set; }
        public decimal Total { get; set; }
        public virtual ICollection<OrderDetailsDto.OrderDetailsDto> OrderDetailsDtos { get; set; } = new List<OrderDetailsDto.OrderDetailsDto>();

    }
}
