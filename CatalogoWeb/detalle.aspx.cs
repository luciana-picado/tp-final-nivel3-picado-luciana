using dominio;
using negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Linq;

namespace CatalogoWeb
{
    public partial class detalle : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ArticuloNegocio articuloNegocio = new ArticuloNegocio();
            MarcaNegocio marcaNegocio = new MarcaNegocio();
            CategoriaNegocio categoriaNegocio = new CategoriaNegocio();
            try
            {
                txtId.Enabled = false;
                ckbEliminar.Visible = false;
                lblEliminar.Visible = false;
                btnModificar.Visible = false;

                if (!IsPostBack)
                {
                    List<Marcas> listaMarcas = marcaNegocio.ListarMarca();
                    List<Categorias> listaCategorias = categoriaNegocio.ListarCategoria();
                    ddlMarca.DataSource = listaMarcas;
                    ddlMarca.DataTextField = "Descripcion";
                    ddlMarca.DataValueField = "Id";
                    ddlMarca.DataBind();
                    ddlCategoria.DataTextField = "Descripcion";
                    ddlCategoria.DataValueField = "Id";
                    ddlCategoria.DataSource = listaCategorias;
                    ddlCategoria.DataBind();
                }

                string id = Request.QueryString["id"] != null ? Request.QueryString["id"].ToString() : "";
                if (id != "" && !IsPostBack)
                {
                    btnModificar.Visible = true;
                    Articulos seleccionado = (articuloNegocio.listarConID(id))[0];
                    txtId.Text = id;
                    txtCodigo.Text = seleccionado.Codigo.ToString();
                    txtCodigo.Enabled = false;
                    txtPrecio.Text = seleccionado.Precio.ToString();
                    txtPrecio.Enabled = false;
                    txtNombre.Text = seleccionado.Nombre;
                    txtNombre.Enabled = false;
                    txtDescripcion.Text = seleccionado.Descripcion;
                    txtDescripcion.Enabled = false;
                    txtImagen.Text = seleccionado.ImagenUrl;
                    txtImagen.Enabled = false;
                    ddlMarca.SelectedValue = seleccionado.Marca.Id.ToString();
                    ddlMarca.Enabled = false;
                    ddlCategoria.SelectedValue = seleccionado.Categoria.Id.ToString();
                    ddlCategoria.Enabled = false;
                    imgArticulo.ImageUrl = txtImagen.Text;
                    btnAceptar.Enabled = false;

                }

            }
            catch (Exception ex)
            {
                Session.Add("error", ex.ToString());
                Response.Redirect("Error.aspx", false);
            }
        }

        protected void btnAceptar_Click(object sender, EventArgs e)
        {
            try
            {
                string id = Request.QueryString["id"] != null ? Request.QueryString["id"].ToString() : null;
                Articulos nuevo = new Articulos();
                ArticuloNegocio negocio = new ArticuloNegocio();
                
                    nuevo.Nombre = txtNombre.Text;
                    nuevo.Codigo = txtCodigo.Text;
                    nuevo.Precio = decimal.Parse(txtPrecio.Text);
                    nuevo.Descripcion = txtDescripcion.Text;
                    nuevo.Marca = new Marcas();
                    nuevo.Marca.Id = int.Parse(ddlMarca.SelectedValue);
                    nuevo.Categoria = new Categorias();
                    nuevo.Categoria.Id = int.Parse(ddlCategoria.SelectedValue);
                    nuevo.ImagenUrl = txtImagen.Text;
                    if (id != null)
                    {
                        nuevo.Id = int.Parse(txtId.Text);
                        negocio.modificar(nuevo);
                    }

                if (!((string.IsNullOrEmpty(txtNombre.Text)) && (string.IsNullOrEmpty(txtCodigo.Text)) && (string.IsNullOrEmpty(txtPrecio.Text))))
                    negocio.agregar(nuevo);
                    Response.Redirect("default.aspx", false);

            }
            catch (Exception ex)
            {

                Session.Add("error", ex.ToString());
                Response.Redirect("Error.aspx", false);
            }

        }

        protected void btnModificar_Click(object sender, EventArgs e)
        {
            try
            {

                string id = Request.QueryString["id"] != null ? Request.QueryString["id"].ToString() : "";
                ArticuloNegocio negocio = new ArticuloNegocio();
                btnEliminarDesea.Visible = true;
                txtNombre.Enabled = true;
                txtCodigo.Enabled = true;
                txtPrecio.Enabled = true;
                txtDescripcion.Enabled = true;
                txtImagen.Enabled = true;
                ddlMarca.Enabled = true;
                ddlCategoria.Enabled = true;
                btnModificar.Enabled = false;
                btnAceptar.Enabled = true;
            }
            catch (Exception ex)
            {

                Session.Add("error", ex.ToString());
                Response.Redirect("Error.aspx", false);
            }
        }

    

        protected void txtImagen_TextChanged(object sender, EventArgs e)
        {
            try
            {
                imgArticulo.ImageUrl = txtImagen.Text;

            }
            catch (Exception ex)
            {

                Session.Add("error", ex.ToString());
                Response.Redirect("Error.aspx", false);
            }
        }

        protected void btnEliminar_Click1(object sender, EventArgs e)
        {
            try
            {
                string id = Request.QueryString["id"] != null ? Request.QueryString["id"].ToString() : "";
                ArticuloNegocio negocio = new ArticuloNegocio();
                if (ckbEliminar.Checked)
                {
                    negocio.eliminar(int.Parse(id));
                    Response.Redirect("default.aspx", false);
                }

            }
            catch (Exception ex)
            {

                Session.Add("error", ex.ToString());
                Response.Redirect("error.aspx", false);
            }
        }

        protected void btnEliminarDesea_Click(object sender, EventArgs e)
        {
            lblEliminar.Visible= true;
            ckbEliminar.Visible = true;
                        btnEliminarDesea.Visible = false;
        }

        protected void ckbEliminar_CheckedChanged(object sender, EventArgs e)
        {
            btnEliminar.Visible = true;
            lblEliminar.Visible = true;
            ckbEliminar.Visible = true;
        }
    }
}