
using SGREB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SGREB.Controlador
{
    /// <summary>
    /// clase para administrar la tabla de bombero
    /// esta hereda funcionalidades de la clase Persona
    /// </summary>
    public class Bombero : Persona
    {
       /// <summary>
       /// constructor para funcion
       /// </summary>
        public Bombero()
        {
        }
         /// <summary>
         /// 
         /// </summary>
         /// <param name="tcBombero"></param>
         public  void  Crear(TC_Bombero tcBombero) 
        {
            var bitacora = new bitacoraBomberoaContext();
            bitacora.TC_Bombero.Add(tcBombero);
            bitacora.SaveChanges();
        }


        /// <summary>
        /// modificar bombero en la base de datos
        /// </summary>
        /// <param name="bombero">Bombero a modificar</param>
        public void modificar(TC_Bombero bombero)
        {
            using (var bitacora = new bitacoraBomberoaContext())
            {
                var tcBombero = bitacora.TC_Bombero.Find(bombero.idBombero);
                tcBombero.rol = bombero.rol;
                tcBombero.grado = bombero.grado;
                bitacora.SaveChanges();
            }
        }

        /// <summary>
        /// obtenr bombero por su id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public TC_Bombero Obtener(string id)
        {
            
            var bitacora = new bitacoraBomberoaContext();
            var tcBombero = bitacora.TC_Bombero.Where(s => s.idBombero == id).Single();
            return tcBombero;
          

        }

        /// <summary>
        /// obter todos los bomberos de la base de datos con la información de persona
        /// </summary>
        /// <returns>lista de bomberos encontrados en la base de datos</returns>
        public  List<TC_Bombero> obtenerVarios()
        {
            List<Bombero> bomberos = new List<Bombero>();
            var bitacora = new bitacoraBomberoaContext();
            var tcBomberos = bitacora.TC_Bombero.ToList();
            return tcBomberos;
        }
    }
}
