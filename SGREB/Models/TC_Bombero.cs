using System;
using System.Collections.Generic;

namespace SGREB.Models
{
    public partial class TC_Bombero
    {
        public TC_Bombero()
        {
            this.TC_Solicitud = new List<TC_Solicitud>();
            this.TC_UnidadParaIncidente = new List<TC_UnidadParaIncidente>();
            this.TC_Usuario = new List<TC_Usuario>();
            this.TC_Incidente = new List<TC_Incidente>();
        }

        public string idBombero { get; set; }
        public int persona { get; set; }
        public Nullable<int> rol { get; set; }
        public Nullable<int> grado { get; set; }
        public virtual TC_Persona TC_Persona { get; set; }
        public virtual TV_Grado TV_Grado { get; set; }
        public virtual TV_Rol TV_Rol { get; set; }
        public virtual ICollection<TC_Solicitud> TC_Solicitud { get; set; }
        public virtual ICollection<TC_UnidadParaIncidente> TC_UnidadParaIncidente { get; set; }
        public virtual ICollection<TC_Usuario> TC_Usuario { get; set; }
        public virtual ICollection<TC_Incidente> TC_Incidente { get; set; }
    }
}
