using System;
using System.Collections.Generic;

namespace SGREB.Models
{
    public partial class TV_CausaSuicidio
    {
        public TV_CausaSuicidio()
        {
            this.TC_Suicidio = new List<TC_Suicidio>();
        }

        public int idCausa { get; set; }
        public string CausaSuicidio { get; set; }
        public virtual ICollection<TC_Suicidio> TC_Suicidio { get; set; }
    }
}
