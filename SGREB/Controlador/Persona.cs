
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

        protected string nombre;

        protected String apellido;

        protected String DPI;

        protected int id;

        /// <summary>
        /// constructor para la creación
        /// </summary>
        /// <param name="nombre"> todos los nombres de la persona</param>
        /// <param name="apellido">todos los apellidos de la persona</param>
        /// <param name="dPI"> el dpi de la persona</param>
        public Persona(string nombre, string apellido, string dPI)
        {
            this.nombre = nombre;
            this.apellido = apellido;
            DPI = dPI;
        }
        /// <summary>
        /// constructor para la actualización y selección 
        /// por eso incluye todos sus elementos
        /// </summary>
        /// <param name="nombre"></param>
        /// <param name="apellido"></param>
        /// <param name="dPI"></param>
        /// <param name="id">id de la persona en la tabla de la base de datos</param>

        public Persona(string nombre, string apellido, string dPI, int id) : this(nombre, apellido, dPI)
        {
            this.id = id;
        }

        /// <summary>
        /// crear una persona en la base de datos
        /// </summary>
        /// <returns type="int">retorna el id de la persona </returns>
        public int Crear()
        {
            var bitacora = new bitacoraBomberoaContext();
            var tcPersona = new TC_Persona();
            tcPersona.nombres = this.nombre;
            tcPersona.apellidos = this.apellido;
            if (this.DPI != "")
            {
                tcPersona.dpi = this.DPI;
            }
            bitacora.TC_Persona.Add(tcPersona);
            bitacora.SaveChanges();
            return tcPersona.idPersona;
        }

        /// <summary>
        /// modifica la persona seleccionada por su id 
        /// </summary>
        /// <param name="persona">todos elementos de la persona 
        /// a modificar</param>
        public void modificar(Persona persona)
        {
            using (var bitacora = new bitacoraBomberoaContext())
            {
                var tcPersona = bitacora.TC_Persona.Find(persona.id);
                tcPersona.nombres = persona.nombre;
                tcPersona.apellidos = persona.apellido;
                tcPersona.dpi = persona.DPI;
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
            return tcPersona;
        }
    }
}