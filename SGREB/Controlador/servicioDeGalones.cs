
using SGREB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SGREB.Controlador {
public class servicioDeGalones  {
    
    public servicioDeGalones() {
    }

    public int crear(TC_ServicioDeGalones servicio)
        {
            var bitacora = new bitacoraBomberoaContext();
            bitacora.TC_ServicioDeGalones.Add(servicio);
            bitacora.SaveChanges();
            return servicio.idServicio;
        }

}
}