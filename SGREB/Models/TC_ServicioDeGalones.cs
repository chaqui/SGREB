using System;
using System.Collections.Generic;

namespace SGREB.Models
{
    public partial class TC_ServicioDeGalones
    {
        public int idServicio { get; set; }
        public Nullable<int> Galones { get; set; }
        public Nullable<int> idIncidente { get; set; }
        public virtual TC_Incidente TC_Incidente { get; set; }
    }
}
