using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace InventarioInstrumentos.Conexion
{
    public interface IConexionDB
    {
        SqlConnection ObtenerConexion();

        SqlConnection AbrirConexion();

        void CerrarConexion();
    }
}
