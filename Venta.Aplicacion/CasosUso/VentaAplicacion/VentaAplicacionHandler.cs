using AutoMapper;
using MediatR;
using System.Reflection;
using Venta.Aplicacion.Common;
using Venta.Dominio.Repositorios;
using Models = Venta.Dominio.Models;

namespace Venta.Aplicacion.CasosUso.VentaAplicacion
{
    public class VentaAplicacionHandler : IRequestHandler<VentaAplicacionRequest, IResult>
    {
        private readonly IVentaAplicacionRepository _ventaAplicacionRepository;
        private readonly IProductoRepository _productoRepository;
        private readonly IMapper _mapper;

        public VentaAplicacionHandler(IVentaAplicacionRepository ventaAplicacionRepository, IProductoRepository productoRepository, IMapper mapper)
        {
            _ventaAplicacionRepository = ventaAplicacionRepository;
            _productoRepository = productoRepository;
            _mapper = mapper;
        }

        public async Task<IResult> Handle(VentaAplicacionRequest request, CancellationToken cancellationToken)
        {
            IResult response = null;

            //var response = new RegistrarVentaResponse();

            var validator = new VentaAplicacionValidator();
            var validationResult = validator.Validate(request);
            if (!validationResult.IsValid)
            {
                return new FailureResult<DetailError>(new DetailError("00'", validationResult.ToString("/")));

            }


            //Aplicando el automapper para convertir el objeto Request a venta dominio
            var venta = _mapper.Map<Models.Venta>(request);

            ///============Condiciones de validaciones


            foreach (var detalle in venta.Detalle)
            {
                //1 - Validar si el productos existe
                var productoEncontrado = await _productoRepository.Consultar(detalle.IdProducto);
                if (productoEncontrado?.IdProducto <= 0)
                {
                    throw new Exception($"Producto no encontrado, código {detalle.IdProducto}");
                }



                //2 - Validar si existe stock suficiente - TODO

                //3 - Reservar el stock del producto - TODO
                //3.1 --Si sucedio algun erro al reservar el producto , retornar una exepcion
            }

            /// SI todo esta OK
            /// Registrar la venta - TODO
            /// 
            await _ventaAplicacionRepository.Registrar(venta);

            response = new SuccessResult<int>(venta.IdVenta);

            return response;
        }
    }
}