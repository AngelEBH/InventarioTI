using conexion.conexion.datos;
using InventarioTIModelo.Seguridad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace InventarioTI.Data.Seguridad
{
    public class UsuarioData
    {
        BD_INV_ACTIVOSEntities entity = new BD_INV_ACTIVOSEntities();
        //SistemaActivosFijosEntities entity = new SistemaActivosFijosEntities();

        public List<UsuarioModel> GetAllUsersData()
        {
            try
            {
                var data = (from u in entity.SegUsuario
                            select new UsuarioModel()
                            {
                                IdUsuario = u.IdUsuario,
                                Usuario = u.Usuario,
                                NombreUsuario = u.NombreUsuario,
                                FechaCreacion = u.FechaCreacion.ToString(),
                                UsuarioCreacion = u.UsuarioCreacion,
                                FechaModificacion = u.FechaModificacion.ToString(),
                                UsuarioModificacion = u.UsuarioModificacion,
                                Estado = u.Estado.ToString()
                            }).ToList();

                return data;
            }
            catch (Exception err)
            {
                Console.WriteLine(err);
                return null;
            }
        }

        public HttpStatusCode PostUsuarioData(UsuarioModel usuario)
        {
            try
            {
                var countUser = (from su in entity.SegUsuario
                                 where su.NombreUsuario == usuario.NombreUsuario || su.Usuario == usuario.Usuario
                                 select su).FirstOrDefault();

                if (countUser == null)
                {
                    if (createUSUARIO(usuario) && createSegUsuario(usuario))
                    {
                        return HttpStatusCode.OK;
                    }
                    else
                    {
                        return HttpStatusCode.BadRequest;
                    }
                }
                else
                {
                    return HttpStatusCode.Found;
                }



            }
            catch (Exception err)
            {
                Console.WriteLine(err);
                return HttpStatusCode.BadRequest;
            }
        }

        public void PutUsuarioData(UsuarioModel usuario)
        {
            SegUsuario SegUser = (from su in entity.SegUsuario
                                  where su.IdUsuario == usuario.IdUsuario
                                  select su).FirstOrDefault();

            SegUser.UsuarioModificacion = usuario.UsuarioModificacion;
            SegUser.FechaModificacion = Convert.ToDateTime(usuario.FechaModificacion);

            if (usuario.Estado == "A")
            {
                SegUser.Estado = true;
            }
            else if (usuario.Estado == "D")
            {
                SegUser.Estado = false;
            }

            USUARIO user = (from u in entity.USUARIO
                             where u.USUARIO1 == SegUser.Usuario
                             select u).FirstOrDefault();

            user.CONTRASENIA = usuario.Contraseña;
            user.ESTADO = usuario.Estado;

            entity.SaveChanges();
        }

        public UsuarioModel GetUserByIdData(int Id)
        {
            var getSegUser = (from su in entity.SegUsuario
                              where su.IdUsuario == Id
                              select new UsuarioModel()
                              {
                                  Usuario = su.Usuario,
                                  NombreUsuario = su.NombreUsuario

                              }).FirstOrDefault();

            var getUser = (from u in entity.USUARIO
                           where u.USUARIO1 == getSegUser.Usuario
                           select u).FirstOrDefault();

            getSegUser.Contraseña = getUser.CONTRASENIA;
            getSegUser.Estado = getUser.ESTADO;

            return getSegUser;
        }

        public void DeleteUsuarioData(int Id)
        {
            SegUsuario SegUser = (from su in entity.SegUsuario
                                  where su.IdUsuario == Id
                                  select su).FirstOrDefault();

            USUARIO user = (from u in entity.USUARIO
                             where u.USUARIO1 == SegUser.Usuario
                             select u).FirstOrDefault();

            entity.USUARIO.Remove(user);
            entity.SegUsuario.Remove(SegUser);
            entity.SaveChanges();
        }

        private bool createUSUARIO(UsuarioModel usuario)
        {
            try
            {
                usuario.Estado = "A";
                USUARIO user = new USUARIO()
                {
                    USUARIO1 = usuario.Usuario,
                    CONTRASENIA = usuario.Contraseña,
                    ESTADO = usuario.Estado
                };

                entity.USUARIO.Add(user);
                entity.SaveChanges();

                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return false;
            }
        }

        private bool createSegUsuario(UsuarioModel usuario)
        {
            try
            {
                SegUsuario user = new SegUsuario()
                {
                    Usuario = usuario.Usuario,
                    NombreUsuario = usuario.NombreUsuario,
                    FechaCreacion = Convert.ToDateTime(usuario.FechaCreacion),
                    UsuarioCreacion = usuario.UsuarioCreacion,
                    FechaModificacion = Convert.ToDateTime(usuario.FechaModificacion),
                    UsuarioModificacion = usuario.UsuarioModificacion,
                    Estado = true

                };

                entity.SegUsuario.Add(user);
                entity.SaveChanges();

                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return false;
            }
        }
    }
}
