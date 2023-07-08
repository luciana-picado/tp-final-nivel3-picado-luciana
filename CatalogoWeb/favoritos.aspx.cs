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
    public partial class favoritos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
			try
			{
                if (Session["user"] != null)
                {
                    int id = ((Users)Session["user"]).Id;
                    favNegocio favNegocio = new favNegocio();
                    repFav.DataSource = favNegocio.listarFavconId(id);
                    repFav.DataBind();
                }
			}
			catch (Exception ex)
			{
                Session.Add("error", ex.ToString());
                Response.Redirect("error.aspx", false);
			}
        }
    }
}