using System;
using System.Collections.Generic;

namespace SGREB.Models
{
    public partial class TV_MedioSolicitud
    {
        public TV_MedioSolicitud()
        {
            this.TC_Solicitud = new List<TC_Solicitud>();
        }

        public int idSolicitud { get; set; }
        public string medio { get; set; }
        public virtual ICollection<TC_Solicitud> TC_Solicitud { get; set; }
    }
}
