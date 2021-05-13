using InventarioTI.Data;
using InventarioTI.Data.InventarioD;
using InventarioTI.Presentacion.Models.Inventario;
using InventarioTIModelo.Inventario;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventarioTI.Logica
{ 
    public  class InventarioLogica

    {
         InventarioData datosSql = new InventarioData();
        InventarioEquipoDatos datos = new InventarioEquipoDatos();


        public List<InventarioM> ListaInventario()
        {
            return datosSql.ListaInventario();
        }

        public InventarioM obtenerMarcar(int id)
        {
            return datosSql.ObetenerMarca(id);
        }

        public int InsertarInventarioEquipoI(int Departamento, string codigoInventario, DateTime FechaCompra, DateTime MesDEpreciacion, int Proveedor, int tipoEquipo, int Marca,
                                     string Color, string Modelo, string Nserie, string TProcesador, string Disquetera, string Lector_dvd, string Lector_sd_mmc, string Parlanntes_Externos,
                                      string Monitor_Color, string Monitor_Serie, string Monitor_tamanio, string Monitor_Tipo, string TecladoColor, string TecladoModelo, string MouseColor, string Ubicacion,
                                      int Empleado, string CondicionActual, string UsuarioResponsable, string Estado)
        {




            return datos.InsertarInventarioEquipoI(Departamento, codigoInventario, FechaCompra, MesDEpreciacion, Proveedor, tipoEquipo, Marca, Color,
                     Modelo, Nserie, TProcesador, Disquetera, Lector_dvd, Lector_sd_mmc, Parlanntes_Externos, Monitor_Color, Monitor_Serie, Monitor_tamanio, Monitor_Tipo,
                     TecladoColor, TecladoModelo, MouseColor, Ubicacion, Empleado, CondicionActual, UsuarioResponsable, Estado);



        }

        public List<InventarioModels> ListaMobiliarioEI()
        {
            return datos.ListaMobiliarioEI();
        }
        public int EliminarEi(string CodigoInventario)
        {
            return datos.EliminarEi(CodigoInventario);
        }

        public InventarioModels ObtenerTomaInformatica(string CODIGO_INVENTARIO)
        {
            return datos.ObtenerTomaInformatica(CODIGO_INVENTARIO);
        }

        public int GuardarDatos(string UsrRes, string FechaTomaInventario, string CodigoInventario
                                )
        {
            DateTime Fecha = Convert.ToDateTime(FechaTomaInventario);
            return datos.InsertarTomarInventario(UsrRes, Fecha, CodigoInventario);
        }
    }
}
