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
    public partial class Default : System.Web.UI.Page
    {
		public List<Articulo> ListaArticulos { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
			try
			{
				if (!IsPostBack)
				{
					ArticuloNegocio negocio = new ArticuloNegocio();
					ListaArticulos = negocio.listar();
					Session.Add("ListaArticulos", ListaArticulos);
					rpArticulos.DataSource = ListaArticulos;
					rpArticulos.DataBind();					
				}
			}
			catch (Exception)
			{

				throw;
			}
        }
        protected void cbCategoria_CheckedChanged(object sender, EventArgs e)
        {
			if (cbCategoria.Checked)
			{
                CategoriaNegocio categoria = new CategoriaNegocio();
                ddlCategoria.DataSource = categoria.listar();
                ddlCategoria.DataValueField = "id";
                ddlCategoria.DataTextField = "Descripcion";
                ddlCategoria.DataBind();
			}
			else
			{
				ddlCategoria.Items.Clear();
                ddlCategoria.DataBind();
            }
        }

        protected void btnAplican_Click(object sender, EventArgs e)
        {
			List<Articulo> Articulos = (List<Articulo>)Session["ListaArticulos"];
            if(cbCategoria.Checked && cbMarca.Checked)
            {
                rpArticulos.DataSource= Articulos.FindAll(x => x.Categoria.Id == int.Parse(ddlCategoria.SelectedValue) && x.Marca.Id == int.Parse(ddlMarca.SelectedValue));
			    rpArticulos.DataBind();
            }else if (cbCategoria.Checked)
            {
                rpArticulos.DataSource = Articulos.FindAll(x => x.Categoria.Id == int.Parse(ddlCategoria.SelectedValue));
                rpArticulos.DataBind();
            }else if (cbMarca.Checked)
            {
                rpArticulos.DataSource = Articulos.FindAll(x => x.Marca.Id == int.Parse(ddlMarca.SelectedValue));
                rpArticulos.DataBind();
            }
            else
            {
                rpArticulos.DataSource = Articulos;
                rpArticulos.DataBind();
            }
        }

        protected void cbMarca_CheckedChanged(object sender, EventArgs e)
        {
            if (cbMarca.Checked)
            {
                MarcaNegocio marca = new MarcaNegocio();
               ddlMarca.DataSource = marca.listar();
                ddlMarca.DataValueField= "id";
                ddlMarca.DataTextField= "Descripcion";
                ddlMarca.DataBind();
            }
            else
            {
                ddlMarca.Items.Clear();
                ddlMarca.DataBind();
            }
        }
    }
}