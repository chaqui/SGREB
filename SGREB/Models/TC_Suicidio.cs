using System;
using System.Collections.Generic;

namespace SGREB.Models
{
    public partial class TC_Suicidio
    {
        public int idSuicidio { get; set; }
        public Nullable<int> Causa { get; set; }
        public Nullable<int> incidente { get; set; }
        public virtual TC_Incidente TC_Incidente { get; set; }
        public virtual TV_CausaSuicidio TV_CausaSuicidio { get; set; }
    }
}
