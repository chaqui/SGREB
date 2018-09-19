
using SGREB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SGREB.Controlador { 

public class Rol  {

    public Rol() {
    }

        public void Crear(TV_Rol tvRol)
        {
            var bitacora = new bitacoraBomberoaContext();
            bitacora.TV_Rol.Add(tvRol);
            bitacora.SaveChanges();
            
        }

        public void Eliminar(int id)
        {
            throw new NotImplementedException();
        }

        public void modificar(int id)
        {
            throw new NotImplementedException();
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
        public void obtener(int id)
        {
            throw new NotImplementedException();
        }


    }
}