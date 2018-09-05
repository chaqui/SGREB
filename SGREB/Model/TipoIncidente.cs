
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace SGREB.Model
{
    public class TipoIncidente
    {
        public int idTipo { set; get; }

        public String nombre { set; get; }

        public TipoIncidente()
        {
        }

        public TipoIncidente(int idTipo, string nombre)
        {
            this.idTipo = idTipo;
            this.nombre = nombre;
        }

        public List<TipoIncidente> obtenerIncidentes()
        {
            List<TipoIncidente> tipos = new List<TipoIncidente>();
            tipos.Add(new TipoIncidente(1, "Incidentes Varios"));
            return tipos;
        }

        


    }
}