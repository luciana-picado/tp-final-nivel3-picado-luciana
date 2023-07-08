using dominio;
using System;
using System.Collections.Generic;
using System.Text;

namespace negocio
{
    public class favNegocio
    {
        AccesoADatos datos = new AccesoADatos();
        public List<Favoritos> listarFavconId(int id)
        {
            List<Favoritos> lista = new List<Favoritos>();
            try
            {
                datos.setearConsulta("select f.Id idFav, IdUser iduser ,u.email usuario, a.Nombre nombreart,m.Descripcion marca ,c.Descripcion categoria, a.ImagenUrl imagen from FAVORITOS f, ARTICULOS a, USERS u, MARCAS m, CATEGORIAS c where u.id=IdUser and a.Id=IdArticulo and m.Id=a.IdMarca and c.Id=a.IdCategoria and u.id=@id");
                datos.setearParametro("@id", id);
                datos.ejecutarLectura();
                while (datos.Lector.Read())
                {
                    Favoritos fav = new Favoritos();
                    fav.Id = (int)datos.Lector["IdFav"];
                    fav.User = new Users();
                    fav.User.Nombre = (string)datos.Lector["Usuario"];
                    fav.Articulo = new Articulos();
                    fav.Articulo.Nombre = (string)datos.Lector["nombreart"];
                    if (!(string.IsNullOrEmpty((string)datos.Lector["imagen"])))
                        fav.Articulo.ImagenUrl = (string)datos.Lector["imagen"];
                    fav.Marca = new Marcas();
                    fav.Marca.Descripcion = (string)datos.Lector["Marca"];
                    fav.Categoria = new Categorias();
                    fav.Categoria.Descripcion = (string)datos.Lector["Categoria"];
                    lista.Add(fav);
                }
                return lista;
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

        public void añadirFav(int idart, int iduser)
        {
            try
            {
                datos.setearConsulta("insert into favoritos (iduser, idarticulo ) values (@iduser, @idart)");
                datos.setearParametro("@iduser", iduser);
                datos.setearParametro("@idart", idart);
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
        public void quitarFav(int iduser, int idart)
        {
            try
            {
                datos.setearConsulta("delete from favoritos where idarticulo = @idart and iduser=@iduser");
                datos.setearParametro("@idart", idart);
                datos.setearParametro("@iduser", iduser);
                datos.ejecutarAccion();
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally { datos.cerrarConexion(); }
        }
        public bool consultarId(int id)
        {
            try
            {
                datos.setearConsulta("select f.id from favoritos f,articulos ,users u where iduser=@id and u.id=@id");
                datos.setearParametro("@id", id);
                datos.ejecutarLectura();
                if (datos.Lector.Read())
                {
                    return true;
                }
                return false;

            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            { datos.cerrarConexion(); }
        }

    }


}
