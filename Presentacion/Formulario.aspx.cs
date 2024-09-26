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
    public partial class Formulario : System.Web.UI.Page
    {
        public bool ConfirmaEliminar { get;set;}
        protected void Page_Load(object sender, EventArgs e)
        {
			try
			{
                if (!IsPostBack)
                {
				    MarcaNegocio negocioMarca = new MarcaNegocio();
				    ddlMarca.DataSource = negocioMarca.listar(); 
				    ddlMarca.DataValueField = "id";
				    ddlMarca.DataTextField = "Descripcion";
				    ddlMarca.DataBind();

                    CategoriaNegocio negocioCategoria = new CategoriaNegocio();               
                    ddlCategoria.DataSource = negocioCategoria.listar(); ;
                    ddlCategoria.DataValueField = "id";
                    ddlCategoria.DataTextField = "Descripcion";
                    ddlCategoria.DataBind();

                    txtID.Enabled = false;
                    btnEliminar.Enabled = false;
                    ConfirmaEliminar = false;

                    string id = Request.QueryString["id"] != null ? Request.QueryString["id"].ToString() : "";
                    if(id != "")
                    {
                        ArticuloNegocio negocio = new ArticuloNegocio();
                        Articulo seleccionado = negocio.listar().Find(x => x.Id == int.Parse(id));

                        txtID.Text = seleccionado.Id.ToString();
                        txtNombre.Text = seleccionado.Nombre;
                        txtCodigo.Text = seleccionado.Codigo;
                        txtDescripcion.Text = seleccionado.Descripcion;
                        txtImg.Text = seleccionado.ImagenUrl;
                        txtPrecio.Text = seleccionado.Precio.ToString();
                        ddlCategoria.SelectedValue = seleccionado.Categoria.Id.ToString();
                        ddlMarca.SelectedValue = seleccionado.Marca.Id.ToString();
                        txtImg_TextChanged(sender, e);

                        btnEliminar.Enabled = true;
                    }
                }


            }
			catch (Exception ex)
			{
                Session.Add("Error", ex.ToString());
                Response.Redirect("Error.aspx", false);
			}
        }

        protected void btnAceptar_Click(object sender, EventArgs e)
        {
            try
            {
                ArticuloNegocio negocio = new ArticuloNegocio();
                Articulo temp = new Articulo();
                temp.Nombre = txtNombre.Text;
                temp.Descripcion = txtDescripcion.Text;
                temp.Codigo = txtCodigo.Text;
                temp.Precio = decimal.Parse(txtPrecio.Text);
                temp.Categoria = new Categoria() ;
                temp.Categoria.Id = int.Parse(ddlCategoria.SelectedValue);
                temp.Marca = new Marca();
                temp.Marca.Id = int.Parse(ddlMarca.SelectedValue);
                temp.ImagenUrl = txtImg.Text;

                if (Request.QueryString["id"] != null)
                {
                    temp.Id = int.Parse(Request.QueryString["id"]);
                    negocio.modificar(temp);
                }else
                {
                    negocio.agregar(temp);
                }


                 Response.Redirect("Default.aspx", false);
            }
            catch (Exception ex)
            {
                Session.Add("Error", ex.ToString());
                Response.Redirect("Error.aspx", false);

            }
        }

        protected void txtImg_TextChanged(object sender, EventArgs e)
        {
            imgArticulo.ImageUrl= txtImg.Text;
        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            ConfirmaEliminar = true;
        }

        protected void btnConfirmar_Click(object sender, EventArgs e)
        {
            try
            {
                ArticuloNegocio negocio = new ArticuloNegocio();
                negocio.eliminar(int.Parse(Request.QueryString["id"]));
                Response.Redirect("TablaArticulos.aspx", false);
            }
            catch (Exception ex)
            {

                Session.Add("Error", ex.ToString());
                Response.Redirect("Error.aspx", false);
            }
        }

        protected void btnRechazar_Click(object sender, EventArgs e)
        {
            ConfirmaEliminar = false;
        }
    }
}