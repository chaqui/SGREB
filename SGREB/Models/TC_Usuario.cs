using System;
using System.Collections.Generic;

namespace SGREB.Models
{
    public partial class TC_Usuario
    {
        public TC_Usuario()
        {
            this.TC_Solicitud = new List<TC_Solicitud>();
        }

        public string nickname { get; set; }
        public string contrasenia { get; set; }
        public string bombero { get; set; }
        public string rol { get; set; }
        public virtual TC_Bombero TC_Bombero { get; set; }
        public virtual ICollection<TC_Solicitud> TC_Solicitud { get; set; }
    }
}
