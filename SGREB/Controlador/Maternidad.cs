
using SGREB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SGREB.Controlador { 

public class Maternidad  {

    public Maternidad() {
    }
    
    /// <summary>
    /// crear el incidente de Maternidad
    /// </summary>
    /// <param name="maternidad"></param>
    /// <returns></returns>
    public int crear(TC_Maternidad maternidad)
        {
            var bitacora = new bitacoraBomberoaContext();
            bitacora.TC_Maternidad.Add(maternidad);
            bitacora.SaveChanges();
            return maternidad.idMaternidad;
        }

}
}