using dominio;
using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Linq;


namespace negocio
{
    public class MarcaNegocio
    {
        public List<Marcas> ListarMarca()
        {
            List<Marcas> lista = new List<Marcas>();
            AccesoADatos datos = new AccesoADatos();
            try
            {
                datos.setearConsulta("select id, descripcion from marcas");
                datos.ejecutarLectura();
                while (datos.Lector.Read())
                {
                    Marcas aux = new Marcas();
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
