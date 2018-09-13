using System;
using System.Collections.Generic;

namespace SGREB.Models
{
    public partial class TV_Rol
    {
        public TV_Rol()
        {
            this.TC_Bombero = new List<TC_Bombero>();
        }

        public int idRol { get; set; }
        public string nombre { get; set; }
        public virtual ICollection<TC_Bombero> TC_Bombero { get; set; }
    }
}
