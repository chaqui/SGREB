
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
    public class HechoDeViolencia  {

        public  int crear(TC_HechoDeViolencia tcHechoDeViolencia)
        {
            var bitacora = new bitacoraBomberoaContext();
            bitacora.TC_HechoDeViolencia.Add(tcHechoDeViolencia);
            bitacora.SaveChanges();
            return tcHechoDeViolencia.idHechoDeViolencia;
        }

        /// <summary>
        /// ctualiza hecho de violencia conjuntamnete con Incidente
        /// </summary>
        /// <param name="hechoDeViolencia"> el hecho de violencia a modificar</param>
        public void modificar(TC_HechoDeViolencia hechoDeViolencia)
        {
            using (var bitacora = new bitacoraBomberoaContext())
            {
                var h = hechoDeViolencia;
                var tC_HechoDeViolencia = bitacora.TC_HechoDeViolencia.Find(hechoDeViolencia.idHechoDeViolencia);
                tC_HechoDeViolencia.armaBlanca = hechoDeViolencia.armaBlanca;
                tC_HechoDeViolencia.armaDeFuego = hechoDeViolencia.armaDeFuego;
                bitacora.SaveChanges();
            }
        }

        /// <summary>
        /// obtener todos los hecgos de violencia
        /// </summary>
        /// <returns>Lista de Hechos de violencia</returns>
        public List<TC_HechoDeViolencia> obtenerVarios()
        {
            var bitacora = new bitacoraBomberoaContext();
            var tcHechoDeViolencias = bitacora.TC_HechoDeViolencia;
            return tcHechoDeViolencias.ToList();
        }

        /// <summary>
        /// obtner hecho de violencia por id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>hecho de violencia</returns>
        public TC_HechoDeViolencia obtenerUno(int id)
        {

            var bitacora = new bitacoraBomberoaContext();
            var tcHechoDeViolencia = bitacora.TC_HechoDeViolencia.Where(S => S.idIncidente == id).Single();
            return tcHechoDeViolencia;
        }

    }
}