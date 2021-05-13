using InventarioTIModelo.Inventario;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventarioTI.Data.InventarioD
{
    public class InventarioData
    {
        public List<InventarioM> ListaInventario()
        {

            List<InventarioM> inventarios;

            using (var db = new Inventario_TIEntities())
            {
                try
                {
                    inventarios = (
                            from c in db.Marcas
                            select new
                            {
                                MarcaID = c.MarcaID,
                                Descriocion = c.Descripcion
                            }).ToList().Select(x => new InventarioM
                            {
                                MarcaID = Convert.ToInt32(x.MarcaID),
                                Descriocion = x.Descriocion
                            }).ToList();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    return null;
                }


            }

            return inventarios;
        }
        public InventarioM ObetenerMarca(int id)
        {

            InventarioM inventario;

            using (var db = new Inventario_TIEntities())
            {
                try
                {
                    var data = db.Marcas.FirstOrDefault(x => x.MarcaID == id);
                    inventario = new InventarioM
                    {
                        MarcaID = Convert.ToInt32(data.MarcaID),
                        Descriocion = data.Descripcion
                    };
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    return null;
                }


            }

            return inventario;
        }
    }
    }
