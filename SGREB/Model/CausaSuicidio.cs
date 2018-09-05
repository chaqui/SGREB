
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace SGREB.Model
{


    public class CausaSuicidio : CRUD
    {
        public int idCausa { set; get; }
        public string nombreCausaSuicidio { set; get; }

        public CausaSuicidio()
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