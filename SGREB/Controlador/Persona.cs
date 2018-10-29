
using SGREB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SGREB.Controlador
{
    /// <summary>
    /// clase para la manipulación de la tabla TC_Persona
    /// de la base de datos
    /// </summary>
    public class Persona
    {

        /// <summary>
        /// constructor para las funcionalidades de la clase
        /// </summary>
        public Persona()
        {
        }


        /// <summary>
        /// crear una persona en la base de datos
        /// </summary>
        /// <returns type="int">retorna el id de la persona </returns>
        public int Crear(TC_Persona tcPersona)
        {
            var bitacora = new bitacoraBomberoaContext();
            bitacora.TC_Persona.Add(tcPersona);
            bitacora.SaveChanges();
            return tcPersona.idPersona;
        }

        /// <summary>
        /// modifica la persona seleccionada por su id 
        /// </summary>
        /// <param name="persona">todos elementos de la persona 
        /// a modificar</param>
        public void modificar(TC_Persona tcPersona)
        {
            using (var bitacora = new bitacoraBomberoaContext())
            {
                var tcPersonaM = bitacora.TC_Persona.Find(tcPersona.idPersona);
                tcPersonaM.nombres = tcPersona.nombres;
                tcPersonaM.apellidos = tcPersona.apellidos;
                tcPersonaM.dpi = tcPersona.dpi;
                bitacora.SaveChanges();
            }
        }

        /// <summary>
        /// obtener todas las personas por su id 
        /// </summary>
        /// <param name="id">id de la persona a buscar</param>
        /// <returns>persona seleccionada por su id</returns>
        public TC_Persona obtener(int id)
        {
            var bitacora = new bitacoraBomberoaContext();
            var tcPersona = bitacora.TC_Persona.Where(s => s.idPersona == id).Single();
            tcPersona.apellidos = tcPersona.apellidos.TrimEnd();
            tcPersona.nombres = tcPersona.nombres.TrimEnd();
            return tcPersona;
        }
    }
}