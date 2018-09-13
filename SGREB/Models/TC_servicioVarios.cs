using System;
using System.Collections.Generic;

namespace SGREB.Models
{
    public partial class TC_servicioVarios
    {
        public int idServiciosVarios { get; set; }
        public Nullable<int> tipoServicio { get; set; }
        public int idIncidente { get; set; }
        public virtual TC_Incidente TC_Incidente { get; set; }
        public virtual TV_TipoServicio TV_TipoServicio { get; set; }
    }
}
