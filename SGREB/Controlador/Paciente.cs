
using SGREB.miscellany;
using SGREB.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace SGREB.Controlador
{

    /// <summary>
    /// Clase para controlar las actiividades en la tabla TC_paciente
    /// </summary>
    public class Paciente  {

        /// <summary>
        /// constructor para crear objetos de funcionalidad
        /// </summary>
        public Paciente() { }

        /// <summary>
        /// crear un TC_Paciente en la base de datos 
        /// </summary>
        /// <param name="paciente"></param>
        /// <returns> id del TC_Paciente creado</returns>
        public int crear(TC_Paciente paciente)
        {
            var bitacora = new bitacoraBomberoaContext();
            bitacora.TC_Paciente.Add(paciente);
            bitacora.SaveChanges();
            guardarId(paciente.idPaciente + 1);
            return paciente.idPaciente;
        }

        /// <summary>
        /// modificar TC_Paciente de la base de datos
        /// </summary>
        /// <param name="paciente">tc paciente a modificar</param>
        public void Modificar(TC_Paciente paciente)
        {
            using(var bitacora = new bitacoraBomberoaContext())
            {
                var tcPacienteM = bitacora.TC_Paciente.Find(paciente.idPaciente);
                tcPacienteM.edad = paciente.edad;
                tcPacienteM.Sexo = paciente.Sexo;
                tcPacienteM.fallecido = paciente.fallecido;
                tcPacienteM.Persoan = paciente.Persoan;
                tcPacienteM.herido = paciente.herido;
            }
        }

        public List<TC_Paciente> obtenerTodos()
        {
            var bitacora = new bitacoraBomberoaContext();
            var tcPacientes = bitacora.TC_Paciente;
            return tcPacientes.ToList();
        }

        public TC_Paciente obtener(int id)
        {
            var bitacora = new bitacoraBomberoaContext();
            var tcPaciente = bitacora.TC_Paciente.Where(s => s.idPaciente == id).Single();
            return tcPaciente;
        }

        public int agregar(PacienteGrid paciente, int idIncidente)
        {
            TC_Persona tcPersona = new TC_Persona { nombres = paciente.nombre, apellidos = paciente.apellido, dpi = paciente.dpi };
            Persona persona = new Persona();
            Incidente incidente = new Incidente();
            var id= persona.Crear(tcPersona);
            int idPaciente = obtenerId();
            TC_Paciente tcPaciente = new TC_Paciente { edad = int.Parse(paciente.edad), Persoan = id,herido = obtenerBooleano( paciente.herido),fallecido = obtenerBooleano(paciente.fallecido), Sexo  = paciente.sexo, domicilio =paciente.domicilio, idPaciente = idPaciente };
            crear(tcPaciente);
            var resultado = incidente.agregarPaciente(idPaciente, idIncidente);
            idPaciente++;
            guardarId(idPaciente);
            if (resultado != -1)
            {
                return 0;
            }

            return -1;
        }

        private bool obtenerBooleano(string cadena)
        {
            if(cadena == "x")
            {
                return true;
            }
            return false; 
        }

        public int agregarMordioPorAnimal(PacienteGrid paciente, int idIncidente, int idAnimal)
        {
            TC_Persona tcPersona = new TC_Persona { nombres = paciente.nombre, apellidos = paciente.apellido, dpi = paciente.dpi };
            Persona persona = new Persona();
            Incidente incidente = new Incidente();
            var id = persona.Crear(tcPersona);

            Animal animal = new Animal();

            int idPaciente = obtenerId();
            TC_Paciente tcPaciente = new TC_Paciente { edad = int.Parse(paciente.edad), Persoan = id, herido = obtenerBooleano(paciente.herido), fallecido =obtenerBooleano(paciente.fallecido), Sexo = paciente.sexo, idPaciente = idPaciente, domicilio = paciente.domicilio };
            crear(tcPaciente);
            agregarMordido(idPaciente, idAnimal);
            var resultado = incidente.agregarPaciente(idPaciente, idIncidente);
            idPaciente++;
            guardarId(idPaciente);

            if (resultado != -1)
            {
                return 0;
            }

            return -1;
        }

        private void agregarMordido(int idPaciente, int idAnimal)
        {
            try
            {
                using (var bitacora = new bitacoraBomberoaContext())
                {
                    var tcPaciente = bitacora.TC_Paciente.FirstOrDefault(x => x.idPaciente == idPaciente);
                    var tvAnimal = bitacora.TV_Animal.FirstOrDefault(x => x.idAnimal == idAnimal);

                    tcPaciente.TV_Animal.Add(tvAnimal);
                    bitacora.SaveChanges();

                }
            }
            catch (Exception e)
            {
                Console.Write(e.ToString());
                return;
            }
        }

        public int agregarMordioPorIntoxicacion(PacienteGrid paciente, int idIncidente, int idIntoxicacion)
        {
            TC_Persona tcPersona = new TC_Persona { nombres = paciente.nombre, apellidos = paciente.apellido, dpi = paciente.dpi };
            Persona persona = new Persona();
            Incidente incidente = new Incidente();
            var id = persona.Crear(tcPersona);

            CausaIntoxicacion causa = new CausaIntoxicacion();

            int idPaciente = obtenerId();
            TC_Paciente tcPaciente = new TC_Paciente { edad = int.Parse(paciente.edad), Persoan = id, herido =obtenerBooleano(paciente.herido), fallecido =obtenerBooleano(paciente.fallecido), Sexo = paciente.sexo, idPaciente = idPaciente, domicilio = paciente.domicilio };
            crear(tcPaciente);
            agregarIntoxicacion(idPaciente, idIntoxicacion);
            var resultado = incidente.agregarPaciente(idPaciente, idIncidente);
            idPaciente++;
            guardarId(idPaciente);
            if (resultado != -1)
            {
                return 0;
            }

            return -1;
        }

        private void agregarIntoxicacion(int idPaciente,int idIntoxicacion)
        {
            try
            {
                using (var bitacora = new bitacoraBomberoaContext())
                {
                    var tcPaciente = bitacora.TC_Paciente.FirstOrDefault(x => x.idPaciente == idPaciente);
                    var tvIntoxicado = bitacora.TV_CausaIntoxicacion.FirstOrDefault(x => x.idCausaIntoxicacion == idIntoxicacion);

                    tcPaciente.TV_CausaIntoxicacion.Add(tvIntoxicado);
                    bitacora.SaveChanges();

                }
            }
            catch (Exception e)
            {
                Console.Write(e.ToString());
                return;
            }

        }
        internal int agregarSuicidio(PacienteGrid paciente, int idIncidente)
        {
            TC_Persona tcPersona = new TC_Persona { nombres = paciente.nombre, apellidos = paciente.apellido, dpi = paciente.dpi };
            Persona persona = new Persona();
            Incidente incidente = new Incidente();
            var id = persona.Crear(tcPersona);
            CausaSuicidio causaSuicidio = new CausaSuicidio();
            int idPaciente = obtenerId();
            TC_Paciente tcPaciente = new TC_Paciente { edad = int.Parse(paciente.edad), Persoan = id,  Sexo = paciente.sexo, idPaciente = idPaciente, domicilio = paciente.domicilio };
            crear(tcPaciente);
            var resultado = incidente.agregarPaciente(idPaciente, idIncidente);
            idPaciente++;
            guardarId(idPaciente);
            if (resultado != -1)
            {
                return 0;
            }

            return -1;
        }

        private int obtenerId()
        {
            try
            {

            
            StreamReader arch = new StreamReader(Directory.GetCurrentDirectory()+ "/idPaciente.txt");
            string idS = arch.ReadToEnd();
            arch.Close();
            if (idS == "")
            {
                return 2;
            }
            else
            {
                return int.Parse(idS);
            }
            }
            catch
            {
                return 2;
            }
        }

        private void guardarId(int id)
        {
            File.Delete("/idPaciente.txt");
            StreamWriter arch = new StreamWriter(Directory.GetCurrentDirectory()+ "/idPaciente.txt");
            arch.WriteLine(id.ToString());
            arch.Close();
            
        }
    }
}