
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace SGREB.Model
{
    public class Rol : CRUD
    {

        public Rol()
        {
        }

        public int idRol { set; get; }

        public String nombre { set; get; }

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