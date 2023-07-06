using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using dominio;


namespace negocio
{
    public class ArticuloNegocio
    {
        AccesoADatos datos = new AccesoADatos();
        public List<Articulos> listar()
        {
            try
            {   List<Articulos> lista= new List<Articulos>();
                Articulos art = new Articulos();
                datos.setearConsulta("select codigo, nombre, a.descripcion as Descripcion, imagenurl, m.Descripcion as Marca , c.Descripcion as categoria, precio, a.Id from ARTICULOS a, CATEGORIAS c, MARCAS m where a.IdMarca=m.id and a.IdCategoria=c.Id");
                datos.ejecutarLectura();
                while(datos.Lector.Read())
                {
                    art.Id=(int)datos.Lector["Id"];
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
                   if(!(string.IsNullOrEmpty((string)datos.Lector["ImagenUrl"])))
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

    }
}
