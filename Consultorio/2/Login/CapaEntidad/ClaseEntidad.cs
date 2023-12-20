using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
    public class ClaseEntidad
    {
        #region DatosUsuario
        public string UsuarioID { get; set; }
        public string Sesion { get; set; }
        public string Contra { get; set; }
        public string NombreUsuario { get; set; }
        public string Rango { get; set; }
        public string CelularUsuario { get; set; }
        public string Accion { get; set; }
        #endregion

        #region DatosPacientes
        public string PacienteID { get; set; }
        public string NombrePaciente { get; set; }
        public int Edad { get; set; }
        public string TipoSangre { get; set; }
        public string Direccion { get; set; }
        public string PolizaSeguro { get; set; }
        public string CelularPaciente { get; set; }
        public string CorreoPaciente { get; set; }

        #endregion

        #region DatosCitas
        public string CitaID { get; set; }
        public string Hora { get; set; }
        public string Dia { get; set; }
        public string Motivo { get; set; }
        public string ConsultorioPreferencia { get; set; }
        #endregion
    }
}

