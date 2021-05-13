using conexion.conexion.datos;
using InventarioTI.Presentacion.Models.Inventario;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventarioTI.Data
{
   public class InventarioEquipoDatos
    {
        BD_INV_ACTIVOSEntities db =  new BD_INV_ACTIVOSEntities();
        int contador = 0;
        public int InsertarTomarInventario(string UsuarioResponsable, DateTime FechaTomaInventario, string CodigoInvetario)
        {

            //var query = db.InsertareTomaEI(UsuarioResponsable, FechaTomaInventario, CodigoInvetario);
            contador += 1;
            //return contador;
            return contador;
        }
        public List<TipoEquipo> TipoEquipo()
        {
            using (var db = new BD_INV_ACTIVOSEntities())
            {
                try
                {
                    return (
                            from c in db.TIPO_EQUIPO

                            select new TipoEquipo()
                            {
                                ID_TIPO_EQUIPO = c.ID_TIPO_EQUIPO,
                                DESCRIPCION = c.DESCRIPCION

                            }).ToList();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    return null;
                }

            }
        }

        public List<Departamento> Departamento()
        {
            using (var db = new BD_INV_ACTIVOSEntities())
            {
                try
                {
                    return (
                            from c in db.DEPTO

                            select new Departamento()
                            {

                                ID_DEPTO = c.ID_DEPTO,
                                NOMBRE_DEPTO = c.NOMBRE_DEPTO

                            }).ToList();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    return null;
                }

            }
        }
        public List<Proveedor> Proveedor()
        {
            using (var db = new BD_INV_ACTIVOSEntities())
            {
                try
                {
                    return (
                            from c in db.PROVEEDOR

                            select new Proveedor()
                            {

                                ID_PROVEEDOR = c.ID_PROVEEDOR,
                                NOMBRE_PROVEEDOR = c.NOMBRE_PROVEEDOR

                            }).ToList();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    return null;
                }

            }
        }
        public List<Marca> Marca()
        {
            using (var db = new BD_INV_ACTIVOSEntities())
            {
                try
                {
                    return (
                            from c in db.MARCAS
                           

                            select new Marca()
                            {
                               ID_MARCA = c.ID_MARCA,
                                DESCRIPCION = c.DESCRIPCION


                            }).ToList();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    return null;
                }

            }
        }
        public List<Empleado> Empleado()
        {
            using (var db = new BD_INV_ACTIVOSEntities())
            {
                try
                {
                    return (
                            from c in db.EMPLEADO

                            select new Empleado()
                            {

                                ID_EMPLADO = c.ID_EMPLEADO,
                                NOMBRE_EMPLEADO = c.NOMBRE_EMPLEADO

                            }).ToList();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    return null;
                }

            }

        }

        public int GenerarCodigoInventario(int Departamento)
        {
            int correlativo = 0;

            try
            {

                using (var db = new BD_INV_ACTIVOSEntities())
                {
                    var q = (from c in db.DETALLE_CONTROL_EI select c).Count();
                    correlativo = q + 1;
                }

            }
            catch (Exception err)
            {
                Console.WriteLine(err);
            }
            return correlativo;
        }



        public int InsertarInventarioEquipoI(int idDEpto, string codigoInventario, DateTime FechaCompra, DateTime MesDEpreciacion, int Proveedor, int tipoEquipo, int Marca,
           string Color, string Modelo, string Nserie, string TProcesador, string Disquetera, string Lector_dvd, string Lector_sd_mmc, string Parlanntes_Externos,
            string Monitor_Color, string Monitor_Serie, string Monitor_tamanio, string Monitor_Tipo, string TecladoColor, string TecladoModelo, string MouseColor, string Ubicacion,
            int Empleado, string CondicionActual, string UsuarioResponsable, string Estado 
            )
        {
			int cuenta = 0;

            try
            {
                using (var db = new BD_INV_ACTIVOSEntities())
                {
                    var q = (from c in db.DETALLE_CONTROL_EI select c).Count();
                    cuenta = q + 1;
                }
            }
            catch { }
            try
            {
			

				using (var db = new BD_INV_ACTIVOSEntities())
                {
                    var query = db.INSERT_INVENTARIO_INFORMATICA(idDEpto, cuenta, codigoInventario, FechaCompra, MesDEpreciacion, Proveedor, tipoEquipo, Marca, Color,
                     Modelo, Nserie, TProcesador, Disquetera, Lector_dvd, Lector_sd_mmc, Parlanntes_Externos, Monitor_Color, Monitor_Serie, Monitor_tamanio, Monitor_Tipo,
                     TecladoColor, TecladoModelo, MouseColor, Ubicacion, Empleado, CondicionActual, UsuarioResponsable, Estado);
                }
                return 1;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return 0;
            }
            
        }
        public List<InventarioModels> ListaMobiliarioEI()
        {
            using (var db = new BD_INV_ACTIVOSEntities())
            {
                try
                {
                    return (
                            from c in db.DETALLE_CONTROL_EI
                            join d in db.PROVEEDOR on c.ID_PROVEEDOR equals d.ID_PROVEEDOR
                            join e in db.MARCAS on c.ID_MARCA equals e.ID_MARCA
                            join f in db.TIPO_EQUIPO on c.ID_TIPO_EQUIPO equals f.ID_TIPO_EQUIPO
                            join b in db.DEPTO on c.ID_DEPTO equals b.ID_DEPTO
                            select new InventarioModels()
                            {
                                NOMBRE_DEPTO = b.NOMBRE_DEPTO,
                                NUMERO_REFERENCIA = c.NUMERO_REFERENCIA,
                                CODIGO_INVENTARIO = c.CODIGO_INVENTARIO,
                              
                                FECHA_COMPRA = c.FECHA_COMPRA.ToString(),
                                MES_DEPRECIACION = c.MES_DEPRECIACION.ToString(),
                                NOMBRE_PROVEEDOR = d.NOMBRE_PROVEEDOR,
                                DESCRIPCION = f.DESCRIPCION,
                                MARCA = e.DESCRIPCION,
                                COLOR = c.COLOR,
                                MODELO = c.MODELO,
                                NUMERO_SERIE = c.NUMERO_SERIE,
                                TIPO_PROCESADOR = c.TIPO_PROCESADOR,
                                DISQUETERA = c.DISQUETERA,
                                LECTOR_DVD = c.LECTOR_DVD,
                                LECTOR_SD_MMC = c.LECTOR_SD_MMC,
                                PARLANTES_EXTERNOS = c.PARLANTES_EXTERNOS,
                                MONITOR_COLOR = c.MONITOR_COLOR,
                                MONITOR_SERIE = c.MONITOR_SERIE,
                                MONITOR_TAMANIO = c.MONITOR_TAMANIO,
                                MONITOR_TIPO = c.MONITOR_TIPO,
                                TECLADO_COLOR = c.TECLADO_COLOR,
                                TECLADO_MODELO = c.TECLADO_MODELO,
                                MOUSE_COLOR = c.MOUSE_COLOR,
                                UBICACION = c.UBICACION,
                                ID_EMPLEADO = c.ID_EMPLEADO,
                                CONDICION_ACTUAL = c.CONDICION_ACTUAL,
                                USUARIO_RESPONSABLE = c.USUARIO_RESPONSABLE,
                                ESTADO = c.ESTADO
                            }).ToList();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    return null;
                }


            }
        }
        public int EliminarEi(string CodigoInventario)
        {
            try
            {
                var query = db.ELIMINAR_EI(CodigoInventario);
                return 1;
            }
            catch (Exception err)
            {
                Console.WriteLine(err);
                return 0;
            }
        }
        public string UpdateEI(string CodigoInventario, string NUMERO_SERIE, string PARLANTES_EXTERNOS, string UBICACION, string CONDICION_ACTUAL,
      string USUARIO_RESPONSABLE)
        {
            try
            {
                using (var db = new BD_INV_ACTIVOSEntities())
                {
                    var query = db.ModificarEI(CodigoInventario, NUMERO_SERIE, PARLANTES_EXTERNOS, UBICACION, CONDICION_ACTUAL, USUARIO_RESPONSABLE);
                }
                return "Se guardo Correctamente";
            }
            catch (Exception err)
            {
                return err + "";
            }
        }
        public InventarioModels ObtenerTomaInformatica(string CODIGO_INVENTARIO)

        {

            using (var db = new BD_INV_ACTIVOSEntities())
            {
                var query = db.DETALLE_CONTROL_EI.Where
                    (x => x.CODIGO_INVENTARIO == CODIGO_INVENTARIO).FirstOrDefault();
                InventarioModels inventarioID = new InventarioModels
                {

                    ID_DEPTO = query.ID_DEPTO,
                    NUMERO_REFERENCIA = query.NUMERO_REFERENCIA,
                    CODIGO_INVENTARIO = query.CODIGO_INVENTARIO,
                    
                    FECHA_COMPRA = query.FECHA_COMPRA.ToString(),
                    MES_DEPRECIACION = query.MES_DEPRECIACION.ToString(),
                    ID_PROVEEDOR = query.ID_PROVEEDOR,
                    ID_TIPO_EQUIPO = query.ID_TIPO_EQUIPO,
                    ID_MARCA = query.ID_MARCA,
                    COLOR = query.COLOR,
                    MODELO = query.MODELO,
                    NUMERO_SERIE = query.NUMERO_SERIE,
                    TIPO_PROCESADOR = query.TIPO_PROCESADOR,
                    DISQUETERA = query.DISQUETERA,
                    LECTOR_DVD = query.LECTOR_DVD,
                    LECTOR_SD_MMC = query.LECTOR_SD_MMC,
                    PARLANTES_EXTERNOS = query.PARLANTES_EXTERNOS,
                    MONITOR_COLOR = query.MONITOR_COLOR,
                    MONITOR_SERIE = query.MONITOR_SERIE,
                    MONITOR_TAMANIO = query.MONITOR_TAMANIO,
                    MONITOR_TIPO = query.MONITOR_TIPO,
                    TECLADO_COLOR = query.TECLADO_COLOR,
                    TECLADO_MODELO = query.TECLADO_MODELO,
                    MOUSE_COLOR = query.MOUSE_COLOR,
                    UBICACION = query.UBICACION,
                    ID_EMPLEADO = query.ID_EMPLEADO,
                    CONDICION_ACTUAL = query.CONDICION_ACTUAL,
                    USUARIO_RESPONSABLE = query.USUARIO_RESPONSABLE,
                    ESTADO = query.ESTADO

                };
                return inventarioID;

            }
        }
    }
}
