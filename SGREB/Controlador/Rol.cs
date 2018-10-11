
using SGREB.Models;
using System.Collections.Generic;
using System.Linq;

namespace SGREB.Controlador
{


    public class Rol  {

        public Rol() {
        }

        public void Crear(TV_Rol tvRol)
        {
            var bitacora = new bitacoraBomberoaContext();
            bitacora.TV_Rol.Add(tvRol);
            bitacora.SaveChanges();
            
        }
        public TV_Rol obtener(int? id)
        {
            var bitacora = new bitacoraBomberoaContext();
            var rol = bitacora.TV_Rol.Where(s=>s.idRol==id).Single();
            return rol;
        }

        public List<TV_Rol> obtenerVarios()
        {
            var bitacora = new bitacoraBomberoaContext();
            var roles = bitacora.TV_Rol;
            return roles.ToList();

        }

        public TV_Rol obtener(string nombre)
        {
            var bitacora = new bitacoraBomberoaContext();
            var rol = bitacora.TV_Rol.Where(s => s.nombre == nombre).Single();
            return rol;
        }
    }
}