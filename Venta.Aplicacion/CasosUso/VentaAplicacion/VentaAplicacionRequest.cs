using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Venta.Aplicacion.CasosUso.VentaAplicacion
{
    public class VentaDetalleAplicacionRequest
    {
        public int IdProducto { get; set; }

        public int Cantidad { get; set; }

        public int Precio { get; set; }
    }

    public class VentaAplicacionRequest
    {

        public int IdCliente { get; set; }

        public IEnumerable<VentaDetalleAplicacionRequest> Productos { get; set; }

    }
}
