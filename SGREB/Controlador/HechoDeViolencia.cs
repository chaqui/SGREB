
using SGREB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SGREB.Controlador
{

     /// <summary>
    /// clase para controlar las acciones en 
    /// la tabla TC_HechosDeViolencia.
    /// </summary>
    public class HechoDeViolencia:Incidente  {

        /// <summary>
        /// constructor solo para funcionalidades 
        /// </summary>
        public HechoDeViolencia() {
        }
     
        private int? idHechoDeViolencia;

        private bool? armaDeFuego;

        private bool? armaBlanca;

        /// <summary>
        /// constructor para la creación en base de datos 
        /// </summary>
        /// <param name="armaDeFuego">si fue ataque con arma de fuego</param>
        /// <param name="armaBlanca">si fue ataque con arma blanca</param>
        /// parametros de la clase padre Incidente
        /// <param name="fecha"></param>
        /// <param name="horaEntrada"></param>
        /// <param name="horaSalida"></param>
        /// <param name="tipoIncidente"></param>
        /// <param name="lugar"></param>
        /// <param name="solicitud"></param>
        public HechoDeViolencia(bool? armaDeFuego, bool? armaBlanca, DateTime? fecha, TimeSpan? horaEntrada, TimeSpan? horaSalida, int? tipoIncidente, int? lugar, int? solicitud)
            :base( fecha,  horaEntrada,  horaSalida,  tipoIncidente,  lugar,  solicitud)
        {
            this.armaDeFuego = armaDeFuego;
            this.armaBlanca = armaBlanca;
        }
        /// <summary>
        /// constructor para la actualización y seleccion
        /// </summary>
        /// parametros del anterior constructor
        /// <param name="armaDeFuego"></param>
        /// <param name="armaBlanca"></param>
        /// <param name="fecha"></param>
        /// <param name="horaEntrada"></param>
        /// <param name="horaSalida"></param>
        /// <param name="tipoIncidente"></param>
        /// <param name="lugar"></param>
        /// <param name="solicitud"></param>
        /// se le agrega solamente el siguiente
        /// <param name="idHechoDeViolencia">id de la tabla de hecho de violencia</param>
        public HechoDeViolencia(bool? armaDeFuego, bool? armaBlanca, DateTime? fecha, TimeSpan? horaEntrada, TimeSpan? horaSalida, int? tipoIncidente, int? lugar, int? solicitud, int? idHechoDeViolencia, int? idIncidente)
       : this(armaDeFuego, armaBlanca, fecha, horaEntrada, horaSalida, tipoIncidente, lugar, solicitud)
        {
            base.idIncidente = idIncidente;
            this.idHechoDeViolencia = idHechoDeViolencia;
        }

        /// <summary>
        /// Creación del incidente hecho de violencia
        /// </summary>
        /// <returns>id del Hecho de Violencia Creado</returns>
        public new int crear()
        {
            int idIncidente = base.crear();
            var bitacora = new bitacoraBomberoaContext();
            var tC_HechoDeViolencia = new TC_HechoDeViolencia();
            tC_HechoDeViolencia.idIncidente = idIncidente;
            tC_HechoDeViolencia.armaBlanca = this.armaBlanca;
            tC_HechoDeViolencia.armaDeFuego = this.armaDeFuego;  
            bitacora.TC_HechoDeViolencia.Add(tC_HechoDeViolencia);
            bitacora.SaveChanges();
            return tC_HechoDeViolencia.idHechoDeViolencia;
        }

        /// <summary>
        /// ctualiza hecho de violencia conjuntamnete con Incidente
        /// </summary>
        /// <param name="hechoDeViolencia"> el hecho de violencia a modificar</param>
        public void modificar(HechoDeViolencia hechoDeViolencia)
        {
            using (var bitacora = new bitacoraBomberoaContext())
            {
                var h = hechoDeViolencia;
                var tC_HechoDeViolencia = bitacora.TC_HechoDeViolencia.Find(hechoDeViolencia.idHechoDeViolencia);
                base.modificar(new Incidente(h.fecha,h.HoraEntrada,h.HoraSalida,h.idIncidente,h.tipoIncidente,h.lugar, h.idIncidente, h.solicitud));
                tC_HechoDeViolencia.armaBlanca = this.armaBlanca;
                tC_HechoDeViolencia.armaDeFuego = this.armaDeFuego;
                bitacora.SaveChanges();
            }
        }

        /// <summary>
        /// obtener todos los hecgos de violencia
        /// </summary>
        /// <returns>Lista de Hechos de violencia</returns>
        public List<HechoDeViolencia> obtenerVarios()
        {
            List<HechoDeViolencia> hechoDeViolencia = new List<HechoDeViolencia>();
            var bitacora = new bitacoraBomberoaContext();
            var tcHechoDeViolencias = bitacora.TC_HechoDeViolencia;
            if(tcHechoDeViolencias!= null)
            {         
                foreach (var tcHechoDeViolencia in tcHechoDeViolencias)
                {
                    var tcIcncidente = base.obtener(tcHechoDeViolencia.idIncidente);
                    HechoDeViolencia thechoDeViolencia = new HechoDeViolencia(tcHechoDeViolencia.armaDeFuego,tcHechoDeViolencia.armaBlanca,tcIcncidente.Fecha, tcIcncidente.HoraEntrada, tcIcncidente.horaSalida, tcIcncidente.tipoIncidente, tcIcncidente.lugar, tcIcncidente.solicitud, tcHechoDeViolencia.idHechoDeViolencia,tcHechoDeViolencia.idIncidente );
                    hechoDeViolencia.Add(thechoDeViolencia);
                }
            }
            return hechoDeViolencia;
        }

        /// <summary>
        /// obtner hecho de violencia por id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>hecho de violencia</returns>
        public HechoDeViolencia obtenerUno(int id)
        {

            var bitacora = new bitacoraBomberoaContext();
            var tcHechoDeViolencia = bitacora.TC_HechoDeViolencia.Where(S => S.idIncidente == id).Single();
            var tcIcncidente = base.obtener(tcHechoDeViolencia.idIncidente);
            HechoDeViolencia thechoDeViolencia = new HechoDeViolencia(tcHechoDeViolencia.armaDeFuego, tcHechoDeViolencia.armaBlanca, tcIcncidente.Fecha, tcIcncidente.HoraEntrada, tcIcncidente.horaSalida, tcIcncidente.tipoIncidente, tcIcncidente.lugar, tcIcncidente.solicitud, tcHechoDeViolencia.idHechoDeViolencia, tcHechoDeViolencia.idIncidente);
            return thechoDeViolencia;
        }

    }
}