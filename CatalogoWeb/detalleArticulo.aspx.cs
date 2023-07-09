using dominio;
using negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using static System.Net.Mime.MediaTypeNames;

namespace CatalogoWeb
{
    public partial class detalleArticulo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                string id = Request.QueryString["id"] != null ? Request.QueryString["id"].ToString() : null;
                ArticuloNegocio negocio = new ArticuloNegocio();
                if (id != null)
                {
                    if (Session["user"] != null)
                        btnFav.Visible = true;
                    else
                        btnFav.Visible = false;
                    Articulos seleccionado = (negocio.listarConID(id))[0];
                    lblCategoria.Text = seleccionado.Categoria.Descripcion;
                    lblNombre.Text = seleccionado.Nombre;
                    lblPrecio.Text = seleccionado.Precio.ToString();
                    lblDescripcion.Text = seleccionado.Descripcion;
                    imgArticulo.ImageUrl = seleccionado.ImagenUrl;
                    favNegocio favNegocio = new favNegocio();

                    string idUser = ((Users)Session["user"]) != null ? ((Users)Session["user"]).Id.ToString() : null ;
                    if (idUser != null)
                    {   
                        if (favNegocio.consultarId(id, idUser))
                        {
                            btnFav.CssClass = "btn btn-danger";
                            btnFav.Text = "Quitar de favoritos";
                        }
                        else
                        {
                            btnFav.CssClass = "btn btn-success";
                            btnFav.Text = " Añadir a favoritos ♥";
                        }

                    }

                }
                else
                {
                    Session.Add("error", "Lamentablemente no podemos cargar esta página. Vuelve al home y selecciona un articulo");
                    Response.Redirect("error.aspx", false);
                }
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
                favNegocio favNegocio = new favNegocio();
                string idart = Request.QueryString["id"];
                string idUser = ((Users)Session["user"]) != null ? ((Users)Session["user"]).Id.ToString() : null;
                if (favNegocio.consultarId(idUser, idart))
                    favNegocio.quitarFav(idUser, idart);
                else
                    favNegocio.añadirFav(idart, idUser);
                Response.Redirect("favoritos.aspx", false);
            }
            catch (Exception ex)
            {
                Session.Add("error", ex.ToString());
                Response.Redirect("error.aspx", false);
            }
        }

        protected void txtFiltro_TextChanged(object sender, EventArgs e)
        {

        }
    }
}