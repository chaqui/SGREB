using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGREB.miscellany
{
    class DataGridIncendiosDatos
    {
        public int idIncidente { set; get; }
        public string Fecha{set;get;}
        public string Hora { set; get; }
        public string Cantidad { set; get; }
        public string Lugar { set; get; }
        public string propietario { set; get; }
        public string perdidas { set; get; }
        public string aguaUtilizada { set; get; }
        public string Fallecidos { set; get; }
        public string Vivos { set; get; }

    }
}
