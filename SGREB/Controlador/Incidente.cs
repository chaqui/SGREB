
using SGREB.miscellany;
using SGREB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;

namespace SGREB.Controlador
{

    /// <summary>
    /// clase para controlar las acciones a la tabla incidente
    /// </summary>
    public class Incidente {
        /// <summary>
        /// constructor para fucnionalidades
        /// </summary>
        public Incidente() {
        }

        /// <summary>
        /// crear un incidente en la base de datos
        /// </summary>
        /// <returns> retorna el id del incidente creado</returns>
        public int crear(TC_Incidente tcIncidente)
        {
            var bitacora = new bitacoraBomberoaContext();
            bitacora.TC_Incidente.Add(tcIncidente);
            bitacora.SaveChanges();
            return tcIncidente.idIncidente;
        }

        /// <summary>
        /// modificar el incidente en la base de datos
        /// </summary>
        /// <param name="incidente">inicidente a modificar</param>
        public void modificar(TC_Incidente incidente)
        {

            using (var bitacora = new bitacoraBomberoaContext())
            {
                var tcIncidente = bitacora.TC_Incidente.Find(incidente.idIncidente);
                tcIncidente.tipoIncidente = incidente.tipoIncidente;
                tcIncidente.lugar = incidente.lugar;
                tcIncidente.Fecha = incidente.Fecha;
                tcIncidente.solicitud = incidente.solicitud;
                tcIncidente.horaSalida = incidente.horaSalida;
                tcIncidente.HoraEntrada = incidente.HoraEntrada;
                bitacora.SaveChanges();
            }
        }

        /// <summary>
        /// obtener incidente por su id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public TC_Incidente obtener(int id)
        {
            var bitacora = new bitacoraBomberoaContext();
            var tcIncidente = bitacora.TC_Incidente.Where(s => s.idIncidente == id).Single();
            return tcIncidente;
        }

        /// <summary>
        /// obtener todos los incidentes alamacenados
        /// </summary>
        /// <returns></returns>
        public List<TC_Incidente> obtenerTodos()
        {
            var bitacora = new bitacoraBomberoaContext();
            var tC_Incidentes = bitacora.TC_Incidente;
            return tC_Incidentes.ToList();
        }
        /// <summary>
        /// obtener todos los incidentes desde lla fecha de inicio 
        /// a la de finalización
        /// </summary>
        /// <param name="fechaI"></param>
        /// <param name="fechaF"></param>
        /// <returns></returns>
        public List<TC_Incidente> obtenerTodos(DateTime fechaI, DateTime fechaF)
        {
            var bitacora = new bitacoraBomberoaContext();
            var tcIncidentes = from s in bitacora.TC_Incidente where  (s.Fecha > fechaI && s.Fecha < fechaF) select s;
            return tcIncidentes.ToList();
        }

        /// <summary>
        /// obtener todos los incidentes por el tipo
        /// </summary>
        /// <param name="idTipo">uno de los 34 tipos</param>
        /// <returns></returns>
        public List<TC_Incidente> obtenerTodos(int idTipo)
        {
            var bitacora = new bitacoraBomberoaContext();
            var tcIncidentes = bitacora.TC_Incidente.Where(s => s.tipoIncidente == idTipo);
            return tcIncidentes.ToList();
        }

        /// <summary>
        /// funcion para agregar pacientes
        /// </summary>
        /// <param name="tcPaciente"></param>
        /// <param name="idIncidente"></param>
        /// <returns></returns>
        public int agregarPaciente(int idPaciente, int idIncidente)
        {
            try
            {
                using (var bitacora = new bitacoraBomberoaContext())
                {
                    var tcPaciente = bitacora.TC_Paciente.FirstOrDefault(x => x.idPaciente == idPaciente);
                    var tcIncidente = bitacora.TC_Incidente.FirstOrDefault(x => x.idIncidente == idIncidente);

                    tcIncidente.TC_Paciente.Add(tcPaciente);
                    bitacora.SaveChanges();

                }
            }
            catch (Exception e)
            {
                Console.Write(e.ToString());
                return -1;
            }

            return 0;
        }


        public int agregarEnfermedadComun(int idTiipoEnfermedadComun, int idIncidente)
        {
            try
            {
                using (var bitacora = new bitacoraBomberoaContext())
                {
                    var tvCausa = bitacora.TV_CausaEnfermedadComun.FirstOrDefault(x => x.idCausa == idTiipoEnfermedadComun);
                    var tcIncidente = bitacora.TC_Incidente.FirstOrDefault(x => x.idIncidente == idIncidente);

                    tcIncidente.TV_CausaEnfermedadComun.Add(tvCausa);
                    bitacora.SaveChanges();

                }
            }
            catch (Exception e)
            {
                Console.Write(e.ToString());
                return -1;
            }

            return 0;
        }

        /// <summary>
        /// agregar bomberos al incidente
        /// </summary>
        /// <param name="tcBombero"></param>
        /// <param name="idIncidente"></param>
        /// <returns></returns>
        public int agregarBombero(string idBombero, int idIncidente)
        {
            try
            {
                using (var bitacora = new bitacoraBomberoaContext())
                {
                    var tcBombero = bitacora.TC_Bombero.FirstOrDefault(x => x.idBombero == idBombero);
                    var tcIncidente = bitacora.TC_Incidente.FirstOrDefault(x => x.idIncidente == idIncidente);
                    tcIncidente.TC_Bombero.Add(tcBombero);
                    bitacora.SaveChanges();
                }

            }
            catch (Exception e)
            {
                Console.Write(e.ToString());
                return -1;
            }

            return 0;
        }



    }
}