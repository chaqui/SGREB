using System;
using System.Collections.Generic;

namespace SGREB.Models
{
    public partial class TV_CausaIntoxicacion
    {
        public TV_CausaIntoxicacion()
        {
            this.TC_Paciente = new List<TC_Paciente>();
        }

        public int idCausaIntoxicacion { get; set; }
        public string nombre { get; set; }
        public virtual ICollection<TC_Paciente> TC_Paciente { get; set; }
    }
}
