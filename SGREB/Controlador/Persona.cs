
using SGREB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SGREB.Controlador
{ 
    /// <summary>
    /// 
    /// </summary>
public class Persona  {

    public Persona() {
    }

    protected string nombre;

    protected String apellido;
     
    protected String DPI;

        protected int id;
        public Persona(string nombre, string apellido, string dPI)
        {
            this.nombre = nombre;
            this.apellido = apellido;
            DPI = dPI;
        }

        public Persona(string nombre, string apellido, string dPI, int id) : this(nombre, apellido, dPI)
        {
            this.id = id;
        }

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

        public void Eliminar(int id)
        {
            throw new NotImplementedException();
        }


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


        public TC_Persona obtener(int id)
        {
            var bitacora = new bitacoraBomberoaContext();
            var tcPersona = bitacora.TC_Persona.Where(s => s.idPersona == id).Single();
            return tcPersona;
        }

        public List<object> obtenerVarios()
        {
            throw new NotImplementedException();
        }

  
}