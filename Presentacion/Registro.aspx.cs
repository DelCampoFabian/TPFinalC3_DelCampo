using dominio;
using negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Presentacion
{
    public partial class Registro : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnRegistro_Click(object sender, EventArgs e)
        {
            try
            {
                Page.Validate();
                if (!Page.IsValid)
                    return;
                User user = new User();
                UserNegocio negocio = new UserNegocio();
                if (string.IsNullOrEmpty(txtEmail.Text) || string.IsNullOrEmpty(txtPassword.Text))
                {
                    Session.Add("Error","Debes llenar ambos campos");
                    Response.Redirect("Error.aspx");
                }
                user.Email= txtEmail.Text;
                user.Password= txtPassword.Text;
                user.Id = negocio.InsertarUser(user);
                Session.Add("UserOnline", user);

                Response.Redirect("Perfil.aspx", false);
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