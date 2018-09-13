using System;
using System.Collections.Generic;

namespace SGREB.Models
{
    public partial class TC_Maternidad
    {
        public int idMaternidad { get; set; }
        public Nullable<bool> aborto { get; set; }
        public Nullable<bool> atencionDeParto { get; set; }
        public Nullable<bool> RetencionDePlacenta { get; set; }
        public Nullable<int> InstitucionDeTraslado { get; set; }
        public int idIncidente { get; set; }
        public Nullable<int> mesesDeEmbarazo { get; set; }
        public virtual TC_Incidente TC_Incidente { get; set; }
        public virtual TV_InstitucionDeSalud TV_InstitucionDeSalud { get; set; }
    }
}
