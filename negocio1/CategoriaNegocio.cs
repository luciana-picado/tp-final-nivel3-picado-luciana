using negocio;
using System;
using System.Collections.Generic;
using System.Text;

namespace dominio
{
    public class CategoriaNegocio
    {
        public List<Categorias> ListarCategoria()
        {
            List<Categorias> lista = new List<Categorias>();
            AccesoADatos datos = new AccesoADatos();
            try
            {
                datos.setearConsulta("select id, descripcion from  categorias  ");
                datos.ejecutarLectura();
                while (datos.Lector.Read())
                {
                    Categorias aux = new Categorias();
                    aux.Id = (int)datos.Lector["Id"];
                    aux.Descripcion = (string)datos.Lector["Descripcion"];
                    lista.Add(aux);
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
