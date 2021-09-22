using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Aplicacion_de_asp.Models
{
    public class UsuarioIndex: BaseModelo
    {
        public List<usuario> Usuarios { get; set; }
    }
}