using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using dominio;


namespace negocio
{
    public class ArticuloNegocio
    {
        AccesoADatos datos = new AccesoADatos();
        public List<Articulos> listar()
        {
            try
            {
                List<Articulos> lista = new List<Articulos>();
                datos.setearConsulta("select codigo, nombre, a.descripcion as Descripcion, imagenurl, m.Descripcion as Marca , c.Descripcion as categoria, m.id, c.id, precio, a.Id from ARTICULOS a, CATEGORIAS c, MARCAS m where a.IdMarca=m.id and a.IdCategoria=c.Id ");
                datos.ejecutarLectura();
                while (datos.Lector.Read())
                {
                Articulos art = new Articulos();
                    art.Id = (int)datos.Lector["Id"];
                    art.Codigo = (string)datos.Lector["Codigo"];
                    art.Nombre = (string)datos.Lector["Nombre"];
                    art.Descripcion = (string)datos.Lector["Descripcion"];
                    art.Marca = new Marcas();
                    art.Marca.Id = (int)datos.Lector["Id"];
                    art.Marca.Descripcion = (string)datos.Lector["Marca"];
                    art.Categoria = new Categorias();
                    art.Categoria.Id = (int)datos.Lector["Id"];
                    art.Categoria.Descripcion = (string)datos.Lector["Categoria"];
                    art.Precio = (decimal)datos.Lector["Precio"];
                    if (!(string.IsNullOrEmpty((string)datos.Lector["ImagenUrl"])))
                        art.ImagenUrl = (string)datos.Lector["ImagenUrl"];

                    lista.Add(art);
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

        public List<Articulos> listarConID(string id = "")
        {
            try
            {
                List<Articulos> lista = new List<Articulos>();
                string consulta = "select codigo, nombre, a.descripcion as Descripcion, imagenurl, m.Descripcion as Marca, m.id, c.id , c.Descripcion as categoria, precio, a.Id from ARTICULOS a, CATEGORIAS c, MARCAS m where a.IdMarca=m.id and a.IdCategoria=c.Id ";
                if (id != null)
                {
                    consulta += "and a.id=" + id;
                }
                datos.setearConsulta(consulta);
                datos.ejecutarLectura();
                while (datos.Lector.Read())
                {
                Articulos art = new Articulos();
                    art.Id = (int)datos.Lector["Id"];
                    art.Codigo = (string)datos.Lector["Codigo"];
                    art.Nombre = (string)datos.Lector["Nombre"];
                    art.Descripcion = (string)datos.Lector["Descripcion"];
                    art.Marca = new Marcas();
                    art.Marca.Id = (int)datos.Lector["Id"];
                    art.Marca.Descripcion = (string)datos.Lector["Marca"];
                    art.Categoria = new Categorias();
                    art.Categoria.Id = (int)datos.Lector["Id"];
                    art.Categoria.Descripcion = (string)datos.Lector["Categoria"];
                    art.Precio = (decimal)datos.Lector["Precio"];
                    if (!(string.IsNullOrEmpty((string)datos.Lector["ImagenUrl"])))
                        art.ImagenUrl = (string)datos.Lector["ImagenUrl"];

                    lista.Add(art);
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
        public void modificar(Articulos nuevo)
        {
            try
            {
                datos.setearConsulta("Update POKEMONS set codigo = @cod, Nombre= @nomb, Descripcion=@desc, UrlImagen=@img, IdMarca=@IdMarca, IdCategoria=@IdCategoria, precio=@precio where Id=@Id ");
                datos.setearParametro("@cod", nuevo.Codigo);
                datos.setearParametro("@nombre", nuevo.Nombre);
                datos.setearParametro("@desc", nuevo.Descripcion);
                datos.setearParametro("@img", nuevo.ImagenUrl);
                datos.setearParametro("@idMarca", nuevo.Marca.Id);
                datos.setearParametro("@idCategoria", nuevo.Categoria.Id);
                datos.setearParametro("@precio", nuevo.Precio);
                datos.setearParametro("id", nuevo.Id);
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
        public List<Articulos> filtrar(string campo, string criterio, string filtro)
        {
            List<Articulos> lista = new List<Articulos>();
            Articulos art = new Articulos();
            try
            {
                string consulta = "select codigo, nombre, a.descripcion as Descripcion, imagenurl, m.Descripcion as Marca , c.Descripcion as categoria, precio, a.Id from ARTICULOS a, CATEGORIAS c, MARCAS m where a.IdMarca=m.id and a.IdCategoria=c.Id and ";
                if (campo == "Precio")
                {
                    switch (criterio)
                    {
                        case "Mayor a":
                            consulta += "precio > " + filtro;
                            break;
                        case "Menor a":
                            consulta += "precio < " + filtro;
                            break;
                        default:
                            consulta += "precio = " + filtro;
                            break;
                    }
                }
                else if (campo == "Nombre")
                {
                    switch (criterio)
                    {
                        case "Comienza con":
                            consulta += "Nombre like '" + filtro + "%'";
                            break;
                        case "Termina con":
                            consulta += "Nombre like '%" + filtro + "'";
                            break;
                        default:
                            consulta += "Nombre like '%" + filtro + "%'";
                            break;
                    }
                }
                else
                {
                    switch (criterio)
                    {
                        case "Comienza con":
                            consulta += "m.Descripcion like '" + filtro + "%'";
                            break;
                        case "Termina con":
                            consulta += "m.Descripcion like '%" + filtro + "'";
                            break;
                        default:
                            consulta += "m.Descripcion like '%" + filtro + "%'";
                            break;
                    }

                }
                datos.setearConsulta(consulta);
                datos.ejecutarLectura();
                while (datos.Lector.Read())
                {
                    art.Id = (int)datos.Lector["Id"];
                    art.Codigo = (string)datos.Lector["Codigo"];
                    art.Nombre = (string)datos.Lector["Nombre"];
                    art.Descripcion = (string)datos.Lector["Descripcion"];
                    art.Marca = new Marcas();
                    art.Marca.Id = (int)datos.Lector["Id"];
                    art.Marca.Descripcion = (string)datos.Lector["Marca"];
                    art.Categoria = new Categorias();
                    art.Categoria.Id = (int)datos.Lector["Id"];
                    art.Categoria.Descripcion = (string)datos.Lector["Categoria"];
                    art.Precio = (decimal)datos.Lector["Precio"];
                    if (!(string.IsNullOrEmpty((string)datos.Lector["ImagenUrl"])))
                        art.ImagenUrl = (string)datos.Lector["ImagenUrl"];

                    lista.Add(art);
                }
                return lista;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void eliminar(int id)
        {
            try
            {
                datos.setearConsulta("delete from articulos where id=@id");
                datos.setearParametro("id", id);
                datos.ejecutarAccion();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public void agregar(Articulos nuevo)
        {
            try
            {
                datos.setearConsulta("insert into ARTICULOS (Codigo, Nombre, Descripcion, IdMarca, IdCategoria, ImagenUrl, Precio) values (@cod, @nombre,@desc,@idMarca ,@idCategoria,@img , @precio)");
                datos.setearParametro("@cod", nuevo.Codigo);
                datos.setearParametro("@nombre", nuevo.Nombre);
                datos.setearParametro("@desc", nuevo.Descripcion);
                datos.setearParametro("@idMarca", nuevo.Marca.Id);
                datos.setearParametro("@idCategoria", nuevo.Categoria.Id);
                datos.setearParametro("@img", nuevo.ImagenUrl);
                datos.setearParametro("@precio", nuevo.Precio);
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
