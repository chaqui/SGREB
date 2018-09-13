using System;
using System.Collections.Generic;

namespace SGREB.Models
{
    public partial class TC_UnidadParaIncidente
    {
        public string IdUnidad { get; set; }
        public int Incidente { get; set; }
        public string piloto { get; set; }
        public virtual TC_Bombero TC_Bombero { get; set; }
        public virtual TC_Incidente TC_Incidente { get; set; }
        public virtual TC_Unidad TC_Unidad { get; set; }
    }
}
