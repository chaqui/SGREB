using System;
using System.Collections.Generic;

namespace SGREB.Models
{
    public partial class TV_TipoUnidad
    {
        public TV_TipoUnidad()
        {
            this.TC_Unidad = new List<TC_Unidad>();
        }

        public int idTipoUnidad { get; set; }
        public string nombreTipo { get; set; }
        public virtual ICollection<TC_Unidad> TC_Unidad { get; set; }
    }
}
