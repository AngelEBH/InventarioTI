using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using System.Net;
using InventarioTI.Presentacion.Models;
using System.Text;
using System.Web.Script.Serialization;
using InventarioTI.Logica;
using InventarioTI.Data;

namespace InventarioTI.Presentacion.Controllers
{
    public class InventarioController : Controller
    {
        InventarioLogica logica = new InventarioLogica();
        InventarioEquipoDatos datos = new InventarioEquipoDatos();

        private readonly IEnumerable<Producto> productos;

        public InventarioController()
        {
            this.productos = Enumerable.Range(1, 10).Select(x => new Producto { id = x, nombre = $"Producto {x}" });
        }
        [HttpGet]
        public ActionResult editar(int? id)
        {

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest, "el parametro id es necesario");
            }

            // logica de la db

            var producto = this.productos.FirstOrDefault(x => x.id == id);

            return View(producto);
        }
        public ActionResult listarProductos()
        {
            return new JsonResult { Data = new { data = this.productos }, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult MostrarDatos()
        {
            return View();
        }
        public ActionResult TomaInventarioInformatica()
        {
          
            return View();
        }
        public ActionResult Indicadores()
        {
            return View();
        }

        public JsonResult MostrarMarca()
        {
            var solicitudes = logica.ListaInventario();
            
            return new JsonResult
            {
                Data = solicitudes,
                ContentType = "application/json",
                ContentEncoding = Encoding.Default,
                MaxJsonLength = Int32.MaxValue,
                JsonRequestBehavior = JsonRequestBehavior.AllowGet

            };
        }
        public JsonResult MostrarInventarioEI()
        {
            var solicitudes = logica.ListaMobiliarioEI();
            var serializer = new JavaScriptSerializer();
            serializer.MaxJsonLength = Int32.MaxValue;
            return new JsonResult
            {
                Data = solicitudes,
                ContentType = "application/json",
                ContentEncoding = Encoding.Default,
                MaxJsonLength = Int32.MaxValue,
                JsonRequestBehavior = JsonRequestBehavior.AllowGet
            };
        }
        public ActionResult IngresarInventario()
        {
            ViewBag.Marca = datos.Marca();
            ViewBag.Departamento = datos.Departamento();
            ViewBag.Proveedor = datos.Proveedor();
            ViewBag.Empleado = datos.Empleado();
            ViewBag.TipoEquipo = datos.TipoEquipo();
            
            return View();
        }
   
    

        public int InsertarInventarioEquipo(int Departamento, string codigoInventario, DateTime FechaCompra, DateTime MesDEpreciacion, int Proveedor, int tipoEquipo, int Marca,
                                        string Color, string Modelo, string Nserie, string TProcesador, string Disquetera, string Lector_dvd, string Lector_sd_mmc, string Parlanntes_Externos,
                                         string Monitor_Color, string Monitor_Serie, string Monitor_tamanio, string Monitor_Tipo, string TecladoColor, string TecladoModelo, string MouseColor, string Ubicacion,
                                         int Empleado, string CondicionActual, string UsuarioResponsable, string Estado)

        {
            var insert = logica.InsertarInventarioEquipoI(Departamento, codigoInventario, FechaCompra, MesDEpreciacion, Proveedor, tipoEquipo, Marca, Color,
            Modelo, Nserie, TProcesador, Disquetera, Lector_dvd, Lector_sd_mmc, Parlanntes_Externos, Monitor_Color, Monitor_Serie, Monitor_tamanio, Monitor_Tipo,
              TecladoColor, TecladoModelo, MouseColor, Ubicacion, Empleado, CondicionActual, UsuarioResponsable, Estado
           );
            return insert;
            
        }

        public int GenerarCodigoInventario(int Departamento)
        {
            var generar = datos.GenerarCodigoInventario(Departamento);
            return generar;
        }
        public ActionResult ObtenerTomaInformatica(string Codigo)
        {
            return Json(logica.ObtenerTomaInformatica(Codigo), JsonRequestBehavior.AllowGet);
        }
        public int EliminarEi(string CodigoInventario)
        {
            return logica.EliminarEi(CodigoInventario);
        }
        public int guardarDatos(string UsrRes, string FechaTomaInventario, string CodigoInventario)
        {
            return logica.GuardarDatos(UsrRes, FechaTomaInventario, CodigoInventario);
        }

    }

}