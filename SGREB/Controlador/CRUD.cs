
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace SGREB.Controlador
{ 

public interface CRUD {

     void Crear();

    /// <summary>
    /// @param int id
    /// </summary>
     void Eliminar(int id);

    /// <summary>
    /// @param int id
    /// </summary>
     void modificar(int id);

    /// <summary>
    /// @param int id
    /// </summary>
     void obtener(int id);

     List<Object> obtenerVarios();

}
}