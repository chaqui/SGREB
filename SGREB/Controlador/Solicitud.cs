
using SGREB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SGREB.Controlador
{
    public class Solicitud
    {
        /// <summary>
        /// constructor para crear objeto de funcionalidades 
        /// </summary>
        public Solicitud()
        {
        }

        /// <summary>
        /// funcion para crear la solicitud 
        /// </summary>
        /// <param name="tcSolicitud">la solicitud a almacenar</param>
        /// <returns>el id de la solicitud creada</returns>
        public int crear(TC_Solicitud tcSolicitud)
        {
            var bitacora = new bitacoraBomberoaContext();
            bitacora.TC_Solicitud.Add(tcSolicitud);
            bitacora.SaveChanges();
            return tcSolicitud.idSolicitud;
        }

        /// <summary>
        /// obtener solicitud por su id
        /// </summary>
        /// <param name="id">id de la solicitud a seleccionar</param>
        /// <returns>solicitud encontrada por su id</returns>
        public TC_Solicitud obtener(int id)
        {
            var bitacora = new bitacoraBomberoaContext();
            var solicitud = bitacora.TC_Solicitud.Where(s => s.idSolicitud == id).Single();
            return solicitud;
        }

        /// <summary>
        /// obtener todas las Solictitudes 
        /// ----PRECAUCIÓN-----
        /// </summary>
        /// <returns>lista de solicitudes alamcenadas en la base de datos</returns>
        public List<TC_Solicitud> obtenerVarios()
        {
            var bitacora = new bitacoraBomberoaContext();
            var solicitudes = bitacora.TC_Solicitud;
            return solicitudes.ToList();
        }

        /// <summary>
        /// modificar las solicitudes 
        /// </summary>
        /// <param name="tcSolicitud">solicitud a modificar</param>
        public void modificar(TC_Solicitud tcSolicitud)
        {
            using( var bitacora = new bitacoraBomberoaContext())
            {
                var tcSolicitudM = bitacora.TC_Solicitud.Find(tcSolicitud.idSolicitud);
                tcSolicitudM.TraspasoACBM = tcSolicitud.TraspasoACBM;
                tcSolicitudM.medioSolicitud = tcSolicitud.medioSolicitud;
                tcSolicitudM.solicitante = tcSolicitud.solicitante;
                bitacora.SaveChanges();
            }
        }
    }
}