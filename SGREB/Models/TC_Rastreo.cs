using System;
using System.Collections.Generic;

namespace SGREB.Models
{
    public partial class TC_Rastreo
    {
        public int idRastreo { get; set; }
        public Nullable<bool> Localizada { get; set; }
        public Nullable<int> incidente { get; set; }
        public virtual TC_Incidente TC_Incidente { get; set; }
    }
}
