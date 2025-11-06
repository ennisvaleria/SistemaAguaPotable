using System.Configuration;
using System.Data.SqlClient;

namespace SistemaIncidenciasAguaPotable.Clases
{
    public class ConexionBD
    {
        private SqlConnection conexion;
        public ConexionBD()
        {
            string cadenaConexion = ConfigurationManager.ConnectionStrings["ConexionSQL"].ConnectionString;
            conexion = new SqlConnection(cadenaConexion);
        }
        public SqlConnection ObtenerConexion() => conexion;
        public void AbrirConexion()
        {
            if (conexion.State == System.Data.ConnectionState.Closed)
                conexion.Open();
        }
        public void CerrarConexion()
        {
            if (conexion.State == System.Data.ConnectionState.Open)
            {
                conexion.Close();
            }
        }
    }
}
