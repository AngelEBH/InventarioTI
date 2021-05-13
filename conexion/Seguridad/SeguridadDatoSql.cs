using conexion.conexion.datos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static InventarioTIModelo.Seguridad.SeguridadModel;

namespace conexion.Seguridad
{
   public  class SeguridadDatoSql
    {
        //BD_INV_ACTIVOSEntities
        public Usuario GetUsuario(string Usuario, string Pass)
        {
            try
            {
                using(var db = new BD_INV_ACTIVOSEntities())
                {
                    var oUser = (from d in db.USUARIO where d.USUARIO1 == Usuario.Trim() && d.CONTRASENIA == Pass.Trim()
                                 select d).FirstOrDefault();
                    Usuario Usuarioid = new Usuario
                    {
                        Id = oUser.ID,
                        User = oUser.USUARIO1,
                        //Estado = oUser.ESTADO,
                        Contraseña = oUser.CONTRASENIA

                    };
               
                    return Usuarioid;
                }
              
            }
            catch (Exception err)
            {
                Console.WriteLine(err);
                throw;
            }

        }

    }
}
