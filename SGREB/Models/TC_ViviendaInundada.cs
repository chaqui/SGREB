using System;
using System.Collections.Generic;

namespace SGREB.Models
{
    public partial class TC_ViviendaInundada
    {
        public TC_ViviendaInundada()
        {
            this.TT_EvacuadoInundacion = new List<TT_EvacuadoInundacion>();
        }

        public int IdViviendaInundada { get; set; }
        public Nullable<int> propietario { get; set; }
        public Nullable<int> idIncidente { get; set; }
        public virtual TC_Incidente TC_Incidente { get; set; }
        public virtual TC_Persona TC_Persona { get; set; }
        public virtual ICollection<TT_EvacuadoInundacion> TT_EvacuadoInundacion { get; set; }
    }
}
