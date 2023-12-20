using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Comun.Cache
{
    public static class UserLoginCache
    {
        public static string UsuarioID { get; set; }
        public static string Sesion { get; set; }
        public static string Contra { get; set; }
        public static string NombreUsuario { get; set; }
        public static string Rango { get; set; }
        public static string CelularUsuario { get; set; }
    }
}
