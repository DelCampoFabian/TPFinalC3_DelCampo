using dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace negocio
{
    public class UserNegocio
    {
        public bool Logear(User Usuario)
        {
			AccesoDatos Datos = new AccesoDatos();
			try
			{
				Datos.setearConsulta("Select id, email, pass, admin, nombre, apellido, urlImagenPerfil from USERS Where email=@email AND pass=@password");
				Datos.setearParametros("@email", Usuario.Email);
				Datos.setearParametros("@password", Usuario.Password);
				Datos.ejecutarLectura();
				while (Datos.Lector.Read())
				{
					Usuario.Id = (int)Datos.Lector["id"];
					Usuario.Admin= (bool)Datos.Lector["admin"];
					if (!(Datos.Lector["urlImagenPerfil"] is DBNull))
						Usuario.UrlImagenPerfil = (string)Datos.Lector["urlImagenPerfil"];
                    if (!(Datos.Lector["nombre"] is DBNull))
                        Usuario.Nombre = (string)Datos.Lector["nombre"];
					if (!(Datos.Lector["apellido"] is DBNull))
						Usuario.Apellido = (string)Datos.Lector["apellido"];
                    return true;
 				}
				return false;

			}
			catch (Exception)
			{

				throw;
			}
			finally
			{
				Datos.cerrarConexion();
			}
        }
		public int InsertarUser(User Usuario)
		{
			AccesoDatos Datos = new AccesoDatos();
			try
			{
				Datos.setearConsulta("INSERT INTO Users (email, pass, admin) output inserted.Id VALUES (@email,@pass,0)");
				Datos.setearParametros("@email", Usuario.Email);
				Datos.setearParametros("@pass", Usuario.Password);
				return Datos.accionScalar();
			}
			catch (Exception ex)
			{
				throw ex;
			}
			finally
			{
				Datos.cerrarConexion();
			}
		}

		public void editarUsuario(User Usuario)
		{
			AccesoDatos Datos = new AccesoDatos();
			try
			{
				Datos.setearConsulta("UPDATE Users SET nombre=@nombre, apellido=@apellido, urlImagenPerfil=@img  WHERE Id=@id");
				Datos.setearParametros("@nombre", Usuario.Nombre);
                Datos.setearParametros("@apellido", Usuario.Apellido);
                Datos.setearParametros("@img", Usuario.UrlImagenPerfil != null ? Usuario.UrlImagenPerfil : (object)DBNull.Value);
                Datos.setearParametros("@id" ,Usuario.Id);

                Datos.accion();

            }
            catch (Exception ex)
			{

				throw ex;
			}
			finally { Datos.cerrarConexion();}
		} 
    }
}
