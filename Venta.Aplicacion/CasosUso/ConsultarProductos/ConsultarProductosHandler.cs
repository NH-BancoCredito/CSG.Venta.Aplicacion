﻿using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Venta.Dominio.Repositorios;

namespace Venta.Applicacion.CasosUso.ConsultarProductos
{
    public class ConsultarProductosHandler : IRequestHandler<ConsultarProductosRequest, ConsultarProductosResponse>
    {
        private readonly IProductoRepository _productoRepository;
        private readonly IMapper _mapper;

        public ConsultarProductosHandler(IProductoRepository productoRepository, IMapper mapper)
        {
            _productoRepository = productoRepository;
            _mapper = mapper;
        }

        public async Task<ConsultarProductosResponse> Handle(ConsultarProductosRequest request, CancellationToken cancellationToken)
        {
            var response = new ConsultarProductosResponse();

            var datos = await _productoRepository.Consultar(request.FiltroPorNombre);

            response.Resultado = _mapper.Map<IEnumerable<ConsultaProducto>>(datos);


            return response;
        }
    }
}