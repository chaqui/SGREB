using System;
using System.Collections.Generic;

namespace SGREB.Models
{
    public partial class TC_Incidente
    {
        public TC_Incidente()
        {
            this.TC_AccidenteTransito = new List<TC_AccidenteTransito>();
            this.TC_HechoDeViolencia = new List<TC_HechoDeViolencia>();
            this.TC_Incendio = new List<TC_Incendio>();
            this.TC_Maternidad = new List<TC_Maternidad>();
            this.TC_Rastreo = new List<TC_Rastreo>();
            this.TC_servicioVarios = new List<TC_servicioVarios>();
            this.TC_Suicidio = new List<TC_Suicidio>();
            this.TC_UnidadParaIncidente = new List<TC_UnidadParaIncidente>();
            this.TC_VehiculoIncendiado = new List<TC_VehiculoIncendiado>();
            this.TC_ViviendaInundada = new List<TC_ViviendaInundada>();
            this.TC_ServicioDeGalones = new List<TC_ServicioDeGalones>();
            this.TC_Paciente = new List<TC_Paciente>();
            this.TV_CausaEnfermedadComun = new List<TV_CausaEnfermedadComun>();
            this.TC_Bombero = new List<TC_Bombero>();
        }

        public int idIncidente { get; set; }
        public Nullable<int> tipoIncidente { get; set; }
        public Nullable<int> lugar { get; set; }
        public Nullable<System.DateTime> Fecha { get; set; }
        public Nullable<int> solicitud { get; set; }
        public Nullable<System.TimeSpan> HoraEntrada { get; set; }
        public Nullable<System.TimeSpan> horaSalida { get; set; }
        public virtual ICollection<TC_AccidenteTransito> TC_AccidenteTransito { get; set; }
        public virtual ICollection<TC_HechoDeViolencia> TC_HechoDeViolencia { get; set; }
        public virtual ICollection<TC_Incendio> TC_Incendio { get; set; }
        public virtual TC_Solicitud TC_Solicitud { get; set; }
        public virtual TT_Lugar TT_Lugar { get; set; }
        public virtual TV_TipoIncidente TV_TipoIncidente { get; set; }
        public virtual ICollection<TC_Maternidad> TC_Maternidad { get; set; }
        public virtual ICollection<TC_Rastreo> TC_Rastreo { get; set; }
        public virtual ICollection<TC_servicioVarios> TC_servicioVarios { get; set; }
        public virtual ICollection<TC_Suicidio> TC_Suicidio { get; set; }
        public virtual ICollection<TC_UnidadParaIncidente> TC_UnidadParaIncidente { get; set; }
        public virtual ICollection<TC_VehiculoIncendiado> TC_VehiculoIncendiado { get; set; }
        public virtual ICollection<TC_ViviendaInundada> TC_ViviendaInundada { get; set; }
        public virtual ICollection<TC_ServicioDeGalones> TC_ServicioDeGalones { get; set; }
        public virtual ICollection<TC_Paciente> TC_Paciente { get; set; }
        public virtual ICollection<TV_CausaEnfermedadComun> TV_CausaEnfermedadComun { get; set; }
        public virtual ICollection<TC_Bombero> TC_Bombero { get; set; }
    }
}
