using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Venta.Dominio.Models;
using Venta.Dominio.Repositorios;
using Venta.Infraestructura.Repositories.Base;

namespace Venta.Infraestructura.Repositories
{
    public class ProductoRepository : IProductoRepository
    {
        private readonly VentaDbContext _ventaDbContext;
        public ProductoRepository(VentaDbContext ventaDbContext)
        {
            _ventaDbContext = ventaDbContext;
        }

        public Task<bool> Adicionar(Producto entity)
        {
            throw new NotImplementedException();
        }

        public Task<Producto> Consultar(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Producto>> Consultar(string nombre)
        {
            return await _ventaDbContext.Productos.Include(p => p.Categoria).ToListAsync();
        }

        public Task<Producto> ConsultarPorId(int id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Eliminar(Producto entity)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Modificar(Producto entity)
        {
            throw new NotImplementedException();
        }
    }
}
