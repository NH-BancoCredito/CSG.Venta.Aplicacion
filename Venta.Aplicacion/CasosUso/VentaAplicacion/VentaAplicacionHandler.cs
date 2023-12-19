using AutoMapper;
using System.Reflection;
using Venta.Dominio.Repositorios;
using Models = Venta.Dominio.Models;

namespace Venta.Aplicacion.CasosUso.VentaAplicacion
{
    public class VentaAplicacionHandler
    {
        private readonly IVentaAplicacionRepository _ventaRepository;
        private readonly IProductoRepository _productoRepository;
        private readonly IMapper _mapper;

        public VentaAplicacionHandler(IVentaAplicacionRepository ventaRepository, IProductoRepository productoRepository, IMapper mapper)
        {
            _ventaRepository = ventaRepository;
            _productoRepository = productoRepository;
            _mapper = mapper;
        }

        public async Task<VentaAplicacionResponse> Registrar(VentaAplicacionRequest request)
        {
            var response = new VentaAplicacionResponse();

            //Aplicando el automapper para convertir el objeto Request a venta dominio
            var venta = _mapper.Map<Models.Venta>(request);

            ///============Condiciones de validaciones


            foreach (var detalle in venta.Detalle)
            {
                //1 - Validar si el productos existe
                var productoEncontrado = await _productoRepository.Consultar(detalle.IdProducto);
                if (productoEncontrado?.IdProducto <= 0)
                    throw new Exception($"Producto no encontrado, código {detalle.IdProducto}");

                //2 - Validar si existe stock suficiente - TODO
                if (detalle.Cantidad > productoEncontrado.Stock)
                    throw new Exception($"El producto {detalle.IdProducto} no tiene stock, solo hay en almacen {detalle.Cantidad}");

                //3 - Reservar el stock del producto - TODO
                if (detalle.Cantidad < productoEncontrado.StockMinimo)
                    throw new Exception($"El producto {detalle.IdProducto} no cumple con el stock mínimo de {productoEncontrado.StockMinimo}");

                detalle.Producto = productoEncontrado;
                //3.1 --Si sucedio algun erro al reservar el producto , retornar una exepcion

                if(detalle == null)
                    throw new Exception($"Error al reservar");

            }

            /// SI todo esta OK
            /// Registrar la venta - TODO
            /// 
            if (!(await _ventaRepository.Registrar(venta)))
            {
                throw new Exception($"Error al registrar venta, código {venta.IdVenta}");
            }
            response.VentaRegistrada = true;


            return response;
        }
    }
}