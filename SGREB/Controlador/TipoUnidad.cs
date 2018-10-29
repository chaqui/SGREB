
using SGREB.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SGREB.Controlador
{
    /// <summary>
    /// clase para administrar la tabla TV_Unidad
    /// </summary>
    public class TipoUnidad  {

        /// <summary>
        /// constructor para funcionalidades de la clase
        /// </summary>
        public TipoUnidad() {}

        /// <summary>
        /// crear el tipo de unidad en la base de datos
        /// </summary>
        /// <param name="tvTipoUnidad"></param>
        public void Crear(TV_TipoUnidad tvTipoUnidad)
        {
            var bitacora = new bitacoraBomberoaContext();
            bitacora.TV_TipoUnidad.Add(tvTipoUnidad);
            bitacora.SaveChanges();
        }

        /// <summary>
        /// seleccionar el tipo de unidad por su id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public TV_TipoUnidad obtener(int? id)
        {
            var bitacora = new bitacoraBomberoaContext();
            var tipo = bitacora.TV_TipoUnidad.Where(s => s.idTipoUnidad == id).Single();
            return tipo;
        }

        /// <summary>
        /// obtener tda la lista de tipos de unidades
        /// </summary>
        /// <returns></returns>
        public List<TV_TipoUnidad> obtenerVasrios()
        {
            var bitacora = new bitacoraBomberoaContext();
            var tipos = bitacora.TV_TipoUnidad;
            return tipos.ToList();
        }

        internal void eliminar(int id)
        {
            var seleccionado = obtener(id);
            bitacoraBomberoaContext context = new bitacoraBomberoaContext();
            context.TV_TipoUnidad.Remove(seleccionado);
            context.SaveChanges();
        }

        internal void modificar(TV_TipoUnidad tvTipoUnidad)
        {
            using (var bitacora = new bitacoraBomberoaContext())
            {
                var tvTipoUnidadModificar = bitacora.TV_TipoUnidad.Find(tvTipoUnidad.idTipoUnidad);
                tvTipoUnidadModificar.nombreTipo = tvTipoUnidad.nombreTipo;
                bitacora.SaveChanges();
            }
        }
    }
}