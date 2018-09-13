using System;
using System.Collections.Generic;

namespace SGREB.Models
{
    public partial class TC_Solicitud
    {
        public TC_Solicitud()
        {
            this.TC_Incidente = new List<TC_Incidente>();
        }

        public int idSolicitud { get; set; }
        public int medioSolicitud { get; set; }
        public Nullable<int> solicitante { get; set; }
        public string radioTelefonista { get; set; }
        public string ingresadoPor { get; set; }
        public Nullable<bool> TraspasoACBM { get; set; }
        public virtual TC_Bombero TC_Bombero { get; set; }
        public virtual ICollection<TC_Incidente> TC_Incidente { get; set; }
        public virtual TC_Persona TC_Persona { get; set; }
        public virtual TC_Usuario TC_Usuario { get; set; }
        public virtual TV_MedioSolicitud TV_MedioSolicitud { get; set; }
    }
}
