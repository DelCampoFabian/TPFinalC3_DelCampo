using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using negocio;
using dominio;

namespace Presentacion
{
    public partial class TablaArticulos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
			if (!Seguridad.EsAdmin(Session["UserOnline"]))
			{
				Session.Add("Error", "No tiene los permisos para acceder");
				Response.Redirect("Error.aspx",false);
			}

			try
			{
				if (!IsPostBack)
				{
					ArticuloNegocio negocio = new ArticuloNegocio();
					dgvArticulos.DataSource = negocio.listar();
					dgvArticulos.DataBind();
				}
			}
			catch (Exception ex)
			{
				Session.Add("Error", ex.ToString());				
			}
        }

        protected void dgvArticulos_SelectedIndexChanged(object sender, EventArgs e)
        {
			string id = dgvArticulos.SelectedDataKey.Value.ToString();
			Response.Redirect("Formulario.aspx?id=" + id ,false);
        }
    }
}