using System;
using System.Collections.Generic;

namespace SGREB.Models
{
    public partial class TT_EvacuadoInundacion
    {
        public int idViviendaInundada { get; set; }
        public int IdEvacuado { get; set; }
        public virtual TC_Paciente TC_Paciente { get; set; }
        public virtual TC_ViviendaInundada TC_ViviendaInundada { get; set; }
    }
}
