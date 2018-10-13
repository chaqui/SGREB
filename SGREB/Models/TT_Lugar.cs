using System;
using System.Collections.Generic;

namespace SGREB.Models
{
    public partial class TT_Lugar
    {
        public TT_Lugar()
        {
            this.TC_Incidente = new List<TC_Incidente>();
            this.TC_Incidente1 = new List<TC_Incidente>();
        }

        public int idLugar { get; set; }
        public string direccion { get; set; }
        public Nullable<int> institucion { get; set; }
        public virtual ICollection<TC_Incidente> TC_Incidente { get; set; }
        public virtual ICollection<TC_Incidente> TC_Incidente1 { get; set; }
    }
}
