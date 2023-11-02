using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos
{
    public  class ConexionDAL
    {
        public static SqlConnection ConectartoBD() {
            SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
            builder.DataSource = "LAPTOP-TTDAQSNT\\SQLEXPRESS";
            builder.InitialCatalog = "TransporteTaxi";
            builder.IntegratedSecurity = true;
            string cadenaConexion = builder.ConnectionString;
            SqlConnection conexion = new SqlConnection(cadenaConexion);
            return conexion;
        }
    }
}
