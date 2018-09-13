using System;
using System.Collections.Generic;

namespace SGREB.Models
{
    public partial class TV_TipoVehiculo
    {
        public TV_TipoVehiculo()
        {
            this.TC_AccidenteTransito = new List<TC_AccidenteTransito>();
            this.TC_VehiculoIncendiado = new List<TC_VehiculoIncendiado>();
        }

        public int idTipoVehiculo { get; set; }
        public string tipo { get; set; }
        public virtual ICollection<TC_AccidenteTransito> TC_AccidenteTransito { get; set; }
        public virtual ICollection<TC_VehiculoIncendiado> TC_VehiculoIncendiado { get; set; }
    }
}
