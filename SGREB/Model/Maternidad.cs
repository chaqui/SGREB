
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SGREB.Model
{
    public class Maternidad : Incidente
    {
        public int idMaternidad { set; get; }

        public Boolean Aborto { set; get; }

        public Boolean atencionDeParto { set; get; }

        public Boolean retencionDePlacenta { set; get; }

        public int mesesdeEmbarazo { set; get; }
        public Maternidad()
        {
        }


      


    }
}