
using SGREB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SGREB.Controlador
{
    /// <summary>
    /// Clase para administrar las interacciones con la tabla 
    /// TC_Unidad de la base de datos
    /// </summary>
    public class Unidad {

        private string[] estados;
        /// <summary>
        /// constructor para funciones
        /// </summary>
        public Unidad() {
            estados = new string[3];
            estados[0] = "en servicio";
            estados[1] = "en espera";
            estados[2] = "desperfectos mecanicos";
        }

        /// <summary>
        /// crear unidad
        /// </summary>
        /// <param name="tC_Unidad"></param>
        /// <returns></returns>
        public string crear(TC_Unidad tC_Unidad)
        {
            var bitacora = new bitacoraBomberoaContext();
            bitacora.TC_Unidad.Add(tC_Unidad);
            bitacora.SaveChanges();
            return tC_Unidad.placa;
        }

        /// <summary>
        /// obtner la unidad por su placa
        /// </summary>
        /// <param name="placa"></param>
        /// <returns></returns>
        public TC_Unidad obtener(string placa)
        {
            var bitacora = new bitacoraBomberoaContext();
            var unidad = bitacora.TC_Unidad.Where(s => s.placa == placa).Single();
            return unidad;
        }

        /// <summary>
        /// pbtener tods las unidades
        /// </summary>
        /// <returns></returns>
        public List<TC_Unidad> obtenerVarios()
        {
            var bitacora = new bitacoraBomberoaContext();
            var unidades = bitacora.TC_Unidad;
            return unidades.ToList();
        }

        public void modificar(TC_Unidad tcUnidad)
        {
            using (var bitacora = new bitacoraBomberoaContext())
            {
                var tcUnidadM = bitacora.TC_Unidad.Find(tcUnidad.placa);
                tcUnidadM.tipo = tcUnidad.tipo;
                tcUnidadM.estado = tcUnidad.estado;
                bitacora.SaveChanges();
            }
        }

        public string obtenerEstado(int? n)
        {
            if (n.HasValue)
            {
                return estados[n.Value];
            }
            return "";
        }

        public string[] obtenerEstados()
        {
            return estados;
        }

    }
}