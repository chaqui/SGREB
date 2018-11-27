using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGREB.miscellany
{
    class DataGridAnimalDatos : DataGridPadre
    {
      
        public string lugar { set; get; }
        public string claseAnimal { set; get; }
        public string sexo { set; get; }
        public string edad { set; get; }
        public string vivo { set; get; }
        public string fallecido { set; get; }
    }
}
