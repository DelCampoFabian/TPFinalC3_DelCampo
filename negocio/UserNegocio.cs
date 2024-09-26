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
				Datos.setearConsulta("Select id, email, pass, admin from USERS Where email=@email AND pass=@password");
				Datos.setearParametros("@email", Usuario.Email);
				Datos.setearParametros("@password", Usuario.Password);
				Datos.ejecutarLectura();
				while (Datos.Lector.Read())
				{
					Usuario.Id = (int)Datos.Lector["id"];
					Usuario.Admin= (bool)Datos.Lector["admin"];
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

    }
}
