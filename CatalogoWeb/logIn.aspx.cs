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
    public partial class logIn : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnIngresar_Click(object sender, EventArgs e)
        {
            Users user = new Users();
            UserNegocio negocio = new UserNegocio();
            try
            {
                user.Email = txtUser.Text;
                user.Password = txtPassword.Text;
                if (negocio.LogIn(user))
                {
                    Session.Add("user", user);
                    Response.Redirect("perfil.aspx", false);
                }
                else
                {
                    Session.Add("error", "User o password incorrectos");
                    Response.Redirect("error.aspx", false);
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