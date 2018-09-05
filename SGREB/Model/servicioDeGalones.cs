
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SGREB.Model
{
    public class servicioDeGalones : CRUD
    {
        protected int idServicio { set; get; }

        protected int Galones { set; get; }

        protected int idIncidente { set; get; }
        public servicioDeGalones()
        {
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