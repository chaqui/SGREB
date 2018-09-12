
using System.Collections.Generic;

namespace SGREB.Model
{

    public class Bombero : Persona
    {
        public Rol rol { set; get; }
        public Grado grado { set; get; }
        public int idBombero { set; get; }

        public Bombero()
        {

        }

       public Bombero(string nombres, string apellidos, string dpi, Grado grado, Rol rol)
        {
            this.nombre = nombres;
            this.apellido = apellidos;
            this.DPI = dpi;
            this.grado = grado;
            this.rol = rol;
        }

    }
}