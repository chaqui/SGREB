using System;
using System.Collections.Generic;

namespace SGREB.Models
{
    public partial class TC_Paciente
    {
        public TC_Paciente()
        {
            this.PacienteDeIncidentes = new List<PacienteDeIncidente>();
            this.TT_EvacuadoInundacion = new List<TT_EvacuadoInundacion>();
            this.TV_Animal = new List<TV_Animal>();
            this.TV_CausaIntoxicacion = new List<TV_CausaIntoxicacion>();
            this.TC_Persona1 = new List<TC_Persona>();
        }

        public int idPaciente { get; set; }
        public Nullable<int> edad { get; set; }
        public string Sexo { get; set; }
        public Nullable<bool> fallecido { get; set; }
        public Nullable<int> Persoan { get; set; }
        public Nullable<bool> herido { get; set; }
        public string domicilio { get; set; }
        public virtual ICollection<PacienteDeIncidente> PacienteDeIncidentes { get; set; }
        public virtual TC_Persona TC_Persona { get; set; }
        public virtual ICollection<TT_EvacuadoInundacion> TT_EvacuadoInundacion { get; set; }
        public virtual ICollection<TV_Animal> TV_Animal { get; set; }
        public virtual ICollection<TV_CausaIntoxicacion> TV_CausaIntoxicacion { get; set; }
        public virtual ICollection<TC_Persona> TC_Persona1 { get; set; }
    }
}
