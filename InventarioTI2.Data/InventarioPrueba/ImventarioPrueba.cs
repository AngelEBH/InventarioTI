using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InventarioTIModelo.InventarioPrueba;
namespace InventarioTI2.Data.InventarioPrueba
{
     public class ImventarioPrueba
    {
        public List<InventarioTIModelo.InventarioPrueba.InventarioPrueba> ListaMobiliarioEI
        {
            get
            {
                using (var db = new BDWatchMaking21Entities())
                {
                    try
                    {
                        return (
                                from c in db.Productos

                                select new InventarioTIModelo.InventarioPrueba.InventarioPrueba()
                                {
                                    IdProducto = c.IdProducto,
                                    DeviceName = c.DeviceName,
                                    IdTipoProducto = c.IdTipoProducto,
                                    IdMarca = c.IdMarca
                                 

                                }).ToList();
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                        return null;
                    }


                }
            }
        }
    }
}
