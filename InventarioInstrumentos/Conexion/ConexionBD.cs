using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventarioInstrumentos.Conexion
{
    public class ConexionBD
    {

        public SqlConnection conexion;

        public ConexionBD()
        {
            string cadenaConexion = "Data Source=WDC;Initial Catalog=InventarioInstrumentos;User ID=sa;Password=root;";
            conexion = new SqlConnection(cadenaConexion);
        }

        public SqlConnection ObtenerConexion()
        {
            return conexion;
        }

        public SqlConnection AbrirConexion()
        {
            if (conexion.State == System.Data.ConnectionState.Closed)
                conexion.Open();
            return conexion;
        }

        public void CerrarConexion()
        {
            if (conexion.State == System.Data.ConnectionState.Open)
                conexion.Close();
        }
    }
}
