﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Venta.Applicacion.CasosUso.ConsultarProductos
{
    public class ConsultarProductosRequest : IRequest<ConsultarProductosResponse>
    {
        public string FiltroPorNombre { get; set; }
    }
}