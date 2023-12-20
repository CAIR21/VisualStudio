using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace DataAccess
{
    public abstract class Conexion
    {
        private readonly string connectionString;
        public Conexion()
        {
            connectionString = "Server=CAIR\\CAIR;DataBase= Consultorio; integrated security= true";
        }
        protected SqlConnection GetConnection()
        {
            return new SqlConnection(connectionString);
        }
    }
}
