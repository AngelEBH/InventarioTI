using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventarioTIModelo.Seguridad
{
    public class UsuarioModel
    {
        public int Id { get; set; }
        public int IdUsuario { get; set; }
        public string Usuario { get; set; }
        public string NombreUsuario { get; set; }
        public string FechaCreacion { get; set; }
        public string UsuarioCreacion { get; set; }
        public string FechaModificacion { get; set; }
        public string UsuarioModificacion { get; set; }
        public string Estado { get; set; }
        public string Contraseña { get; set; }
    }
}
