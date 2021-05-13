using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InventarioTI.Presentacion.Models
{
    public class Producto
    {
        public int id { get; set; }

        public string nombre { get; set; }

        public int precio { get; set; }
    }
}