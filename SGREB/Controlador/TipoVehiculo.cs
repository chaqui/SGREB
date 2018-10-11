
using SGREB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SGREB.Controlador { 

public class TipoVehiculo  {

    public TipoVehiculo() {
    }

    public int idTipoVehiculo;

    public String tipo;

        public void crear(TV_TipoVehiculo tipo)
        {
            var bitacora = new bitacoraBomberoaContext();
            bitacora.TV_TipoVehiculo.Add(tipo);
            bitacora.SaveChanges();

        }

        public List<TV_TipoVehiculo> obtenerVarios()
        {
            var bitacora = new bitacoraBomberoaContext();
            var tipos = bitacora.TV_TipoVehiculo;
            return tipos.ToList();

        }

    }
}