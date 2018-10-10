using System;
using System.Collections.Generic;

namespace SGREB.Models
{
    public partial class TC_Unidad
    {
        public TC_Unidad()
        {
            this.TC_UnidadParaIncidente = new List<TC_UnidadParaIncidente>();
        }

        public string placa { get; set; }
        public Nullable<int> estado { get; set; }
        public Nullable<int> tipo { get; set; }
        public virtual TV_TipoUnidad TV_TipoUnidad { get; set; }
        public virtual ICollection<TC_UnidadParaIncidente> TC_UnidadParaIncidente { get; set; }
    }
}
