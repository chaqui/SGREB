using SGREB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGREB.Controlador
{
    public class Incendio
    {
        public Incendio()
        {

        }

        public int crear(TC_Incendio incendio)
        {
            var bitacora = new bitacoraBomberoaContext();
            bitacora.TC_Incendio.Add(incendio);
            bitacora.SaveChanges();
            return incendio.idIncendio;
        }
    }
}
