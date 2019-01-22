
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
            tipos.Add(new TipoIncidente(12, "Accidente de Bicicleta"));
            tipos.Add(new TipoIncidente(13, "Fugas de Gas Propano"));
            tipos.Add(new TipoIncidente(14, "Servicios de Agua"));
            tipos.Add(new TipoIncidente(15, "Prevenciones"));
            tipos.Add(new TipoIncidente(16, "Accidentes Laborales"));
            tipos.Add(new TipoIncidente(17, "Hechos de Violencia"));
            tipos.Add(new TipoIncidente(18, "Incendios de Viviendas"));
            tipos.Add(new TipoIncidente(19, "Vehiculos Incendios"));
            tipos.Add(new TipoIncidente(20, "Incendios Forestales"));
            tipos.Add(new TipoIncidente(21, "Contatos de Incendios"));
            tipos.Add(new TipoIncidente(22, "Vapuleados"));
            tipos.Add(new TipoIncidente(23, "Suicidios"));
            tipos.Add(new TipoIncidente(24, "Linchados"));
            tipos.Add(new TipoIncidente(25, "Lapidados"));
            tipos.Add(new TipoIncidente(26, "Quemados con Juegos Pirotecnicos"));
            tipos.Add(new TipoIncidente(27, "Picado por abejas"));
            tipos.Add(new TipoIncidente(28, "Niños y Adolescentes Baleados"));
            tipos.Add(new TipoIncidente(29, "Incendios en Mercados"));
            tipos.Add(new TipoIncidente(30, "Incendios en Gasolineras"));
            tipos.Add(new TipoIncidente(31, "Incendios en Locales Comerciales"));
            tipos.Add(new TipoIncidente(32, "Personas Electrocutadas"));
            tipos.Add(new TipoIncidente(33, "Viviendas Inundadas"));
            tipos.Add(new TipoIncidente(34, "Rescate en Barrancos"));
            tipos.Add(new TipoIncidente(35, "Rescate en Posos"));
            tipos.Add(new TipoIncidente(36, "Rastreo Efectuado"));
            tipos.Add(new TipoIncidente(37, "Accidente Aereo"));
            tipos.Add(new TipoIncidente(38, "Rescates Vehiculares con Equipos Especiales"));
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