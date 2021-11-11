using System;
using System.Data;
using System.Data.SqlClient;

namespace Proyecto.Logica.BL
{
    public class clsEstadoTarea
    {
        SqlConnection _SqlConnection = null;//Me permite establecer comunicación con la BD
        SqlCommand _SqlCommand = null;//Me permite ejecutar comandos SQL
        SqlDataAdapter _SqlDataAdapter = null;//Me permite adaptar conjunto de datos SQL
        string stConexion = string.Empty;//Cadena de conexión

        SqlParameter _SqlParameter = null;

        public clsEstadoTarea()
        {
            clsConexion obclsConexion = new clsConexion();
            stConexion = obclsConexion.getConexion();
        }

        /// <summary>
        /// CONSULTA ESTADO TAREA
        /// </summary>
        /// <returns>REGISTROS ESTADO TAREA</returns>
        public DataSet getConsultarEstadoTareas()
        {
            try
            {
                DataSet dsConsulta = new DataSet();

                _SqlConnection = new SqlConnection(stConexion);
                _SqlConnection.Open();

                _SqlCommand = new SqlCommand("spConsultarEstadoTareas", _SqlConnection);
                _SqlCommand.CommandType = CommandType.StoredProcedure;

                _SqlCommand.ExecuteNonQuery();

                _SqlDataAdapter = new SqlDataAdapter(_SqlCommand);
                _SqlDataAdapter.Fill(dsConsulta);

                return dsConsulta;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                _SqlConnection.Close();
            }
        }
    }
}
