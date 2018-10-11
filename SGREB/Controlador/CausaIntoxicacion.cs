
using SGREB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SGREB.Controlador
{

    /// <summary>
    /// clase que controla las funciones 
    /// a la base de datos con la tabla 
    /// causa intoxicación
    /// </summary>
    public class CausaIntoxicacion
    {
        /// <summary>
        /// constructor para funcionalidades
        /// </summary>
        public CausaIntoxicacion()
        {
        }
        /// <summary>
        /// constructor para crear
        /// </summary>
        /// <param name="nombre"></param>
        public CausaIntoxicacion(string nombre)
        {
            this.nombre = nombre;
        }

        /// <summary>
        /// constructor para seleccionar
        /// </summary>
        /// <param name="idCausaIntoxicacion"></param>
        /// <param name="nombre"></param>

        public CausaIntoxicacion(int idCausaIntoxicacion, string nombre):this(nombre)
        {
            this.idCausaIntoxicacion = idCausaIntoxicacion;
        }

        public int idCausaIntoxicacion { set; get; }

        public String nombre { set; get; }

        /// <summary>
        /// 
        /// </summary>
        public int crear(TV_CausaIntoxicacion causa)
        {
            var bitacora = new bitacoraBomberoaContext();
            bitacora.TV_CausaIntoxicacion.Add(causa);
            bitacora.SaveChanges();
            return causa.idCausaIntoxicacion;
        }


        /// <summary>
        /// obtener todas las causas de intoxicación
        /// </summary>
        /// <returns></returns>

        public List<TV_CausaIntoxicacion> obtenerTodos()
        {
            var bitacora = new bitacoraBomberoaContext();
            var tvCausaIntoxicacion = bitacora.TV_CausaIntoxicacion;
            return tvCausaIntoxicacion.ToList();
        }

        /// <summary>
        /// obtener elemento por ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public TV_CausaIntoxicacion obtener(int id)
        {
            var bitacora = new bitacoraBomberoaContext();
            var tvCausaIntoxicacion = bitacora.TV_CausaIntoxicacion.Where(s => s.idCausaIntoxicacion == id).Single();
            return tvCausaIntoxicacion;
        }

        /// <summary>
        /// modificar la tabla causa intoxicación
        /// </summary>
        /// <param name="causaIntoxicacion"></param>
        public void modificar(CausaIntoxicacion causaIntoxicacion)
        {
            using (var bitacora = new bitacoraBomberoaContext())
            {
                var tvCausaIntoxicacion = bitacora.TV_Animal.Find(causaIntoxicacion.idCausaIntoxicacion);
                tvCausaIntoxicacion.tipo = causaIntoxicacion.nombre;
                bitacora.SaveChanges();
            }
        }




    }
}