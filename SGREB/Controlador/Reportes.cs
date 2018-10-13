using SGREB.miscellany;
using SGREB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace SGREB.Controlador
{
    class Reportes
    {

        public List<DataGridComunDatos> obtenerReproteComunes(int idIncidente, DateTime fechaInicio, DateTime fechaFinal)
        {
            bitacoraBomberoaContext context = new bitacoraBomberoaContext();

            var query = from tc in context.TC_Incidente
                        where tc.tipoIncidente == idIncidente && tc.Fecha < fechaFinal && tc.Fecha > fechaInicio
                        join sol in context.TC_Solicitud on tc.solicitud equals sol.idSolicitud
                        join lug in context.TT_Lugar on tc.lugar equals lug.idLugar
                        from pac in tc.TC_Paciente

                        select new DataGridComunDatos
                        {
                            Fecha = tc.Fecha.ToString(),
                            Hora = tc.horaSalida.ToString().Remove(8,8),
                            Lugar = lug.direccion,
                            sexo = pac.Sexo.ToString(),
                            Edad = pac.edad.ToString(),
                            Fallecido = pac.fallecido.ToString(),
                            Vivo = pac.herido.ToString()
                        };
        
            return query.ToList();
        }

        public List<DataGridEnfermedadComunDatos> obtenerReporteEnfermedadComun(int idIncidente, DateTime fechaInicio, DateTime fechaFinal)
        {
            bitacoraBomberoaContext context = new bitacoraBomberoaContext();

            var query = from tc in context.TC_Incidente
                        where tc.tipoIncidente == idIncidente && tc.Fecha < fechaFinal && tc.Fecha > fechaInicio
                        join sol in context.TC_Solicitud on tc.solicitud equals sol.idSolicitud
                        join lug in context.TT_Lugar on tc.lugar equals lug.idLugar
                        from cau in tc.TV_CausaEnfermedadComun
                        from pac in tc.TC_Paciente

                        select new DataGridEnfermedadComunDatos
                        {
                            Fecha = tc.Fecha.ToString(),
                            Hora = tc.horaSalida.ToString().Remove(8, 8),
                            Lugar = lug.direccion,
                            sexo = pac.Sexo.ToString(),
                            Edad = pac.edad.ToString(),
                            Fallecido = pac.fallecido.ToString(),
                            Vivo = pac.herido.ToString(),
                            Causa = cau.nombre
                            
                        };

            return query.ToList();
        }

        public List<DataGridIncendiosDatos> obtenerIncendios (int idIncidente, DateTime fechaInicio, DateTime fechaFinal)
        {
            bitacoraBomberoaContext context = new bitacoraBomberoaContext();
            List<DataGridIncendiosDatos> incendios = new List<DataGridIncendiosDatos>();

            var query = from tc in context.TC_Incidente
                        where tc.tipoIncidente == idIncidente && tc.Fecha < fechaFinal && tc.Fecha > fechaInicio
                        join sol in context.TC_Solicitud on tc.solicitud equals sol.idSolicitud
                        join lug in context.TT_Lugar on tc.lugar equals lug.idLugar
                        from inc in tc.TC_Incendio
                        join per in context.TC_Persona on inc.propietario equals per.idPersona
                        
                        select new DataGridIncendiosDatos
                        {
                            Fecha = tc.Fecha.ToString(),
                            Hora = tc.horaSalida.ToString().Remove(8, 8),
                            Lugar = lug.direccion,
                            propietario = per.nombres + " " + per.apellidos,
                            perdidas = inc.perdidas.ToString(),
                            aguaUtilizada = inc.aguaUtilizada.ToString(),
                            idIncidente = tc.idIncidente

                        };

            foreach(var item in query)
            {
                var  pacientes = from paciente in context.TC_Paciente
                where paciente.TC_Incidente.Any(p => p.idIncidente == item.idIncidente )
                select paciente;
                int vivos = 0;
                int fallecidos = 0;
                foreach(var pac in pacientes)
                {
                    if(bool.Parse(pac.fallecido.ToString()))
                    {
                        fallecidos++;
                    }
                    else
                    {
                        vivos++;
                    }
                }
                item.Vivos = vivos.ToString();
                item.Fallecidos = fallecidos.ToString();

                incendios.Add(item);
            }




            return incendios;
        }

        public List<DataGridAtropelladosDatos> obtenerreportesAtropellados(int idIncidente, DateTime fechaInicio, DateTime fechaFinal)
        {
            bitacoraBomberoaContext context = new bitacoraBomberoaContext();

            var query = from tc in context.TC_Incidente
                        where tc.tipoIncidente == idIncidente && tc.Fecha < fechaFinal && tc.Fecha > fechaInicio
                        join sol in context.TC_Solicitud on tc.solicitud equals sol.idSolicitud
                        join lug in context.TT_Lugar on tc.lugar equals lug.idLugar
                        from acc in tc.TC_AccidenteTransito
                        join veh in context.TV_TipoVehiculo on acc.tipoVehiculo equals veh.idTipoVehiculo
                        from pac in tc.TC_Paciente

                        select new DataGridAtropelladosDatos
                        {
                            fecha = tc.Fecha.ToString(),
                            hora = tc.horaSalida.ToString().Remove(8, 8),
                            cantidad = lug.direccion,
                            sexo = pac.Sexo.ToString(),
                            edad = pac.edad.ToString(),
                            fallecido = pac.fallecido.ToString(),
                            vivo = pac.herido.ToString(),
                            lugar = lug.direccion,
                            tipoVehiculo = veh.tipo
                        };

            return query.ToList();
        }

        public List<DataGridServiciosDeAguaDatos> obtnerServiciosDeAgua(int idIncidente, DateTime fechaInicio, DateTime fechaFinal)
        {
            bitacoraBomberoaContext context = new bitacoraBomberoaContext();

            var query = from tc in context.TC_Incidente
                        where tc.tipoIncidente == idIncidente && tc.Fecha < fechaFinal && tc.Fecha > fechaInicio
                        join sol in context.TC_Solicitud on tc.solicitud equals sol.idSolicitud
                        join lug in context.TT_Lugar on tc.lugar equals lug.idLugar
                        from ser in tc.TC_ServicioDeGalones
                        join per in context.TC_Persona on sol.solicitante equals per.idPersona
                        
                        select new DataGridServiciosDeAguaDatos
                        {
                            fecha = tc.Fecha.ToString(),
                            hora = tc.horaSalida.ToString().Remove(8, 8),
                            cantidad = lug.direccion,
                            lugar = lug.direccion,
                            nombre = per.nombres + " " + per.apellidos,
                            galones = ser.Galones.ToString()
                        };

            return query.ToList();
        }

        public List<DataGridFallecimientoDatos> obtenerSuicidios(int idIncidente, DateTime fechaInicio, DateTime fechaFinal)
        {
            bitacoraBomberoaContext context = new bitacoraBomberoaContext();

            var query = from tc in context.TC_Incidente
                        where tc.tipoIncidente == idIncidente && tc.Fecha < fechaFinal && tc.Fecha > fechaInicio
                        join sol in context.TC_Solicitud on tc.solicitud equals sol.idSolicitud
                        join lug in context.TT_Lugar on tc.lugar equals lug.idLugar
                        from sui in tc.TC_Suicidio
                        from pac in tc.TC_Paciente
                        join cau in context.TV_CausaSuicidio on sui.Causa equals cau.idCausa
                        join per in context.TC_Persona on pac.Persoan equals per.idPersona
                       
                        select new DataGridFallecimientoDatos
                        {
                            fecha = tc.Fecha.ToString(),
                            hora = tc.horaSalida.ToString().Remove(8, 8),
                            cantidad = lug.direccion,
                            lugar = lug.direccion,
                            nombre = per.nombres + " " + per.apellidos,
                            causa = cau.CausaSuicidio,
                            edad = pac.edad.ToString(),
                            sexo = pac.Sexo
                        };

            return query.ToList();
        }

        public DatosCertificacion obtenerCertificacion(int idSolicitud)
        {
            DatosCertificacion datosCertificacion = new DatosCertificacion();
            bitacoraBomberoaContext context = new bitacoraBomberoaContext();

            var queryPerInc = from sol in context.TC_Solicitud
                              where sol.idSolicitud == idSolicitud
                              join solPer in context.TC_Persona on sol.solicitante equals solPer.idPersona
                              join radio in context.TC_Bombero on sol.radioTelefonista equals radio.idBombero
                              join perRadio in context.TC_Persona on radio.persona equals perRadio.idPersona
                              join cert in context.TC_Certificacion on sol.idSolicitud equals cert.idSolicitud
                              join med in context.TV_MedioSolicitud on sol.medioSolicitud equals med.idSolicitud
                         
                              from inc in sol.TC_Incidente
                              join tipoInc in context.TV_TipoIncidente on inc.tipoIncidente equals tipoInc.idTipo
                              join lug in context.TT_Lugar on inc.lugar equals lug.idLugar
                              select new
                                    {
                                    idSolicitud = sol.idSolicitud,
                                    solicitante = obtenerNombre(solPer),
                                    radioTelefonista = obtenerNombre(solPer),
                                    noTelefono = sol.noTelefono,
                                    medio = med.medio,
                                    
                                    //datos del incidente
                                    idIncidente = inc.idIncidente,
                                    horaEntrada = inc.HoraEntrada,
                                    horasalida = inc.horaSalida,
                                    observaciones = inc.observaciones,
                                    lugar = lug.direccion,
                                    fecha = inc.Fecha
                                    };
            var obt = queryPerInc.SingleOrDefault();

            datosCertificacion.MinutosTrabajados = (obt.horasalida - obt.horasalida).ToString();
            datosCertificacion.numeroTelefono = obt.noTelefono;
            datosCertificacion.direccion = obt.lugar;
            datosCertificacion.fecha = DateTime.Parse( obt.fecha.ToString());
            datosCertificacion.observaciones = obt.observaciones;


            //obtención de pacientes
            var queryPac = from inc in context.TC_Incidente
                           where inc.idIncidente == obt.idIncidente
                           from pac in inc.TC_Paciente
                           join pacPer in context.TC_Persona on pac.Persoan equals pacPer.idPersona
                           select new
                           {
                               nombre= obtenerNombre(pacPer),
                               idPaciente = pac.idPaciente,
                               paciente = obtenerNombre(pacPer),
                               edad = pac.edad,
                               sexo = pac.Sexo,
                               fallecido = pac.fallecido
                           };


     
            var pacientes = queryPac.ToList();
            if(pacientes.Count > 0)
            {
                datosCertificacion.nombrePaciente = "";
                datosCertificacion.acompaniante = "";
                foreach (var paciente in pacientes)
                {
                    if (datosCertificacion.nombrePaciente.Count() > 0)
                    {
                        datosCertificacion.nombrePaciente = datosCertificacion.nombrePaciente + ",";
                    }
                    datosCertificacion.nombrePaciente = datosCertificacion.nombrePaciente + " "+ paciente.nombre;


                    var query = from pac in context.TC_Paciente
                                where pac.idPaciente == paciente.idPaciente
                                from acomp in pac.TC_Persona1
                                select new
                                {
                                    nombre = obtenerNombre(acomp)
                    
                                };
                    var acompaniantes = query.ToList();
                    if (acompaniantes.Count > 0)
                    {
                        foreach (var acompaniante in acompaniantes)
                        {
                            if (datosCertificacion.acompaniante.Count() > 0)
                            {
                                datosCertificacion.acompaniante = datosCertificacion.acompaniante + ",";
                            }
                            datosCertificacion.acompaniante = datosCertificacion.acompaniante + " " + acompaniante.nombre;
                        }
                    }
                    else
                    {
                        datosCertificacion.acompaniante = "-----";
                    }
                }
            }
            else
            {
                datosCertificacion.nombrePaciente = "se ignora";
            }


            //conusulta de unidades 
            var queryUnidades = from inc in context.TC_Incidente
                                where inc.idIncidente == obt.idIncidente
                                from uni in inc.TC_UnidadParaIncidente
                                join pilotoBombero in context.TC_Bombero on uni.piloto equals pilotoBombero.idBombero
                                join nombrePiloto in context.TC_Persona on pilotoBombero.persona equals nombrePiloto.idPersona
                                select new
                                {
                                    piloto = obtenerNombre(nombrePiloto),
                                    unidad = uni.IdUnidad
                                };

            var unidades = queryUnidades.ToList();
            datosCertificacion.pilotos = "";
            datosCertificacion.unidades = "";
            foreach (var unidad in unidades)
            {
                if (datosCertificacion.pilotos != "")
                {
                    datosCertificacion.pilotos = datosCertificacion.pilotos + ",";
                }

                if (datosCertificacion.unidades != "")
                {
                    datosCertificacion.unidades = datosCertificacion.unidades + ",";
                }
                datosCertificacion.pilotos = datosCertificacion.pilotos + " " + unidad.piloto;               
                datosCertificacion.unidades = datosCertificacion.unidades + " " + unidad.unidad;

            }

            //consulta De Personal
            var queryPersonal = from inc in context.TC_Incidente
                                where inc.idIncidente == obt.idIncidente
                                from bomb in inc.TC_Bombero
                                join bombPer in context.TC_Persona on bomb.persona equals bombPer.idPersona
                                select new
                                {
                                    nombre = obtenerNombre(bombPer)
                                };
            var bomberos = queryPersonal.ToList();
            datosCertificacion.personal = "";
            foreach (var bombero in bomberos)
            {
                if (datosCertificacion.personal != "")
                {
                    datosCertificacion.personal = datosCertificacion.personal + ",";
                }

                datosCertificacion.personal = datosCertificacion.personal + " " + bombero.nombre;

            }





            return datosCertificacion;

        }

        private string obtenerNombre(TC_Persona persona)
        {
            return persona.nombres + " " + persona.apellidos;
        }


    }
}
