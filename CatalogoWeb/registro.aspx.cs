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
    public partial class registro : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void btnRegistrarse_Click(object sender, EventArgs e)
        {
            Page.Validate();

            if (!Page.IsValid)
                return;
            try
            {
                Users user = new Users();
                UserNegocio negocio = new UserNegocio();
                EmailService email = new EmailService();
                user.Email = txtUser.Text;
                user.Password = txtPassword.Text;
                user.Id = negocio.insertarNuevo(user);
                Session.Add("user", user);
                email.armarCorreo(user.Email, "Te damos la bienvenida", "Felicidades, ahora puedes navegar en nuestra pagina");
                email.enviarMail();
                Response.Redirect("default.aspx", false);
            }
            catch (Exception ex)
            {
                Session.Add("error", ex.ToString());
                Response.Redirect("error.aspx", false);
            }

        }
    }
}