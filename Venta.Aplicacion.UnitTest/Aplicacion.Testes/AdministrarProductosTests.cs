using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Venta.Applicacion.CasosUso.ConsultarProductos;
using Venta.Dominio.Repositorios;

namespace Venta.Aplicacion.UnitTest.Aplicacion.Testes
{

    public class AdministrarProductosTests
    {
        private readonly IProductoRepository _productoRepository;
        private readonly IMapper _mapper;
        private readonly ConsultarProductosHandler _consultarProductosHandler;

        [Fact]
        public async Task ConsultarProductos()
        {

        }
    }
}
