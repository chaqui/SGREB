
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SGREB.Model
{


    public class Persona : CRUD
    {
        protected String nombre { set; get; }

        protected String apellido { set; get; }

        protected String DPI { set; get; }

        public Persona()
        {
        }
        public Persona(String nombre, String apellido, String dpi)
        {
            this.nombre = nombre;
            this.apellido = apellido;
            this.DPI = DPI;
        }

        public void crear()
        {
            throw new NotImplementedException();
        }

        public void eliminar(int id)
        {
            throw new NotImplementedException();
        }

        public void modificar(int id)
        {
            throw new NotImplementedException();
        }

        public object obtener(int id)
        {
            throw new NotImplementedException();
        }

        public List<object> obtenerVarios()
        {
            throw new NotImplementedException();
        }
    }
}