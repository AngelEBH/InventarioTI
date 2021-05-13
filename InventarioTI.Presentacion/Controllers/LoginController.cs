
using InventarioTI.Logica.Seguridad;
using InventarioTIModelo.Seguridad;
using System;
using System.Threading.Tasks;
using System.Web.Mvc;
using System.Web.UI;

namespace InventarioTI.Presentacion.Controllers
{
    public class LoginController : Controller
    {

        LoginLogica logica = new LoginLogica();
        [OutputCache(Location = OutputCacheLocation.None, NoStore = true)]
        public ActionResult Login()
        {
            if(Session["UserName"] !=null)
            {
                
                return RedirectToAction("Inicio", "Home");
            }
            else
            {
                return View();
            }
            
        }

        [HttpPost]
        public ActionResult PostLogin(LoginModel loginModel)
        {
            //Not Found 404, Found 302
            int Status = 302;
            var model = logica.GetUsuario(loginModel);
            if(model == null)
            {
                Status = 404;
                
            }
            else
            {
                Session["UserName"] = model.Usuario;
            }

            Session["User"] = model;

            return Json(Status, JsonRequestBehavior.AllowGet);

            //return RedirectToAction("Inicio", "Home");

        }

    }
}