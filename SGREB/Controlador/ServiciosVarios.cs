
using SGREB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SGREB.Controlador {
public class ServiciosVarios  {

    public ServiciosVarios() {
    }

        public void Crear(TC_servicioVarios tcServiciosVarios)
        {
            var bitacora = new bitacoraBomberoaContext();
            bitacora.TC_servicioVarios.Add(tcServiciosVarios);
            bitacora.SaveChanges();
        }


    }
}