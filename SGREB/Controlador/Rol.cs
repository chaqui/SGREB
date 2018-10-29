
using SGREB.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SGREB.Controlador
{


    public class Rol  {

        public Rol() {
        }

        /// <summary>
        /// crear rol
        /// </summary>
        /// <param name="tvRol"></param>
        public void Crear(TV_Rol tvRol)
        {
            var bitacora = new bitacoraBomberoaContext();
            bitacora.TV_Rol.Add(tvRol);
            bitacora.SaveChanges();
            
        }

        /// <summary>
        /// obtener rol por su id
        /// </summary>
        /// <param name="id"></param>
        /// <returns> rol encontrado</returns>
        public TV_Rol obtener(int? id)
        {
            var bitacora = new bitacoraBomberoaContext();
            var rol = bitacora.TV_Rol.Where(s=>s.idRol==id).Single();
            return rol;
        }

        internal void modificar(TV_Rol tvrol)
        {
            using (var bitacora = new bitacoraBomberoaContext())
            {
                var tRolModificar = bitacora.TV_Rol.Find(tvrol.idRol);
                tRolModificar.nombre = tRolModificar.nombre;
                bitacora.SaveChanges();
            }
        }

        /// <summary>
        /// obtiene todos los roles almacenados
        /// </summary>
        /// <returns>roles en formato List</returns>
        public List<TV_Rol> obtenerVarios()
        {
            var bitacora = new bitacoraBomberoaContext();
            var roles = bitacora.TV_Rol;
            return roles.ToList();

        }

        /// <summary>
        /// obtener el rol por su nombre
        /// </summary>
        /// <param name="nombre"></param>
        /// <returns></returns>
        public TV_Rol obtener(string nombre)
        {
            var bitacora = new bitacoraBomberoaContext();
            var rol = bitacora.TV_Rol.Where(s => s.nombre == nombre).Single();
            return rol;
        }
    }
}