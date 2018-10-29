
using SGREB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SGREB.Controlador { 
public class TipoServicio  {

    /// <summary>
    /// clase para administrar la tabla de tipo de Servicio
    /// </summary>
    public TipoServicio() {
    }
        /// <summary>
        /// crear tipo de Servicio
        /// </summary>
        /// <param name="tvTipoServicio"></param>
        /// <returns></returns>
        public int crear(TV_TipoServicio tvTipoServicio)
        {
            var bitacora = new bitacoraBomberoaContext();
            bitacora.TV_TipoServicio.Add(tvTipoServicio);
            bitacora.SaveChanges();
            return tvTipoServicio.idTipoServicio;
        }

        /// <summary>
        /// Modifiar el tipo de Servicio
        /// </summary>
        /// <param name="tvTipoIncidente"></param>
        public void Modificar(TV_TipoServicio tvTipoServicio)
        {
            using (var bitacora = new bitacoraBomberoaContext())
            {
                var tvTipoIncidenteM = bitacora.TV_TipoServicio.Find(tvTipoServicio.idTipoServicio);
                tvTipoIncidenteM.nombre = tvTipoServicio.nombre;
                bitacora.SaveChanges();
            }
        }

        /// <summary>
        /// obtener el tipo de incidente por su id
        /// </summary>
        /// <param name="id">id del tipo de servicio</param>
        /// <returns>TV_TipoIncidente encontrado</returns>
        public TV_TipoServicio obtener(int id)
        {
            var bitacora = new bitacoraBomberoaContext();
            var tvTipoServicio = bitacora.TV_TipoServicio.Where(s => s.idTipoServicio == id).Single();
            return tvTipoServicio;
        }

        /// <summary>
        /// obtener todos los servicios
        /// </summary>
        /// <returns>Lista de TV_TipoIncidente</returns>
        public List<TV_TipoServicio> obtenerTodos()
        {
            var bitacora = new bitacoraBomberoaContext();
            var tvTipoIncidentes = bitacora.TV_TipoServicio;
            return tvTipoIncidentes.ToList();
        }

        internal void eliminar(int id)
        {
            var seleccionado = obtener(id);
            bitacoraBomberoaContext context = new bitacoraBomberoaContext();
            context.TV_TipoServicio.Remove(seleccionado);
            context.SaveChanges();
        }
    }
}