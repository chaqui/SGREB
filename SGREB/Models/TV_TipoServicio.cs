using System;
using System.Collections.Generic;

namespace SGREB.Models
{
    public partial class TV_TipoServicio
    {
        public TV_TipoServicio()
        {
            this.TC_servicioVarios = new List<TC_servicioVarios>();
        }

        public int idTipoServicio { get; set; }
        public string nombre { get; set; }
        public virtual ICollection<TC_servicioVarios> TC_servicioVarios { get; set; }
    }
}
