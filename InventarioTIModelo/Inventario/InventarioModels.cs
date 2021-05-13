using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InventarioTI.Presentacion.Models.Inventario
{
    public class InventarioModels
    {
        public int ID_DEPTO { get; set; }
        public int NUMERO_REFERENCIA { get; set; }
        public string CODIGO_INVENTARIO { get; set; }
        public string CODIGO_NUEVO { get; set; }
        public string FECHA_COMPRA { get; set; }
        public string MES_DEPRECIACION { get; set; }
        public int ID_PROVEEDOR { get; set; }
        public int ID_TIPO_EQUIPO { get; set; }
        public int ID_MARCA { get; set; }
        public string COLOR { get; set; }
        public string MODELO { get; set; }
        public string NUMERO_SERIE { get; set; }
        public string TIPO_PROCESADOR { get; set; }
        public string DISQUETERA { get; set; }
        public string LECTOR_DVD { get; set; }
        public string LECTOR_SD_MMC { get; set; }
        public string PARLANTES_EXTERNOS { get; set; }
        public string MONITOR_COLOR { get; set; }
        public string MONITOR_SERIE { get; set; }
        public string MONITOR_TAMANIO { get; set; }
        public string MONITOR_TIPO { get; set; }
        public string TECLADO_COLOR { get; set; }
        public string TECLADO_MODELO { get; set; }
        public string MOUSE_COLOR { get; set; }
        public string UBICACION { get; set; }
        public int ID_EMPLEADO { get; set; }
        public string CONDICION_ACTUAL { get; set; }
        public string USUARIO_RESPONSABLE { get; set; }
        public string ESTADO { get; set; }
        public string Extra { get; set; }



        public string DESCRIPCION_DEPTO { get; set; }
        public string NOMBRE_PROVEEDOR { get; set; }
        public string DESCRIPCION { get; set; }
        public string MARCA { get; set; }
        public string NOMBRE_EMPLEADO { get; set; }
        public string NOMBRE_DEPTO { get; set; }


    }
    public class TipoEquipo
    {
        public int ID_TIPO_EQUIPO { get; set; }
        public string DESCRIPCION { get; set; }
    }
    public class Departamento
    {
        public int ID_DEPTO { get; set; }
        public string NOMBRE_DEPTO { get; set; }

    }
    public class Marca
    {
        public int ID_MARCA { get; set; }
        public string DESCRIPCION { get; set; }
        //public int ID_CONTROL { get; set; }


    }
    public class Proveedor
    {
        public int ID_PROVEEDOR { get; set; }
        public string NOMBRE_PROVEEDOR { get; set; }
    }
    public class Empleado
    {
        public int ID_EMPLADO { get; set; }
        public string NOMBRE_EMPLEADO { get; set; }
    }
}