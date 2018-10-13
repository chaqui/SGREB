
using SGREB.Models;
using System.Collections.Generic;
using System.Linq;

namespace SGREB.Controlador
{
    public class Lugar  {
        /// <summary>
        /// 
        /// </summary>
        public Lugar() {
        }
        /// <summary>
        /// crear un lugar en la base de datos
        /// </summary>
        /// <param name="tT_Lugar"></param>
        public int crear(TT_Lugar tT_Lugar)
        {
            var bitacora = new bitacoraBomberoaContext();
            bitacora.TT_Lugar.Add(tT_Lugar);
            bitacora.SaveChanges();
            return tT_Lugar.idLugar;
        }

        public TT_Lugar obtener(int id)
        {
            var bitacora = new bitacoraBomberoaContext();
            var lugar = bitacora.TT_Lugar.Where(s => s.idLugar == id).Single();
            return lugar;
        }
        /// <summary>
        /// obtener todos los lugares 
        /// </summary>
        /// <returns></returns>
        public List<TT_Lugar> obtenerVarios()
        {
            var bitacora = new bitacoraBomberoaContext();
            var ttLugares = bitacora.TT_Lugar;
            return ttLugares.ToList();
        }

        /// <summary>
        /// modificar el lugar seleccionado
        /// </summary>
        /// <param name="ttLugar"> el lugar a modificar</param>
        public void modificar(TT_Lugar ttLugar)
        {

            using (var bitacora = new bitacoraBomberoaContext())
            {
                var tt_Lugar = bitacora.TT_Lugar.Find(ttLugar.idLugar);
                tt_Lugar.direccion = tt_Lugar.direccion;
                bitacora.SaveChanges();
            }
        }

        /// <summary>
        /// obtener los lugares  bajo la direccion
        /// </summary>
        /// <param name="direccion"></param>
        /// <returns>lista de lugares</returns>
        public List<TT_Lugar> obtener(string direccion)
        {
            var bitacora = new bitacoraBomberoaContext();
            var tt_Lugar = bitacora.TT_Lugar.Where(s => s.direccion == direccion);
            return tt_Lugar.ToList();
        }

        public List<TT_Lugar> obtenerVariasInstituciones()
        {
            var bitacora = new bitacoraBomberoaContext();
            var tt_Lugar = bitacora.TT_Lugar.Where(s => s.institucio != "");
            return tt_Lugar.ToList();
        }
    }
}