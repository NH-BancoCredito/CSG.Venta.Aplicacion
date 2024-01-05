using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Venta.Dominio.Repositorios;
using Venta.Infraestructura.Repositories.Base;

namespace Venta.Infraestructura.Repositories
{
    public class VentaRepository : IVentaAplicacionRepository
    {
        private readonly VentaDbContext _context;
        public VentaRepository(VentaDbContext context)
        {
            _context = context;
        }
        public async Task<bool> Registrar(Dominio.Models.Venta venta)
        {
            _context.Ventas.Add(venta);

            await _context.SaveChangesAsync(); //INSERT VENTA() VALUES(.....)

            return venta.IdVenta > 0;
        }
    }
}
