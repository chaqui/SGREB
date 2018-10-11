
using SGREB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace SGREB.Controlador
{
    /// <summary>
    /// clase para gestionar las actividades de institución de salud
    /// </summary>
    public class InstitucionDeSalud
    {

        /// <summary>
        /// constructor para crear objeto de funcionalidades
        /// </summary>
        public InstitucionDeSalud()
        {
        }

        /// <summary>
        /// crar institucion en la base de datos
        /// </summary>
        /// <param name="tV_InstitucionSalud"></param>
        /// <returns></returns>
        public int crear(TV_InstitucionDeSalud tV_InstitucionSalud)
        {
            var bitacora = new bitacoraBomberoaContext();
            bitacora.TV_InstitucionDeSalud.Add(tV_InstitucionSalud);
            bitacora.SaveChanges();
            return tV_InstitucionSalud.idInstitucion;
        }

        /// <summary>
        /// modificar la institucion
        /// </summary>
        /// <param name="tV_InstitucionSalud"></param>
        public void modificar(TV_InstitucionDeSalud tV_InstitucionSalud)
        {

            using (var bitacora = new bitacoraBomberoaContext())
            {
                var tV_InstitucionSaludM = bitacora.TV_InstitucionDeSalud.Find(tV_InstitucionSalud.idInstitucion);
                tV_InstitucionSaludM.nombre = tV_InstitucionSalud.nombre;
                bitacora.SaveChanges();
            }
        }

        /// <summary>
        /// obtener todos los registros de l base de datos
        /// </summary>
        /// <returns>Lista de Instituciones</returns>
        public List<TV_InstitucionDeSalud> obtenerTodos()
        {
            var bitacora = new bitacoraBomberoaContext();
            var tV_InstitucionSalud = bitacora.TV_InstitucionDeSalud;
            return tV_InstitucionSalud.ToList();
        }

        /// <summary>
        /// obtiene la inistitucion por su id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public TV_InstitucionDeSalud obtener(int id)
        {
            var bitacora = new bitacoraBomberoaContext();
            var tV_InstitucionSalud = bitacora.TV_InstitucionDeSalud.Where(s => s.idInstitucion == id).Single();
            return tV_InstitucionSalud;
        }

        /// <summary>
        /// obtiene las instituciones por su nombre
        /// </summary>
        /// <param name="nombre"></param>
        /// <returns></returns>
        public List<TV_InstitucionDeSalud> obtener(String nombre)
        {
            var bitacora = new bitacoraBomberoaContext();
            var tV_InstitucionSalud = bitacora.TV_InstitucionDeSalud.Where(s => s.nombre == nombre);
            return tV_InstitucionSalud.ToList();
        }


    }
}