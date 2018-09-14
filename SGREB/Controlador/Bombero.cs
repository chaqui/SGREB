
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
        /// constructor para la actualización y seleción de bombero
        /// </summary>
        /// <param name="idBombero"></param>
        /// <param name="nombre"></param>
        /// <param name="apellidos"></param>
        /// <param name="dpi"></param>
        /// <param name="idRol"></param>
        /// <param name="idGrado"></param>
        public Bombero(string idBombero, string nombre, string apellidos, string dpi, int idRol, int idGrado):base(nombre,apellidos,dpi)
        {
            this.idBombero = idBombero;

            this.idGrado = idGrado;
            this.idRol = idRol;
        }

        protected string idBombero { set; get; }
        protected int idRol { set; get; }
        protected int idGrado { set; get; }

        /// <summary>
        /// creacion de bombero
        /// </summary>
        public new void Crear()
        {
            int idPersona = base.Crear();

            var bitacora = new bitacoraBomberoaContext();
            var tcBombero = new TC_Bombero();
            tcBombero.persona = idPersona;
            tcBombero.grado = idGrado;
            tcBombero.rol = idRol;
            bitacora.TC_Bombero.Add(tcBombero);
            bitacora.SaveChanges();
        }


        /// <summary>
        /// modificar bombero en la base de datos
        /// </summary>
        /// <param name="bombero">Bombero a modificar</param>
        public void modificar(Bombero bombero)
        {
            using (var bitacora = new bitacoraBomberoaContext())
            {
                var tcBombero = bitacora.TC_Bombero.Find(bombero.id);
                base.modificar(new Persona(bombero.nombre, bombero.apellido, bombero.DPI, tcBombero.persona));
                tcBombero.rol = bombero.idRol;
                tcBombero.grado = bombero.idGrado;
                bitacora.SaveChanges();
            }
        }

        /// <summary>
        /// obtenr bombero por su id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public  Bombero Obtener(string id)
        {
            
            var bitacora = new bitacoraBomberoaContext();
            var tcBombero = bitacora.TC_Bombero.Where(s => s.idBombero == id).Single();
            if(tcBombero != null)
            {
                var tcPersona = base.obtener(tcBombero.persona);
                Bombero bombero = new Bombero(tcBombero.idBombero, tcPersona.nombres, tcPersona.apellidos, tcPersona.dpi, int.Parse(tcBombero.rol.ToString()), int.Parse(tcBombero.grado.ToString()));
                return bombero;
            }
            return null;
          

        }

        /// <summary>
        /// obter todos los bomberos de la base de datos con la información de persona
        /// </summary>
        /// <returns>lista de bomberos encontrados en la base de datos</returns>
        public  List<Bombero> obtenerVarios()
        {
            List<Bombero> bomberos = new List<Bombero>();
            var bitacora = new bitacoraBomberoaContext();
            var tcBomberos = bitacora.TC_Bombero;
            foreach (var tcBombero in tcBomberos)
            {
                var tcPersona = base.obtener(tcBombero.persona);
                Bombero bombero = new Bombero(tcBombero.idBombero, tcPersona.nombres, tcPersona.apellidos, tcPersona.dpi, int.Parse(tcBombero.rol.ToString()), int.Parse(tcBombero.grado.ToString()));
                bomberos.Add(bombero);
            }

            return bomberos;
        }
    }
}
