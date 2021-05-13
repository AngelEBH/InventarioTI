using InventarioTI.Data.Seguridad;
using InventarioTIModelo.Seguridad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventarioTI.Logica.Seguridad
{
    public class LoginLogica
    {
        LoginData data = new LoginData();
        public LoginModel GetUsuario(LoginModel login)
        {
            return data.LoginAccessData(login);
        }
    }
}
