
using SGREB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SGREB.Controlador
{
    public class Bombero : Persona
    {
       
        public Bombero()
        {
        }

        public Bombero(string idBombero, string nombre, string apellidos, string dpi, int idRol, int idGrado):base(nombre,apellidos,dpi)
        {
            this.idBombero = idBombero;

            this.idGrado = idGrado;
            this.idRol = idRol;
        }

        protected string idBombero { set; get; }
        protected int idRol { set; get; }
        protected int idGrado { set; get; }

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

        public new void Eliminar(int id)
        {
            throw new NotImplementedException();
        }

        public void modificar(Bombero bombero)
        {
            using (var bitacora = new bitacoraBomberoaContext())
            {
                var tcBombero = bitacora.TC_Bombero.Find(bombero.id);
                base.modificar(new Persona(bombero.nombre, bombero.apellido, bombero.DPI, tcBombero.persona));
                tcBombero.rol = bombero.idRol;
                tcBombero.grado = bombero.idGrado;
            }
        }

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

        public new List<Bombero> obtenerVarios()
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
