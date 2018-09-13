using System;
using System.Collections.Generic;

namespace SGREB.Models
{
    public partial class TV_TipoIncidente
    {
        public TV_TipoIncidente()
        {
            this.TC_Incidente = new List<TC_Incidente>();
        }

        public int idTipo { get; set; }
        public string nombre { get; set; }
        public virtual ICollection<TC_Incidente> TC_Incidente { get; set; }
    }
}
