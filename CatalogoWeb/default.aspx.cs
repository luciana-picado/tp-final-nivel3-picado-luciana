using dominio;
using negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace CatalogoWeb
{
    public partial class _default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                ArticuloNegocio negocio = new ArticuloNegocio();
                List<Articulos> lista = negocio.listar();
                repRepeater.DataSource = lista;
                repRepeater.DataBind();


            }
            catch (Exception ex)
            {
                Session.Add("error", ex.ToString());
                Response.Redirect("error.aspx", false);
            }
        }

    }
}