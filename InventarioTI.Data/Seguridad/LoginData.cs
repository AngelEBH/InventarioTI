using conexion.conexion.datos;
using InventarioTIModelo.Seguridad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventarioTI.Data.Seguridad
{ 
    public class LoginData
    {
        BD_INV_ACTIVOSEntities entity = new BD_INV_ACTIVOSEntities();
        //SistemaActivosFijosEntities entity = new SistemaActivosFijosEntities();
        public LoginModel LoginAccessData(LoginModel login)
        {
            try
            {
                var data = (from u in entity.USUARIO
                             where u.USUARIO1 == login.Usuario.Trim() && u.CONTRASENIA == login.contrasenia.Trim()
                             select new LoginModel()
                             {
                                 Usuario = u.USUARIO1,
                                 contrasenia = u.CONTRASENIA,
                                 Estado = u.ESTADO
                             }).FirstOrDefault();

                 return data;
            }
            catch (Exception err)
            {
                Console.WriteLine(err);
                return null;
            }
        }
    }
}
