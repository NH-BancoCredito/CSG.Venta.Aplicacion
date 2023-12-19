using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Venta.Dominio.Repositorios;
using Venta.Infraestructura.Repositories;

namespace Venta.Infraestructura
{
    public static class DependencyInjection
    {
        public static void AddInfraestructura(
          this IServiceCollection services
          )
        {
            services.AddRepositories();
        }

        public static void AddRepositories(this IServiceCollection services)
        {
            services.AddScoped<IProductoRepository, ProductoRepository>();
            services.AddScoped<IVentaAplicacionRepository, VentaRepository>();
        }
    }
}
