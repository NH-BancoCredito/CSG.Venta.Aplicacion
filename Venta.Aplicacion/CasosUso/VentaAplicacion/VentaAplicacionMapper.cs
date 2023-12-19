using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models = Venta.Dominio.Models;

namespace Venta.Aplicacion.CasosUso.VentaAplicacion
{
    public class VentaAplicacionMapper : Profile
    {
        public VentaAplicacionMapper()
        {
            CreateMap<VentaAplicacionRequest, Models.Venta>()
                .ForMember(dest => dest.Detalle, map => map.MapFrom(src => src.Productos));
            CreateMap<VentaDetalleAplicacionRequest, Models.VentaDetalle>();
        }
    }
}
