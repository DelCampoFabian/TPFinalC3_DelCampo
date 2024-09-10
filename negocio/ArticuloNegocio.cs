using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using dominio;
namespace negocio
{
    public class ArticuloNegocio
    {
        public List<Articulo> listar()
        {
            List<Articulo> lista = new List<Articulo>();
            AccesoDatos datos = new AccesoDatos();
            
            try
            {
                datos.setearConsulta("select A.Id, Codigo, Nombre, A.Descripcion, ImagenUrl, Precio, m.Descripcion Marca,c.Descripcion Categoria, A.IdMarca, A.IdCategoria from ARTICULOS A, MARCAS M, CATEGORIAS C where IdMarca = m.Id and IdCategoria = c.Id");
                datos.ejecutarLectura();
                while (datos.Lector.Read())
                {
                    Articulo aux = new Articulo();
                    aux.id = (int)datos.Lector["Id"];
                    aux.nombre = (string)datos.Lector["Nombre"];
                    aux.codigo = (string)datos.Lector["Codigo"];
                    aux.descripcion = (string)datos.Lector["Descripcion"];
                    if (!(datos.Lector["ImagenUrl"] is DBNull))
                        aux.imagenUrl = (string)datos.Lector["ImagenUrl"];
                    aux.categoria = new Categoria();
                    aux.categoria.descripcion = (string)datos.Lector["Categoria"];
                    aux.categoria.id= (int)datos.Lector["IdCategoria"];
                    aux.marca = new Marca();
                    aux.marca.id = (int)datos.Lector["IdMarca"];
                    aux.marca.descripcion = (string)datos.Lector["Marca"];
                    aux.precio = (decimal)datos.Lector["Precio"];

                    lista.Add(aux);
                }
                
                return lista;
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }
        public void agregar(Articulo newArticulo)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("insert into ARTICULOS (Codigo, Nombre,Descripcion,IdMarca,IdCategoria,ImagenUrl,Precio) values(@Codigo,@Nombre,@Descripcion,@idMarca,@idCategoria,@urlImagen,@Precio)");
                datos.setearParametros("@Codigo",newArticulo.codigo);
                datos.setearParametros("@Nombre", newArticulo.nombre);
                datos.setearParametros("@Descripcion",newArticulo.descripcion);
                datos.setearParametros("@idMarca", newArticulo.marca.id);
                datos.setearParametros("@idCategoria", newArticulo.categoria.id);
                datos.setearParametros("@urlImagen", newArticulo.imagenUrl);
                datos.setearParametros("@Precio", newArticulo.precio);

                datos.accion();


            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally { datos.cerrarConexion();}
        }

        public void modificar(Articulo articulo)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("update ARTICULOS set  Codigo=@Codigo, Nombre= @Nombre, Descripcion=@Desc, IdMarca = @IdMarca, IdCategoria=@IdCategoria, ImagenUrl = @Img, Precio = @Precio  where id = @id");
                datos.setearParametros("@Nombre",articulo.nombre);
                datos.setearParametros("@Codigo",articulo.codigo);
                datos.setearParametros("@Desc", articulo.descripcion);
                datos.setearParametros("@IdMarca", articulo.marca.id);
                datos.setearParametros("@IdCategoria", articulo.categoria.id);
                datos.setearParametros("@Img", articulo.imagenUrl);
                datos.setearParametros("@Precio", articulo.precio);
                datos.setearParametros("@Id", articulo.id);
                datos.accion();
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }

        }

        public void eliminar(int id)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("delete from ARTICULOS where id = @id");
                datos.setearParametros("@id", id);
                datos.accion();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
