using System;
using System.Collections.Generic;

namespace SGREB.Models
{
    public partial class PacienteDeIncidente
    {
        public int idPaciente { get; set; }
        public int incidente { get; set; }
        public virtual TC_Paciente TC_Paciente { get; set; }
    }
}
