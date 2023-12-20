using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data.SqlClient;

namespace Datos.Repositorios
{
    public abstract class Repositorio //Para no instanciar solo heredar (public abstract)
    {
        private readonly string conexionstring;
        public Repositorio()
        {
            conexionstring = ConfigurationManager.ConnectionStrings["ConexionConsultorio"].ToString();
        }
        protected SqlConnection ObtenerLaConexion()
        {
            return new SqlConnection(conexionstring);
        }
    }
}
