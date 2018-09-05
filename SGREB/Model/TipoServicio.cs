
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SGREB.Model
{
    public class TipoServicio : CRUD
    {
        public int idServicio { set; get; }
        public String nombre { set; get; }

        public TipoServicio(int idServicio, string nombre)
        {
            this.idServicio = idServicio;
            this.nombre = nombre;
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