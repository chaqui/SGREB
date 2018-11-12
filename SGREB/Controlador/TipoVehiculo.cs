
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

        internal void eliminar(int id)
        {
            var seleccionado = obtener(id);
            bitacoraBomberoaContext context = new bitacoraBomberoaContext();
            context.TV_TipoVehiculo.Remove(seleccionado);
            context.SaveChanges();
        }

        public TV_TipoVehiculo obtener(int id)
        {
            var bitacora = new bitacoraBomberoaContext();
            var tipo = bitacora.TV_TipoVehiculo.Where(s => s.idTipoVehiculo == id).Single();
            return tipo;
        }

        internal void modificar(TV_TipoVehiculo tvVehiculo)
        {
            using (var bitacora = new bitacoraBomberoaContext())
            {
                var tvVehiculoModificar = bitacora.TV_TipoVehiculo.Find(tvVehiculo.idTipoVehiculo);
                tvVehiculoModificar.tipo = tvVehiculo.tipo;
                bitacora.SaveChanges();
            }
        }
    }
}