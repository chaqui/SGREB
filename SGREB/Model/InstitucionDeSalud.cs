
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace SGREB.Model
{
    public class InstitucionDeSalud:CRUD
    {
        public int idInstitucion { set; get; }

        public int nombre { set; get; }
        public InstitucionDeSalud()
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