using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Venta.Dominio.Repositorios
{
    public interface IVentaAplicacionRepository
    {
        Task<bool> Registrar(Models.Venta venta);
    }
}
