using AutoMapper;
using Lavanderia.Data.Dtos.ClienteDto;
using Lavanderia.Data.Dtos.OrdenDto;
using Lavanderia.Data.Dtos.OrderDetailsDto;
using Lavanderia.Data.Dtos.ProductoDto;
using Lavanderia.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lavanderia.Bussines.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Clientes, ClienteDto>().ReverseMap();

            CreateMap<Productos, ProductoDto>().ReverseMap();
            CreateMap<Ordenes, OrdenDto>().ReverseMap();
            CreateMap<OrdenesDetails, OrderDetailsDto>().ReverseMap();
        }
    }
}
