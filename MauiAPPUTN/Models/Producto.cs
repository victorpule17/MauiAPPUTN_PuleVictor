﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiAPPUTN.Models
{
    class Producto
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public double Existencia { get; set; }
        public double PrecioUnitario { get; set; }
        public double IVA { get; set; }
        public int ClasificacionId { get; set; }
    }
}
