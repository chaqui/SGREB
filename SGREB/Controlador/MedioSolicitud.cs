using SGREB.Models;
using System.Collections.Generic;
using System.Linq;
namespace SGREB.Controlador
{
    /// <summary>
    /// Clase para controlar las actividades en la tabla TV_MedioSolicitud
    /// </summary>
    public class MedioSolicitud  {
        /// <summary>
        /// Constructor para crear objetos de funcionalidades
        /// </summary>
        public MedioSolicitud() {

        }
        /// <summary>
        /// crear tvMedioSolucitud en la base de datos 
        /// </summary>
        /// <param name="tvMedioSolicitud"></param>
        /// <returns>id del Medio de Solicitud creado</returns>
        public int crear(TV_MedioSolicitud tvMedioSolicitud)
        {
            var bitacora = new bitacoraBomberoaContext();
            bitacora.TV_MedioSolicitud.Add(tvMedioSolicitud);
            bitacora.SaveChanges();
            return tvMedioSolicitud.idSolicitud;
        }

        /// <summary>
        /// modificar tvMedioSolicitud
        /// </summary>
        /// <param name="tvMedioSolicitud"></param>

        public void Modificar(TV_MedioSolicitud tvMedioSolicitud)
        {
            using (var bitacora = new bitacoraBomberoaContext())
            {
                var tvMedioSolicitudM = bitacora.TV_MedioSolicitud.Find(tvMedioSolicitud.idSolicitud);
                tvMedioSolicitudM.medio = tvMedioSolicitud.medio;
                bitacora.SaveChanges();
            }
        }

        /// <summary>
        /// obrtiene todos los Medios
        /// </summary>
        /// <returns>Lista de tvMedioSolicitudM
        /// que se encuentran en la Base de Datos</returns>
        public List<TV_MedioSolicitud> obtenerTodos()
        {
            var bitacora = new bitacoraBomberoaContext();
            var tvMedioSolicitud = bitacora.TV_MedioSolicitud;
            return tvMedioSolicitud.ToList();
        }

        /// <summary>
        /// obtien el medio de Solicitud por su Id
        /// </summary>
        /// <param name="id">id del Medio de solicitud</param>
        /// <returns>Objeto con la información de medio de solicitud</returns>
        public TV_MedioSolicitud obtener(int id)
        {
            var bitacora = new bitacoraBomberoaContext();
            var tV_MedioSolicitud = bitacora.TV_MedioSolicitud.Where(s => s.idSolicitud == id).Single();
            return tV_MedioSolicitud;
        }

        /// <summary>
        /// obtiene el medio de solicitud por su nombre
        /// </summary>
        /// <param name="nombre">nombre del medio a buscar</param>
        /// <returns>lista de medios de solicitud que contienen el nombre</returns>
        public List<TV_MedioSolicitud> obtener(string nombre)
        {
            var bitacora = new bitacoraBomberoaContext();
            var tV_MedioSolicitud = bitacora.TV_MedioSolicitud.Where(s => s.medio == nombre);
            return tV_MedioSolicitud.ToList();
        }

    
    }
}