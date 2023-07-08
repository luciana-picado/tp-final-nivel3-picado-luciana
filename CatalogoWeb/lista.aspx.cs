using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Linq;
using dominio;
using negocio;


namespace CatalogoWeb
{
    public partial class lista : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                //object user = (Users)Session["trainee"];
                //if (!(seguridad.esAdmin(user)))
                //{
                //    Session.Add("error", "Debes ser usuario administrador para ingresar a este sitio");
                //    Response.Redirect("Error.aspx", false);
                //}
                if (!IsPostBack)
                {
                    ArticuloNegocio negocio = new ArticuloNegocio();
                    Session.Add("listaArticulos", negocio.listar());
                    dgvArticulos.DataSource = Session["listaArticulos"];
                    dgvArticulos.DataBind();
                    if (ddlCampo.SelectedItem.ToString() == "Nombre")
                    {
                        ddlCriterio.Enabled = true;
                        ddlCriterio.Items.Clear();
                        ddlCriterio.Items.Add("Comienza con");
                        ddlCriterio.Items.Add("Termina con");
                        ddlCriterio.Items.Add("Contiene");
                    }
                }

            }
            catch (Exception ex)
            {

                Session.Add("error", ex.ToString());
                Response.Redirect("error.aspx", false);
            }
        }

        protected void ckbFiltroAvanzado_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (ckbFiltroAvanzado.Checked)
                {
                    txtFiltroRapido.Enabled = false;
                }
                if (!ckbFiltroAvanzado.Checked)
                {
                    txtFiltroRapido.Enabled = true;
                }

            }
            catch (Exception ex)
            {

                Session.Add("error", ex.ToString());
                Response.Redirect("error.aspx", false);
            }
        }

        protected void txtFiltroRapido_TextChanged(object sender, EventArgs e)
        {
            try
            {
                List<Articulos> lista = (List<Articulos>)Session["listaArticulos"];
                List<Articulos> listaFiltrada = lista.FindAll(x => x.Nombre.ToUpper().Contains(txtFiltroRapido.Text.ToUpper()) || x.Descripcion.ToUpper().Contains(txtFiltroRapido.Text.ToUpper()) || x.Precio.ToString().Contains(txtFiltroRapido.Text));
                if (txtFiltroRapido.Text == "")
                {
                    dgvArticulos.DataSource = lista;
                    dgvArticulos.DataBind();
                }
                else
                {
                    dgvArticulos.DataSource = listaFiltrada;
                    dgvArticulos.DataBind();
                }

            }
            catch (Exception ex)
            {

                Session.Add("error", ex.ToString());
                Response.Redirect("error.aspx", false);
            }
        }

        protected void ddlCampo_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {

               MarcaNegocio marcaNegocio= new MarcaNegocio();
                List<Marcas> lista = marcaNegocio.ListarMarca();
                if (ddlCampo.SelectedItem.ToString() == "Nombre")
                {
                    txtFiltro.Text = "";
                    ddlCriterio.Enabled = true;
                    ddlCriterio.Items.Clear();
                    ddlCriterio.Items.Add("Comienza con");
                    ddlCriterio.Items.Add("Termina con");
                    ddlCriterio.Items.Add("Contiene");
                }
                if (ddlCampo.SelectedItem.ToString() == "Precio")
                {
                    txtFiltro.Text = "";
                    ddlCriterio.Enabled = true;
                    ddlCriterio.Items.Clear();
                    ddlCriterio.Items.Add("Menor a ");
                    ddlCriterio.Items.Add("Mayor a");
                    ddlCriterio.Items.Add("Igual a");
                }
                if (ddlCampo.SelectedItem.ToString() == "Marca")
                {
                    ddlCriterio.Items.Clear();
                    ddlCriterio.Enabled= true;
                    ddlCriterio.DataSource = marcaNegocio.ListarMarca();
                    ddlCriterio.DataValueField = "Descripcion";
                    ddlCriterio.DataBind();
                }
            }
            catch (Exception ex)
            {

                Session.Add("error", ex.ToString());
                Response.Redirect("error.aspx", false);
            }
        }

        protected void ddlCriterio_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (ddlCampo.SelectedItem.ToString() == "Marca")
                {
                    txtFiltro.Text = ddlCriterio.SelectedItem.ToString();
                }

            }
            catch (Exception ex)
            {

                Session.Add("error", ex.ToString());
                Response.Redirect("error.aspx", false);
            }
        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
               ArticuloNegocio articuloNegocio = new ArticuloNegocio();
                string campo = ddlCampo.SelectedItem.ToString();
                string criterio = ddlCriterio.SelectedItem.ToString();
                string filtro = txtFiltro.Text;
                dgvArticulos.DataSource = articuloNegocio.filtrar(campo, criterio, filtro);
                dgvArticulos.DataBind();

            }
            catch (Exception ex)
            {

                Session.Add("error", ex.ToString());
                Response.Redirect("error.aspx", false);
            }
        }

        protected void dgvArticulos_SelectedIndexChanged1(object sender, EventArgs e)
        {
            try
            {
                string id = dgvArticulos.SelectedDataKey.Value.ToString();
                Response.Redirect("detalle.aspx?id=" + id, false);

            }
            catch (Exception ex)
            {

                Session.Add("error", ex.ToString());
                Response.Redirect("error.aspx", false);
            }
        }

        protected void btnRefrescar_Click(object sender, EventArgs e)
        {
            try
            {
                Response.Redirect("lista.aspx", false);
            }
            catch (Exception ex)
            {

                Session.Add("error", ex.ToString());
                Response.Redirect("error.aspx", false);
            }
        }
    }
    
}