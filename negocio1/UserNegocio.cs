using dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace negocio
{
    public class UserNegocio
    {
        AccesoADatos datos = new AccesoADatos();
        public int insertarNuevo(Users nuevo)
        {
            try
            {
                datos.setearProcedimiento("InsertarUsuario");
                datos.setearParametro("@email", nuevo.Email);
                datos.setearParametro("@password", nuevo.Password);
                return datos.ejecutarAccionScalar();
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }

        public bool LogIn(Users user)
        {
            try
            {
                datos.setearConsulta("select id, email, pass, admin, urlimagenperfil, nombre, apellido from users where email=@email and pass=@pass");
                datos.setearParametro("@email",user.Email);
                datos.setearParametro("@pass", user.Password);
                datos.ejecutarLectura();
                if (datos.Lector.Read())
                {
                    user.Id = (int)datos.Lector["Id"];
                    if (!(datos.Lector["Nombre"] is DBNull))
                        user.Nombre = (string)datos.Lector["Nombre"];
                    if (!(datos.Lector["Apellido"] is DBNull))
                        user.Apellido = (string)datos.Lector["Apellido"];
                    if (!(datos.Lector["urlImagenPerfil"] is DBNull))
                        user.ImagenPerfil = (string)datos.Lector["urlImagenPerfil"];
                    user.Admin = (bool)datos.Lector["Admin"];
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }
        public void actualizar(Users user)
        {

            try
            {
                datos.setearProcedimiento("actualizarUsuario");
                datos.setearParametro("@id", user.Id);
                datos.setearParametro("@nombre", user.Nombre);
                datos.setearParametro("@apellido", user.Apellido);
                datos.setearParametro("@perfil", (object)user.ImagenPerfil ?? DBNull.Value);
                datos.ejecutarAccion();
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }
    }
}
