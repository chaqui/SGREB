using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGREB.miscellany
{
    public class DataGridMaternidadDatos: DataGridPadre
    {

        public string edad { set; get; }
        public string lugar { set; get;  }
        public string aborto { set; get; }
        public string lugarTraslado { set; get; }
        public string fallecido { set; get; }
        public string vivo { set; get; }
        public string parto { set; get; }
    }
}
