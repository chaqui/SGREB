using System;
using System.Collections.Generic;

namespace SGREB.Models
{
    public partial class TC_VehiculoIncendiado
    {
        public int idVehiculoIncendiado { get; set; }
        public Nullable<int> propietario { get; set; }
        public string vehiculo { get; set; }
        public Nullable<int> tipoVehiculo { get; set; }
        public Nullable<int> idIncidente { get; set; }
        public string placa { get; set; }
        public virtual TC_Incidente TC_Incidente { get; set; }
        public virtual TC_Persona TC_Persona { get; set; }
        public virtual TV_TipoVehiculo TV_TipoVehiculo { get; set; }
    }
}
