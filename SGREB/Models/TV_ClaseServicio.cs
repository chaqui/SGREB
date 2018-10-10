using System;
using System.Collections.Generic;

namespace SGREB.Models
{
    public partial class TV_ClaseServicio
    {
        public int id { get; set; }
        public string nombre { get; set; }
        public Nullable<int> idIncidente { get; set; }
        public virtual TC_Incidente TC_Incidente { get; set; }
    }
}
