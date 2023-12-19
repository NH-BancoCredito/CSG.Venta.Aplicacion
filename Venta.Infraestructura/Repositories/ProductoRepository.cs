using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Venta.Dominio.Models;
using Venta.Dominio.Repositorios;

namespace Venta.Infraestructura.Repositories
{
    public class ProductoRepository : IProductoRepository
    {
        public Task<bool> Adicionar(Producto entity)
        {
            throw new NotImplementedException();
        }

        public Task<Producto> Consultar(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Producto>> Consultar(string nombre)
        {
            throw new NotImplementedException();
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
