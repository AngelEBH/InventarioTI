using InventarioTI.Data.Seguridad;
using InventarioTIModelo.Seguridad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace InventarioTI.Logica.Seguridad
{
    public class UsuarioLogica
    {
        UsuarioData data = new UsuarioData();
        public List<UsuarioModel> GetAllUsersLogica()
        {
            return data.GetAllUsersData();
        }

        public HttpStatusCode PostUsuarioLogica(UsuarioModel usuario)
        {
            return data.PostUsuarioData(usuario);
        }

        public HttpStatusCode PutUsuarioLogica(UsuarioModel usuario)
        {
            try
            {
                data.PutUsuarioData(usuario);
                return HttpStatusCode.OK;
            }
            catch(Exception e)
            {
                return HttpStatusCode.BadRequest;
            }
            
        }

        public HttpStatusCode DeleteUsuarioLogica(int Id)
        {
            try
            {
                data.DeleteUsuarioData(Id);
                return HttpStatusCode.OK;
            }
            catch (Exception e)
            {
                return HttpStatusCode.BadRequest;
            }

        }

        public UsuarioModel GetUserByIdLogica (int Id)
        {
            try
            {
                return data.GetUserByIdData(Id);
            }
            catch(Exception e)
            {
                Console.WriteLine(e);
                return null;
            }
            
        }
    }
}
