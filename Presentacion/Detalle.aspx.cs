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
    public partial class Detalle : System.Web.UI.Page
    {
        List<Articulo> articulos;
        protected void Page_Load(object sender, EventArgs e)
        {
            if(Request.QueryString["id"] != null)
            {
                try
                {
                    ArticuloNegocio negocio = new ArticuloNegocio();
                    articulos = negocio.listar();
                    Articulo seleccionado = articulos.Find(x => x.Id == int.Parse(Request.QueryString["id"]));
                    lblNombre.Text = seleccionado.Nombre;
                    lblDescripcion.Text = seleccionado.Descripcion;
                    lblCodigo.Text= seleccionado.Codigo;
                    lblPrecio.Text= seleccionado.Precio.ToString();
                    lblMarca.Text = seleccionado.Marca.Descripcion;
                    lblCategoria.Text= seleccionado.Categoria.Descripcion;
                    imgDetalle.ImageUrl = seleccionado.ImagenUrl;            
    
                }
                catch (Exception)
                {

                    throw;
                }
            }
        }
    }
}