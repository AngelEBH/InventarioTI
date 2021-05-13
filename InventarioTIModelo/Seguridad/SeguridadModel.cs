using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventarioTIModelo.Seguridad
{
    public class SeguridadModel
    {

        public class Usuario
        {
            public int Id { get; set; }
            public string User { get; set; }
            public bool? Estado { get; set; }
            public string Contraseña { get; set; }
            public int? IdRol { get; set; }

        }

    }
}
