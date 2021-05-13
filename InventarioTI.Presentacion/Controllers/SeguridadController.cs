using InventarioTI.Logica.Seguridad;
using InventarioTIModelo.Seguridad;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;
using ActionResult = System.Web.Mvc.ActionResult;
using HttpDeleteAttribute = System.Web.Mvc.HttpDeleteAttribute;
using HttpGetAttribute = System.Web.Mvc.HttpGetAttribute;
using HttpPostAttribute = System.Web.Mvc.HttpPostAttribute;

namespace InventarioTI.Presentacion.Controllers
{
    public class SeguridadController : Controller
    {
        UsuarioLogica Logica = new UsuarioLogica();
        public string UserSeguridad;
        [OutputCache(Location = OutputCacheLocation.None, NoStore = true)]
        public ActionResult SeguridadUsuarios()
        {
            ViewBag.GetAllUsers = Logica.GetAllUsersLogica();
            return View();
        }

        public ActionResult AdminRoles()
        {
            return View();
        }
        public ActionResult Permisos()
        {
            return View();
        }

        [HttpPost]
        public HttpStatusCode PostUsuario(UsuarioModel usuarioModel)
        {
            if (Session["UserName"] != null)
            {
                UserSeguridad = System.Web.HttpContext.Current.Session["UserName"].ToString();
            }

            usuarioModel.UsuarioCreacion = UserSeguridad;
            usuarioModel.UsuarioModificacion = usuarioModel.UsuarioCreacion;
            
            return Logica.PostUsuarioLogica(usuarioModel);
        }

        public HttpStatusCode PutUsuario(UsuarioModel usuarioModel)
        {
            if (Session["UserName"] != null)
            {
                UserSeguridad = System.Web.HttpContext.Current.Session["UserName"].ToString();
            }

            usuarioModel.UsuarioModificacion = UserSeguridad;

            return Logica.PutUsuarioLogica(usuarioModel);
        }

        public ActionResult GetUsuario(int Id)
        {
            var getUser = Logica.GetUserByIdLogica(Id);
            return Json(getUser, JsonRequestBehavior.AllowGet);
        }

        public HttpStatusCode BorrarUsuario(int Id)
        {
            return Logica.DeleteUsuarioLogica(Id);
        }


    }
}