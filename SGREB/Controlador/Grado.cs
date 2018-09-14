
using SGREB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SGREB.Controlador
{ 
    /// <summary>
    /// clase que controla las acciones para manipular 
    /// la tabla TV_Gado de la base de datos
    /// </summary>
public class Grado  {
        /// <summary>
        /// constructor para funcionalidades
        /// </summary>
        public Grado() {
        }

        private int idGrado;

        private String nombreGrado;

        /// <summary>
        /// constructor para la selección y modificación
        /// </summary>
        /// <param name="idGrado"></param>
        /// <param name="nombreGrado"></param>
        public Grado(int idGrado, string nombreGrado):this(nombreGrado)
        {
            this.idGrado = idGrado;
        }

        /// <summary>
        /// constructor para la creación
        /// </summary>
        /// <param name="nombreGrado"></param>
        public Grado(string nombreGrado)
        {
            this.nombreGrado = nombreGrado;
        }
        /// <summary>
        /// crear un grado
        /// </summary>
        public void Crear()
        {
            var bitacora = new bitacoraBomberoaContext();
            var tvGrado = new TV_Grado();
            tvGrado.nombreGrado = this.nombreGrado;
            bitacora.TV_Grado.Add(tvGrado);
            bitacora.SaveChanges();
        }


        /// <summary>
        /// modificar el grado
        /// </summary>
        /// <param name="grado">el objeto grado a modificar</param>
        public void modificar(Grado grado)
        {
            using (var bitacora = new bitacoraBomberoaContext())
            {
                var tvGrado = bitacora.TV_Grado.Find(grado.idGrado);
                tvGrado.nombreGrado= grado.nombreGrado;
                bitacora.SaveChanges();
            }
        }

        /// <summary>
        /// obtener el grado por su id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>objeto grado encontrado en la base de datos</returns>
        public TV_Grado obtener(int id)
        {
            
            var bitacora = new bitacoraBomberoaContext();
            var grado = bitacora.TV_Grado.Where(s => s.idGrado == id).Single();
            return grado;
        }

        /// <summary>
        /// obtener todas los grados almacenados en la base de datos 
        /// </summary>
        /// <returns></returns>
        public List<TV_Grado> obtenerVarios()
        {
            var bitacora = new bitacoraBomberoaContext();
            var tvGrados = bitacora.TV_Grado;
            return tvGrados.ToList();
        }
    }
}