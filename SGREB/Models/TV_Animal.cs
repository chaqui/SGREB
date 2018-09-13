using System;
using System.Collections.Generic;

namespace SGREB.Models
{
    public partial class TV_Animal
    {
        public TV_Animal()
        {
            this.TC_Paciente = new List<TC_Paciente>();
        }

        public int idAnimal { get; set; }
        public string tipo { get; set; }
        public virtual ICollection<TC_Paciente> TC_Paciente { get; set; }
    }
}
