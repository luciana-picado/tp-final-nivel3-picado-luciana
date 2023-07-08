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

        protected void btnFav_Click(object sender, EventArgs e)
        {
            try
            {
                if (Session["user"] != null)
                {
                    favNegocio favNegocio = new favNegocio();
                    int id = ((Users)Session["user"]).Id;
                    // El detalle está en encontrar el item padre del botón que se presionó
                    //Button btn = (Button)sender;
                    Button btn=(Button)sender;
                    //RepeaterItem item = (RepeaterItem)btn.NamingContainer;
                    RepeaterItem item = (RepeaterItem)btn.NamingContainer;
                    // Buscamos el control en ese item 
                    //Label lbl = (Label)item.FindControl("LblId");
                    Label lbl = (Label)item.FindControl("lblId");
                    int IdServ = int.Parse(lbl.Text);
                    favNegocio.añadirFav(IdServ, id);
                }
                else return;

            }
            catch (Exception ex)
            {

                Session.Add("error", ex.ToString());
                Response.Redirect("error.aspx", false);
            }
        }
    }
}