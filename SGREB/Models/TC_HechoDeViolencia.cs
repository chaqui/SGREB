using System;
using System.Collections.Generic;

namespace SGREB.Models
{
    public partial class TC_HechoDeViolencia
    {
        public int idHechoDeViolencia { get; set; }
        public Nullable<bool> armaDeFuego { get; set; }
        public Nullable<bool> armaBlanca { get; set; }
        public int idIncidente { get; set; }
        public virtual TC_Incidente TC_Incidente { get; set; }
    }
}
