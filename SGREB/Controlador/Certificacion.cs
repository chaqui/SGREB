using SGREB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGREB.Controlador
{
    public class Certificacion
    {
        public Certificacion()
        {

        }

        public int crear(TC_Certificacion certificacion)
        {
            var bitacora = new bitacoraBomberoaContext();
            bitacora.TC_Certificacion.Add(certificacion);
            bitacora.SaveChanges();
            return certificacion.idCertificacion;
        }
    }
}
