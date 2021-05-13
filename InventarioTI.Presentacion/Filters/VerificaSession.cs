using InventarioTI.Presentacion.Controllers;
using InventarioTIModelo.Seguridad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using static InventarioTIModelo.Seguridad.SeguridadModel;

namespace InventarioTI.Presentacion.Filters
{
    public class VerificaSession : ActionFilterAttribute
    {
        private LoginModel oUsuario;
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            try
            {
                base.OnActionExecuting(filterContext);

                oUsuario = (LoginModel)HttpContext.Current.Session["User"];
                if (oUsuario == null)
                {

                    if (filterContext.Controller is LoginController == false)
                    {
                        filterContext.HttpContext.Response.Redirect("/Login/Login");
                    }

                }

            }
            catch (Exception)
            {
                filterContext.Result = new RedirectResult("~/Login/Login");
            }

        }
    }
}
