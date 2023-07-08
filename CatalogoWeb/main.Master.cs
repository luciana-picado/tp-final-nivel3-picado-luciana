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
    public partial class main : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {

                imgPerfil.ImageUrl = "data:image/jpeg;base64,/9j/4AAQSkZJRgABAQAAAQABAAD/2wCEAAkGBw8ODw0ODQ0QDhANDw8NDw8ODQ8NDw0PFREWFhURFRUYHSggGBolGxUTITEhJSkrLi4uFx8zODMtNygtLisBCgoKBQUFDgUFDisZExkrKysrKysrKysrKysrKysrKysrKysrKysrKysrKysrKysrKysrKysrKysrKysrKysrK//AABEIAOEA4QMBIgACEQEDEQH/xAAaAAEBAQEBAQEAAAAAAAAAAAAAAQIEAwUH/8QALRABAAIBAgQFAwMFAAAAAAAAAAERAgMEITFRYRJBcbHwUoGRMqHRIkKS4fH/xAAUAQEAAAAAAAAAAAAAAAAAAAAA/8QAFBEBAAAAAAAAAAAAAAAAAAAAAP/aAAwDAQACEQMRAD8A/cbLRAastEBqy2VBbLZAastEBqy2VBbLZUFstEBqy0AWy2VBbLZAastEBqy2VBbLZUC1ZABLLBRLLBRLLBRLLBRLLBRLLBRLLBRLLBRLLBRLLBRLLBRLLBRLLBRLLBQAQQBRAFEAUQBRAFEAURMs4jjMxHrNA0PONbD68f8AKGwUQBRAFEAUQBRAFEAWvlf6E+fOACWWAFlgBZYAWWAFlgBby19xGHPjPSObz3e58PDH9Xs+dM3xniD21d3nl5+GOkfy8JnqADWGpOP6ZmPSWQHVhvs451PrFOjQ3sZTUx4Z/aXzQH27Lcm13UTWOXCevV1gWWAFlgBZYAWWAAAAzZYNDNlg0M2WDQzZYNPLcavgxmfPlHq3b5++1Lyr6fcHPlNzc85QAAAAAAAHfsde/wCmeccvRwN6GVZYz3B9gZssGhmywaGbLBoZssGhm1BA+ewAAAB89wA+e4BMvj55XMz1l9fLlPpL48gAAAAAAAALjzj1hGtKLyxjvAPrRyUAPnuAAAAfPYAZFoBAAAAAAAAHy9bGspju+nlNRM9It8vUznKbnzBkAAAAAAAB07HC5menu5ndsZ/pntIOkAAAAAAAAAARAaEAUQBRACXys4qZjpL6r5u4w8OU9+MA8wAAAAAAAH0NnFYR3fPfR2+NYwD2EAUQBRAFGVBRkACywAssALLACywHnraUZ8/Lzellg+XlFTMdEb1orKfVgAAAAAAHTtdGMoufKXY8drFYR3uXtYAWWAFlgBZYAWWAFoAAAAAAAAAADk3uPGJ68HM79xjE4zflxcAAAAAAPXbYXlHbiDtwioiOkNIoAAAAAAAAIAAAAAAAADOWcRzmgaTLKI4zwc2puvpj7y58spnnNg9dfX8XCOEe7xAAAAABccpibhAHfo6sZR384ej5kS99PczHPj7g7BjDUjLlP8tgAAAWAAAFgMqgADGrqxjHfoDeWURxmXPnuvpi+8vDPOcpuf8AjIPWdxl1r7POZvnxQAAAAAAAAAAAAAiW41so/un3YAesbjLrfrD1w3MecV+7lAfRib5K+fp6k48vw7dPUjKLgG0AFEtQZstADPOomXDnlc3L23OXGujwAAAAAAAAAAAAAAAAAAAAAa08/DNsgPoRlfEtz7XLnH3e4LYgAFpMg485uZnuyAAAAAAAAAAAAAAAAAAAAAAAN6M1lH4djhx5x6w7bBQASPn5lM+U+gA4gAAAAAAAAAAAAAAAAAAAAAAAHdiAKAD/2Q==";
                if (this.Page is perfil || Page is favoritos || Page is lista)
                {
                    if (!(Seguridad.sesionActiva(Session["user"])))
                    {
                        Response.Redirect("logIn.aspx", false);
                    }
                }
                if (Seguridad.sesionActiva(Session["user"]))
                {
                    btnlogIn.Visible = false;
                    btnRegistro.Visible = false;
                    btnCerrarSesion.Visible = true;
                    if (!string.IsNullOrEmpty(((Users)Session["user"]).ImagenPerfil))
                        imgPerfil.ImageUrl = "~/Imagenes/" + ((Users)Session["user"]).ImagenPerfil;
                    lblUsuario.Visible = true;
                    lblUsuario.Text = ((Users)Session["user"]).Email;
                }


                else
                {
                    imgPerfil.ImageUrl = "data:image/jpeg;base64,/9j/4AAQSkZJRgABAQAAAQABAAD/2wCEAAkGBw8ODw0ODQ0QDhANDw8NDw8ODQ8NDw0PFREWFhURFRUYHSggGBolGxUTITEhJSkrLi4uFx8zODMtNygtLisBCgoKBQUFDgUFDisZExkrKysrKysrKysrKysrKysrKysrKysrKysrKysrKysrKysrKysrKysrKysrKysrKysrK//AABEIAOEA4QMBIgACEQEDEQH/xAAaAAEBAQEBAQEAAAAAAAAAAAAAAQIEAwUH/8QALRABAAIBAgQFAwMFAAAAAAAAAAERAgMEITFRYRJBcbHwUoGRMqHRIkKS4fH/xAAUAQEAAAAAAAAAAAAAAAAAAAAA/8QAFBEBAAAAAAAAAAAAAAAAAAAAAP/aAAwDAQACEQMRAD8A/cbLRAastEBqy2VBbLZAastEBqy2VBbLZUFstEBqy0AWy2VBbLZAastEBqy2VBbLZUC1ZABLLBRLLBRLLBRLLBRLLBRLLBRLLBRLLBRLLBRLLBRLLBRLLBRLLBRLLBQAQQBRAFEAUQBRAFEAURMs4jjMxHrNA0PONbD68f8AKGwUQBRAFEAUQBRAFEAWvlf6E+fOACWWAFlgBZYAWWAFlgBby19xGHPjPSObz3e58PDH9Xs+dM3xniD21d3nl5+GOkfy8JnqADWGpOP6ZmPSWQHVhvs451PrFOjQ3sZTUx4Z/aXzQH27Lcm13UTWOXCevV1gWWAFlgBZYAWWAAAAzZYNDNlg0M2WDQzZYNPLcavgxmfPlHq3b5++1Lyr6fcHPlNzc85QAAAAAAAHfsde/wCmeccvRwN6GVZYz3B9gZssGhmywaGbLBoZssGhm1BA+ewAAAB89wA+e4BMvj55XMz1l9fLlPpL48gAAAAAAAALjzj1hGtKLyxjvAPrRyUAPnuAAAAfPYAZFoBAAAAAAAAHy9bGspju+nlNRM9It8vUznKbnzBkAAAAAAAB07HC5menu5ndsZ/pntIOkAAAAAAAAAARAaEAUQBRACXys4qZjpL6r5u4w8OU9+MA8wAAAAAAAH0NnFYR3fPfR2+NYwD2EAUQBRAFGVBRkACywAssALLACywHnraUZ8/Lzellg+XlFTMdEb1orKfVgAAAAAAHTtdGMoufKXY8drFYR3uXtYAWWAFlgBZYAWWAFoAAAAAAAAAADk3uPGJ68HM79xjE4zflxcAAAAAAPXbYXlHbiDtwioiOkNIoAAAAAAAAIAAAAAAAADOWcRzmgaTLKI4zwc2puvpj7y58spnnNg9dfX8XCOEe7xAAAAABccpibhAHfo6sZR384ej5kS99PczHPj7g7BjDUjLlP8tgAAAWAAAFgMqgADGrqxjHfoDeWURxmXPnuvpi+8vDPOcpuf8AjIPWdxl1r7POZvnxQAAAAAAAAAAAAAiW41so/un3YAesbjLrfrD1w3MecV+7lAfRib5K+fp6k48vw7dPUjKLgG0AFEtQZstADPOomXDnlc3L23OXGujwAAAAAAAAAAAAAAAAAAAAAa08/DNsgPoRlfEtz7XLnH3e4LYgAFpMg485uZnuyAAAAAAAAAAAAAAAAAAAAAAAN6M1lH4djhx5x6w7bBQASPn5lM+U+gA4gAAAAAAAAAAAAAAAAAAAAAAAHdiAKAD/2Q==";
                    btnlogIn.Visible = true;
                    btnRegistro.Visible = true;
                    btnCerrarSesion.Visible = false;
                }
            }
            catch (Exception ex)
            {

                Session.Add("error", ex.ToString());
                Response.Redirect("error.aspx", false);
            }
        }

        protected void btnlogIn_Click(object sender, EventArgs e)
        {
            Response.Redirect("logIn.aspx", false);
        }

        protected void btnRegistro_Click(object sender, EventArgs e)
        {
            Response.Redirect("registro.aspx", false);
        }

        protected void btnCerrarSesion_Click(object sender, EventArgs e)
        {
            try
            {
                if (Session["user"]!=null)
                {
                    Session.Clear();
                    Response.Redirect("default.aspx", false);
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