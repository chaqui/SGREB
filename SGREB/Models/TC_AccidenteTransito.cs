using System;
using System.Collections.Generic;

namespace SGREB.Models
{
    public partial class TC_AccidenteTransito
    {
        public int idAccidente { get; set; }
        public int idIncidente { get; set; }
        public int tipoVehiculo { get; set; }
        public string placa { get; set; }
        public virtual TC_Incidente TC_Incidente { get; set; }
        public virtual TV_TipoVehiculo TV_TipoVehiculo { get; set; }
    }
}
