
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SGREB.Model
{
    public class VehiculoAccidentado : Incidente
    {

        public VehiculoAccidentado()
        {
        }

        public int idAccidente { set; get; }

        public String placa { set; get; }



    }
}