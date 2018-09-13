using System;
using System.Collections.Generic;

namespace SGREB.Models
{
    public partial class TV_InstitucionDeSalud
    {
        public TV_InstitucionDeSalud()
        {
            this.TC_Maternidad = new List<TC_Maternidad>();
            this.TT_Lugar = new List<TT_Lugar>();
        }

        public int idInstitucion { get; set; }
        public string nombre { get; set; }
        public virtual ICollection<TC_Maternidad> TC_Maternidad { get; set; }
        public virtual ICollection<TT_Lugar> TT_Lugar { get; set; }
    }
}
