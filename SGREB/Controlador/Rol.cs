
using SGREB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SGREB.Controlador { 

public class Rol : CRUD {

    public Rol() {
    }

    private int idRol;

    private String nombre;

        public Rol(int idRol, string nombre)
        {
            this.idRol = idRol;
            this.nombre = nombre;
        }

        public Rol(string nombre)
        {
            this.nombre = nombre;
        }

        public void Crear()
        {
            var bitacora = new bitacoraBomberoaContext();
            var tvRol = new TV_Rol();
            tvRol.nombre = this.nombre;
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

        public Rol obtener(int? id)
        {
            var bitacora = new bitacoraBomberoaContext();
            var roles = bitacora.TV_Rol.Where(s=>s.idRol==id);
            foreach( var rol in roles)
            {
                return new Rol(rol.idRol,rol.nombre);
            }
            return null;
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

        List<object> CRUD.obtenerVarios()
        {
            throw new NotImplementedException();
        }
    }
}