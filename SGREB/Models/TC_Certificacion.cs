using System;
using System.Collections.Generic;

namespace SGREB.Models
{
    public partial class TC_Certificacion
    {
        public int idCertificacion { get; set; }
        public string solicitante { get; set; }
        public string profesion { get; set; }
        public Nullable<int> idSolicitud { get; set; }
        public Nullable<System.DateTime> fecha { get; set; }
        public virtual TC_Solicitud TC_Solicitud { get; set; }
    }
}
