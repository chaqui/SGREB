using System;
using System.Collections.Generic;

namespace SGREB.Models
{
    public partial class TV_Grado
    {
        public TV_Grado()
        {
            this.TC_Bombero = new List<TC_Bombero>();
        }

        public int idGrado { get; set; }
        public string nombreGrado { get; set; }
        public virtual ICollection<TC_Bombero> TC_Bombero { get; set; }
    }
}
