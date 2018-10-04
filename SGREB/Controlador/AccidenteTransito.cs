using SGREB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGREB.Controlador
{
    class AccidenteTransito
    {
        public AccidenteTransito()
        {

        }

        public int Crear(TC_AccidenteTransito accidente)
        {

            var bitacora = new bitacoraBomberoaContext();
            bitacora.TC_AccidenteTransito.Add(accidente);
            bitacora.SaveChanges();
            return accidente.idAccidente;
        }
    }
}
