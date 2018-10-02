
using SGREB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace SGREB.Controlador { 

    public class UnidadParaInicidente {

        public UnidadParaInicidente() {
        }

        public int crear(TC_UnidadParaIncidente tC_UniadParaIncidente) {
            var bitacora = new bitacoraBomberoaContext();
            bitacora.TC_UnidadParaIncidente.Add(tC_UniadParaIncidente);
            bitacora.SaveChanges();
            return tC_UniadParaIncidente.Incidente;
        }
        

    }
}