﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Xml.Serialization;

namespace negocio
{
    public class AccesoDatos
    {
        private SqlConnection conexion;
        private SqlCommand comando;
        private SqlDataReader lector;
        public SqlDataReader Lector 
        {
            get { return lector; }
         }

        public AccesoDatos()
        {
            conexion = new SqlConnection("server=DESKTOP-P72N324\\SQLEXPRESS; database=CATALOGO_WEB_DB; integrated security=true");
            comando = new SqlCommand();
        }
        public void setearConsulta(string consulta)
        {
            comando.CommandType = System.Data.CommandType.Text;
            comando.CommandText = consulta;
        }
        public void ejecutarLectura()
        {
            comando.Connection= conexion;
            try
            {
                conexion.Open();
                lector = comando.ExecuteReader();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public void accion()
        {
            comando.Connection = conexion;
            try
            {
                conexion.Open();
                comando.ExecuteNonQuery();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public void setearParametros(string nombre, object valor)
        {
            comando.Parameters.AddWithValue(nombre, valor);
        }
        public void cerrarConexion()
        {
            if (lector != null)
            {
                lector.Close();
            }
            conexion.Close();
        }
    }
}
