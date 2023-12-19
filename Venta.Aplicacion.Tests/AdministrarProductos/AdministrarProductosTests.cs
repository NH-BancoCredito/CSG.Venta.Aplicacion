using AutoMapper;
using NSubstitute;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Venta.Applicacion.CasosUso.ConsultarProductos;
using Venta.Dominio.Models;
using Venta.Dominio.Repositorios;

namespace Venta.Aplicacion.Tests.AdministrarProductos
{

    public class AdministrarProductosTests
    {
        private readonly IProductoRepository _productoRepository;
        private readonly IMapper _mapper;
        private readonly ConsultarProductosHandler _consultarProductosHandler;

        public AdministrarProductosTests()
        {
            _productoRepository = Substitute.For<IProductoRepository>();
            _mapper = new MapperConfiguration(c => c.AddProfile<ConsultarProductosMapper>()).CreateMapper();
            _consultarProductosHandler = Substitute.For<ConsultarProductosHandler>(_productoRepository, _mapper);
        }

        [Fact]
        public async Task ConsultarProductos()
        {
            var request = new ConsultarProductosRequest() { FiltroPorNombre = "Pollo" };

            var listProductos = new List<Producto>() {
                new Producto() {
                    IdProducto = 1,
                    Nombre = "Pollo",
                    PrecioUnitario = 15,
                    Stock = 3,
                    StockMinimo = 5
                 },
                new Producto() {
                    IdProducto = 2,
                    Nombre = "Arroz",
                    PrecioUnitario = 15,
                    Stock = 3,
                    StockMinimo = 5
                 }
            };

            _productoRepository.Consultar(Arg.Any<string>()).ReturnsForAnyArgs(listProductos);

            var response = await _consultarProductosHandler.Handle(request);

            Assert.NotNull(response);
            Assert.True(response.Resultado.Count() > 0);
            Assert.Equal(request.FiltroPorNombre, response.Resultado.First().Nombre);
        }
    }
}
