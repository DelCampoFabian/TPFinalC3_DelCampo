using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using dominio;
using negocio;

namespace Presentacion
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
      
        protected void btnLogear_Click(object sender, EventArgs e)
        {
            User Usuario = new User();
            UserNegocio Negocio = new UserNegocio();
            try
            {
                if(Validacion.ValidarCampo(txtEmail) || Validacion.ValidarCampo(txtPassword))
                {
                    lblError.Text = "Completa ambos campos";
                    return;
                }
                    Usuario.Email = txtEmail.Text;
                    Usuario.Password = txtPassword.Text;

                if (Negocio.Logear(Usuario))
                {
                    Session.Add("UserOnline", Usuario);
                    Response.Redirect("Default.aspx", false);
                }
                else
                {
                    lblError.Text = "Email o Password incorrecto";
                } 
            }
            catch (System.Threading.ThreadAbortException ex) { }
            catch (Exception ex)
            {
                Session.Add("Error", ex.ToString());
                Response.Redirect("Error.aspx", false);
                
            }

        }
    }
}