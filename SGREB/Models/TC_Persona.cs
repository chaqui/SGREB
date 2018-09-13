using System;
using System.Collections.Generic;

namespace SGREB.Models
{
    public partial class TC_Persona
    {
        public TC_Persona()
        {
            this.TC_Bombero = new List<TC_Bombero>();
            this.TC_Incendio = new List<TC_Incendio>();
            this.TC_Paciente = new List<TC_Paciente>();
            this.TC_Solicitud = new List<TC_Solicitud>();
            this.TC_VehiculoIncendiado = new List<TC_VehiculoIncendiado>();
            this.TC_ViviendaInundada = new List<TC_ViviendaInundada>();
            this.TC_Paciente1 = new List<TC_Paciente>();
        }

        public int idPersona { get; set; }
        public string nombres { get; set; }
        public string apellidos { get; set; }
        public string dpi { get; set; }
        public virtual ICollection<TC_Bombero> TC_Bombero { get; set; }
        public virtual ICollection<TC_Incendio> TC_Incendio { get; set; }
        public virtual ICollection<TC_Paciente> TC_Paciente { get; set; }
        public virtual ICollection<TC_Solicitud> TC_Solicitud { get; set; }
        public virtual ICollection<TC_VehiculoIncendiado> TC_VehiculoIncendiado { get; set; }
        public virtual ICollection<TC_ViviendaInundada> TC_ViviendaInundada { get; set; }
        public virtual ICollection<TC_Paciente> TC_Paciente1 { get; set; }
    }
}
