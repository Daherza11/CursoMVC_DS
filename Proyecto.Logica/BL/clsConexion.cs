using System.Configuration;

namespace Proyecto.Logica.BL
{
    public class clsConexion
    {
        /// <summary>
        /// OBTIENE CONEXIÓN A BASE DE DATOS
        /// </summary>
        /// <returns>CADENA DE CONEXIÓN</returns>
        public string getConexion()
        {
            return ConfigurationManager.ConnectionStrings["Cnx"].ToString();
        }
    }
}
