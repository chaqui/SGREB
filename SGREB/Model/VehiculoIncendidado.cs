
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SGREB.Model
{
    public class VehiculoIncendidado : Incidente
    {
        public int idVehiculoIncendiado { set; get; }

        public String vehiculo { set; get; }

        public String placa { set; get; }
        public VehiculoIncendidado()
        {
        }

    }
}