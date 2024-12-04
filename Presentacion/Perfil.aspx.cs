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
    public partial class Perfil : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Seguridad.SesionActiva(Session["UserOnline"]))
            {
                Response.Redirect("Login.aspx");
            }
            try
            {
                if (!IsPostBack)
                {
                    User user = (User)Session["UserOnline"];
                    txtEmail.ReadOnly= true;
                    txtEmail.Text= user.Email.ToString();
                    txtNombre.Text= user.Nombre;
                    txtApellido.Text= user.Apellido;
                    if (string.IsNullOrEmpty(user.UrlImagenPerfil))
                        imgNuevoPerfil.ImageUrl = "https://png.pngtree.com/png-vector/20210604/ourmid/pngtree-gray-network-placeholder-png-image_3416659.jpg"; 
                    else 
                        imgNuevoPerfil.ImageUrl= "~/Images/" + user.UrlImagenPerfil;   
                }
            }
            catch (Exception ex)
            {
                Session.Add("Error", ex.ToString());
                Response.Redirect("Error.aspx", false); 
            }

        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                Page.Validate();
                if (!Page.IsValid)
                    return;
                UserNegocio negocio = new UserNegocio();
                User user = (User)Session["UserOnline"];
                if (txtImagen.PostedFile.FileName != "")
                {
                    string ruta = Server.MapPath("./Images/");
                    txtImagen.PostedFile.SaveAs(ruta + "perfil-" + user.Id + ".jpg");
                    user.UrlImagenPerfil = "perfil-" + user.Id + ".jpg";
                } 
                user.Nombre= txtNombre.Text;
                user.Apellido = txtApellido.Text;

                negocio.editarUsuario(user);
                Response.Redirect("Default.aspx", false);

            }
            catch (Exception ex)
            {
                Session.Add("Error", ex.ToString());
                Response.Redirect("Error.aspx", false); 
                
            }
        }
    }
}