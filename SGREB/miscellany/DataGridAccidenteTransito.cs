using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGREB.miscellany
{
    public class DataGridAccidenteTransito: DataGridPadre
    {
        public string lugar { set; get; }
        public string tipoVehiculo { set; get; }
        public string herido { set; get; }
        public string fallecido { set; get; }
        public string sexo { set; get; }
    }
}
