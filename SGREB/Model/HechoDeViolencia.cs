
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SGREB.Model
{

    public class HechoDeViolencia : Incidente
    {
        public int idHechoDeViolencia { set; get; }

        public bool armaDeFuego { set; get; }

        public bool armaBlanca { set; get; }

        public HechoDeViolencia()
        {
        }

   
        

    }
}