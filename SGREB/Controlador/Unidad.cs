
using SGREB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SGREB.Controlador
{
    public class Unidad {

        public Unidad() {
        }

        /// <summary>
        /// crear unidad
        /// </summary>
        /// <param name="tC_Unidad"></param>
        /// <returns></returns>
        public string crear(TC_Unidad tC_Unidad)
        {
            var bitacora = new bitacoraBomberoaContext();
            bitacora.TC_Unidad.Add(tC_Unidad);
            bitacora.SaveChanges();
            return tC_Unidad.placa;
        }



    }
}