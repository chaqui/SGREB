
using SGREB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace SGREB.Controlador {

    /// <summary>
    /// clase para controlar las acciones a la tabla incidente
    /// </summary>
    public class Incidente {
        /// <summary>
        /// constructor para fucnionalidades
        /// </summary>
        public Incidente() {
        }

        /// <summary>
        /// constructor para crear 
        /// </summary>
        /// <param name="fecha"> fecha del incidente</param>
        /// <param name="horaEntrada">hora de entrada de la unidad</param>
        /// <param name="horaSalida"> hora de salida de la unidad</param>
        /// <param name="tipoIncidente">el id del tipo de incidente</param>
        /// <param name="lugar"> el id del lugar</param>
        public Incidente(DateTime? fecha, TimeSpan? horaEntrada, TimeSpan? horaSalida, int? tipoIncidente, int? lugar, int? solicitud)
        {
            this.fecha = fecha;
            HoraEntrada = horaEntrada;
            HoraSalida = horaSalida;
            this.tipoIncidente = tipoIncidente;
            this.lugar = lugar;
            this.solicitud = solicitud;
        }

        /// <summary>
        /// constructor para seleccionar y modificar
        /// </summary>
        /// <param name="fecha"></param>
        /// <param name="horaEntrada"></param>
        /// <param name="horaSalida"></param>
        /// <param name="idIncidente">Id del incidente solo para la seleccion y modificacion</param>
        /// <param name="tipoIncidente"></param>
        /// <param name="lugar"></param>
        public Incidente(DateTime? fecha, TimeSpan? horaEntrada, TimeSpan? horaSalida, int? idIncidente, int? tipoIncidente, int? lugar, int? incidente, int? solicitud) : this(fecha, horaEntrada, horaSalida, tipoIncidente, lugar, solicitud)
        {
            this.idIncidente = idIncidente;
        }




        protected DateTime? fecha { set; get; }

        protected TimeSpan? HoraEntrada { set; get; }

        protected TimeSpan? HoraSalida { set; get; }

        protected int? idIncidente { set; get; }

        protected int? tipoIncidente { set; get; }

        protected int? lugar { set; get; }

        protected int? solicitud { set; get; }
        /// <summary>
        /// crear un incidente en la base de datos
        /// </summary>
        /// <returns> retorna el id del incidente creado</returns>
        protected int crear()
        {
            var bitacora = new bitacoraBomberoaContext();
            var tcIncidente = new TC_Incidente();
            tcIncidente.tipoIncidente = tipoIncidente;
            tcIncidente.lugar = lugar;
            tcIncidente.Fecha = fecha;
            tcIncidente.solicitud = solicitud;
            tcIncidente.horaSalida = HoraSalida;
            tcIncidente.HoraEntrada = HoraEntrada;

            bitacora.TC_Incidente.Add(tcIncidente);
            bitacora.SaveChanges();
            return tcIncidente.idIncidente;
        }

        /// <summary>
        /// modificar el incidente en la base de datos
        /// </summary>
        /// <param name="incidente">inicidente a modificar</param>
        protected void modificar(Incidente incidente)
        {

            using (var bitacora = new bitacoraBomberoaContext())
            {
                var tcIncidente = bitacora.TC_Incidente.Find(incidente.idIncidente);
                tcIncidente.tipoIncidente = tipoIncidente;
                tcIncidente.lugar = lugar;
                tcIncidente.Fecha = fecha;
                tcIncidente.solicitud = solicitud;
                tcIncidente.horaSalida = HoraSalida;
                tcIncidente.HoraEntrada = HoraEntrada;
                bitacora.SaveChanges();
            }
        }

        /// <summary>
        /// obtener incidente por su id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public TC_Incidente obtener(int id)
        {
            var bitacora = new bitacoraBomberoaContext();
            var tcIncidente = bitacora.TC_Incidente.Where(s => s.idIncidente == id).Single();
            return tcIncidente;
        }

        /// <summary>
        /// obtener todos los incidentes alamacenados
        /// </summary>
        /// <returns></returns>
        public List<TC_Incidente> obtenerTodos()
        {
            var bitacora = new bitacoraBomberoaContext();
            var tC_Incidentes = bitacora.TC_Incidente;
            return tC_Incidentes.ToList();
        }
        /// <summary>
        /// obtener todos los incidentes desde lla fecha de inicio 
        /// a la de finalización
        /// </summary>
        /// <param name="fechaI"></param>
        /// <param name="fechaF"></param>
        /// <returns></returns>
        public List<TC_Incidente> obtenerTodos(DateTime fechaI, DateTime fechaF)
        {
            var bitacora = new bitacoraBomberoaContext();
            var tcIncidentes = from s in bitacora.TC_Incidente where  (s.Fecha > fechaI && s.Fecha < fechaF) select s;
            return tcIncidentes.ToList();
        }

        /// <summary>
        /// obtener todos los incidentes por el tipo
        /// </summary>
        /// <param name="idTipo">uno de los 34 tipos</param>
        /// <returns></returns>
        public List<TC_Incidente> obtenerTodos(int idTipo)
        {
            var bitacora = new bitacoraBomberoaContext();
            var tcIncidentes = bitacora.TC_Incidente.Where(s => s.tipoIncidente == idTipo);
            return tcIncidentes.ToList();
        }
    }
}