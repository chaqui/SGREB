using System;
using System.Collections.Generic;

namespace SGREB.Models
{
    public partial class TC_Incendio
    {
        public int idIncendio { get; set; }
        public Nullable<double> perdidas { get; set; }
        public Nullable<double> aguaUtilizada { get; set; }
        public Nullable<int> quemadosVivos { get; set; }
        public Nullable<int> quemadosFallecidos { get; set; }
        public int idIncidente { get; set; }
        public Nullable<int> propietario { get; set; }
        public virtual TC_Incidente TC_Incidente { get; set; }
        public virtual TC_Persona TC_Persona { get; set; }
    }
}
