
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace SGREB.Model
{

    public interface CRUD {

         void crear();

        /// <summary>
        /// @param int id
        /// </summary>
        void eliminar( int id);

        /// <summary>
        /// @param int id
        /// </summary>
        void modificar( int id);

        /// <summary>
        /// @param int id
        /// </summary>
        Object obtener( int id);

        List<Object> obtenerVarios();

    }
}