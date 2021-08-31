using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Aplicacion_de_asp.Controllers
{
    public class Reporte
    {
        public string nombreProveedor { get; set; }
        public string direccionProveedor { get; set; }
        public string telefonoProveedor { get; set; }
        public string nombreProducto { get; set; }
        public int PrecioProducto { get; set; }
    }
}