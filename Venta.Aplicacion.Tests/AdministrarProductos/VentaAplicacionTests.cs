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
            var request = ingresarVentaAplicacionRequest();

            var objProducto = new Producto() { IdProducto = 2, Stock = 30, StockMinimo = 1 };

            _productoRepository.ConsultarPorId(default(int)).ReturnsForAnyArgs(objProducto);
            _ventaAplicacionRepository.Registrar(default).ReturnsForAnyArgs(true);

            var resultado = await _ventaAplicacionHandler.Handle(request);

            Assert.True(resultado.VentaRegistrada);


        }
        private VentaAplicacionRequest ingresarVentaAplicacionRequest()
        {
            var registrarVentaDetalleRequest = new List<VentaDetalleAplicacionRequest>();
            for (int i = 0; i < 5; i++)
            {
                registrarVentaDetalleRequest.Add(new VentaDetalleAplicacionRequest() { Cantidad = i + 1, IdProducto = i + 2, Precio = i + 5 });
            }
            var registrarVentaRequest = new VentaAplicacionRequest() { IdCliente = 2, Productos = registrarVentaDetalleRequest };
            return registrarVentaRequest;
        }
    }
}
