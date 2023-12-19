using AutoMapper;
using NSubstitute;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Venta.Aplicacion.CasosUso.VentaAplicacion;
using Venta.Dominio.Models;
using Venta.Dominio.Repositorios;

namespace Venta.Aplicacion.Tests.AdministrarProductos
{
    public class VentaAplicacionTests
    {
        private readonly IVentaAplicacionRepository _ventaAplicacionRepository;
        private readonly IProductoRepository _productoRepository;
        private readonly IMapper _mapper;
        private readonly VentaAplicacionHandler _ventaAplicacionHandler;

        public VentaAplicacionTests()
        {
            _mapper = new MapperConfiguration(c => c.AddProfile<VentaAplicacionMapper>()).CreateMapper();
            _ventaAplicacionRepository = Substitute.For<IVentaAplicacionRepository>();
            _productoRepository = Substitute.For<IProductoRepository>();
            _ventaAplicacionHandler = Substitute.For<VentaAplicacionHandler>(_ventaAplicacionRepository, _productoRepository, _mapper);
        }
        [Fact]
        public async Task RegistraVentas()
        {
            var request = setVentaRequest();

            var objProducto = new Producto() { IdProducto = 2, Stock = 30, StockMinimo = 1 };

            _productoRepository.ConsultarPorId(default(int)).ReturnsForAnyArgs(objProducto);
            _ventaAplicacionRepository.Registrar(default).ReturnsForAnyArgs(true);

            var resultado = await _ventaAplicacionHandler.Registrar(request);

            Assert.True(resultado.VentaRegistrada);


        }
        private VentaAplicacionRequest setVentaRequest()
        {
            var registrarVentaDetalleRequest = new List<VentaDetalleAplicacionRequest>();
            registrarVentaDetalleRequest.Add(new VentaDetalleAplicacionRequest() { Cantidad = 2, IdProducto = 3, Precio = 10 });
            registrarVentaDetalleRequest.Add(new VentaDetalleAplicacionRequest() { Cantidad = 4, IdProducto = 10, Precio = 30 });
            registrarVentaDetalleRequest.Add(new VentaDetalleAplicacionRequest() { Cantidad = 5, IdProducto = 7, Precio = 30 });
            var registrarVentaRequest = new VentaAplicacionRequest() { IdCliente = 2, Productos = registrarVentaDetalleRequest };
            return registrarVentaRequest;
        }
    }
}
