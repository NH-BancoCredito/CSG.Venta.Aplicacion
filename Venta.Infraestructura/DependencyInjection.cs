using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Venta.Dominio.Repositorios;
using Venta.Infraestructura.Repositories;
using Venta.Infraestructura.Repositories.Base;

namespace Venta.Infraestructura
{
    public static class DependencyInjection
    {
        public static void AddInfraestructura(
          this IServiceCollection services,
          string connectionString
          )
        {
            services.AddDbContext<VentaDbContext>(
                    options => options.UseSqlServer(connectionString)
                );
            services.AddRepositories();
        }

        public static void AddRepositories(this IServiceCollection services)
        {
            services.AddScoped<IProductoRepository, ProductoRepository>();
            services.AddScoped<IVentaAplicacionRepository, VentaRepository>();
        }
    }
}
