using negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Presentacion
{
    public partial class MiMaster : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!(Page is Login || Page is Default || Page is Error || Page is Detalle))
            {
                if (!Seguridad.SesionActiva(Session["UserOnline"]))
                {
                    Response.Redirect("Login.aspx", false);
                }
            }
        }
    }
}