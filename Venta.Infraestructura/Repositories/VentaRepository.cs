using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Venta.Dominio.Repositorios;

namespace Venta.Infraestructura.Repositories
{
    public class VentaRepository : IVentaAplicacionRepository
    {
        public Task<bool> Registrar(Dominio.Models.Venta venta)
        {
            throw new NotImplementedException();
        }
    }
}
