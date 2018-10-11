
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace SGREB.Controlador
{
    public class TipoIncidente
    {
        private List<TipoIncidente> tipos;
        public int idTipo { set; get; }

        public String nombre { set; get; }

        public TipoIncidente()
        {
            tipos = new List<TipoIncidente>();
            tipos.Add(new TipoIncidente(1, "Incidentes Varios"));
            tipos.Add(new TipoIncidente(2, "Enfermedad Común"));
            tipos.Add(new TipoIncidente(3, "Caidads Casuales"));
            tipos.Add(new TipoIncidente(4, "Maternindad"));
            tipos.Add(new TipoIncidente(5, "Atropellados"));
            tipos.Add(new TipoIncidente(6, "Intoxicados"));
            tipos.Add(new TipoIncidente(7, "Quemadas"));
            tipos.Add(new TipoIncidente(8, "Mordidos Por Animales"));
            tipos.Add(new TipoIncidente(9, "Ataque con objeto contundente"));
            tipos.Add(new TipoIncidente(10, "Accidente de Transito"));
            tipos.Add(new TipoIncidente(11, "Accidente de Motocicletas"));
            tipos.Add(new TipoIncidente(12, "Servicio de Agua"));
            tipos.Add(new TipoIncidente(13, "Prevenciones"));
            tipos.Add(new TipoIncidente(14, "Accidente Laboral"));
            tipos.Add(new TipoIncidente(15, "Hechos de Violencia"));
            tipos.Add(new TipoIncidente(16, "Incendios de Viviendas"));
            tipos.Add(new TipoIncidente(17, "Conatos de Incendios"));
            tipos.Add(new TipoIncidente(18, "Incendios Forestales"));
            tipos.Add(new TipoIncidente(19, "Vapuleados"));
            tipos.Add(new TipoIncidente(20, "Suicidios"));
            tipos.Add(new TipoIncidente(21, "Linchados"));
            tipos.Add(new TipoIncidente(22, "Lapidados"));
            tipos.Add(new TipoIncidente(23, "Picado por abejas"));
            tipos.Add(new TipoIncidente(24, "Niños y Adolescentes Baleados"));
            tipos.Add(new TipoIncidente(25, "Incendios en Mercados"));
            tipos.Add(new TipoIncidente(26, "Incendios en Gasolineras"));
            tipos.Add(new TipoIncidente(27, "Incendios en Locales Comerciales"));
            tipos.Add(new TipoIncidente(28, "Personas Electrocutadas"));
            tipos.Add(new TipoIncidente(29, "Viviendas Inundadas"));
            tipos.Add(new TipoIncidente(30, "Rescate en Barrancos"));
            tipos.Add(new TipoIncidente(31, "Rescate en Posos"));
            tipos.Add(new TipoIncidente(32, "Rastreo Efectuado"));
            tipos.Add(new TipoIncidente(33, "Accidente Aereo"));
            tipos.Add(new TipoIncidente(34, "Rescates Vehiculares con Equipos Especiales"));
        }

        public TipoIncidente(int idTipo, string nombre)
        {
            this.idTipo = idTipo;
            this.nombre = nombre;
        }

        public List<TipoIncidente> obtenerIncidentes()
        {
         
           
            return tipos;
        }

        public string obtenerNombre(int id)
        {
            foreach(var tipo in tipos)
            {
                if(tipo.idTipo == id)
                {
                    return tipo.nombre;
                }
            }
            return "";
        }
        


    }
}