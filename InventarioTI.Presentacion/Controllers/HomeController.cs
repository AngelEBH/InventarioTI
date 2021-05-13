using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;

namespace InventarioTI.Presentacion.Controllers
{
    public class HomeController : Controller
    {
        [OutputCache(Location = OutputCacheLocation.None, NoStore = true)]
        public ActionResult Inicio()
        {
            return View();
        }

        [OutputCache(Location = OutputCacheLocation.None, NoStore = true)]
        public ActionResult LogOut()
        {
            Session["UserName"] = null;
            Session["User"] = null;
            return RedirectToAction("Login", "Login");
        }
    }
}