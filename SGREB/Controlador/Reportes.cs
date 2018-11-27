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

        internal List<DataGridAccidenteTransito> obtenerReporteAccidenteTransito(int idIncidente, DateTime fechaInicio, DateTime fechaFinal)
        {
            bitacoraBomberoaContext context = new bitacoraBomberoaContext();

            var query = from tc in context.TC_Incidente
                        where tc.tipoIncidente == idIncidente && tc.Fecha < fechaFinal && tc.Fecha > fechaInicio
                        join lug in context.TT_Lugar on tc.lugar equals lug.idLugar
                        from acc in tc.TC_AccidenteTransito 
                        join veh in context.TV_TipoVehiculo on acc.tipoVehiculo equals veh.idTipoVehiculo
                        from pac in tc.TC_Paciente
                        select new DataGridAccidenteTransito
                        {
                            fecha = tc.Fecha.ToString(),
                            hora = tc.horaSalida.ToString().Remove(8, 8),
                            lugar = lug.direccion,
                            tipoVehiculo = veh.tipo,
                            herido = pac.herido.ToString(),
                            fallecido = pac.fallecido.ToString(),
                            sexo = pac.Sexo
                        };
            return query.ToList();
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
                            domicilio = lug.direccion,
                            sexo = pac.Sexo.ToString(),
                            edad = pac.edad.ToString(),
                            fallecido = pac.fallecido.ToString(),
                            vivo = pac.herido.ToString(),
                            lugar = lug.direccion.TrimEnd(),
                            tipoVehiculo = veh.tipo
                        };

            return query.ToList();
        }

        internal List<DataGridAnimalDatos> obtenerMordidos(DateTime fechaInicio, DateTime fechaFinal)
        {
            bitacoraBomberoaContext context = new bitacoraBomberoaContext();

            var query = from tc in context.TC_Incidente
                        where tc.tipoIncidente == 8 && tc.Fecha < fechaFinal && tc.Fecha > fechaInicio
                        join lug in context.TT_Lugar on tc.lugar equals lug.idLugar
                        from pac in tc.TC_Paciente
                        from ani in pac.TV_Animal
                        select new DataGridAnimalDatos
                        {
                            fecha = tc.Fecha.ToString(),
                            hora = tc.horaSalida.ToString().Remove(8, 8),
                            lugar = lug.direccion.TrimEnd(),
                            edad = pac.edad.ToString(),
                            sexo = pac.Sexo,
                            fallecido = pac.fallecido.ToString(),
                            claseAnimal = ani.tipo

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
                            nombre = per.nombres.TrimEnd() + " " + per.apellidos.TrimEnd(),
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
                            domicilio = lug.direccion,
                            lugar = lug.direccion,
                            nombre = per.nombres + " " + per.apellidos,
                            causa = cau.CausaSuicidio,
                            edad = pac.edad.ToString(),
                            sexo = pac.Sexo
                        };

            return query.ToList();
        }

        public List<DataGridMaternidadDatos> obtenerMaternidad(int idIncidente, DateTime fechaInicio, DateTime fechaFinal)
        {
            bitacoraBomberoaContext context = new bitacoraBomberoaContext();
            List<DataGridMaternidadDatos> maternidades = new List<DataGridMaternidadDatos>();
            var query = from tc in context.TC_Incidente
                        where tc.tipoIncidente == idIncidente && tc.Fecha < fechaFinal && tc.Fecha > fechaInicio
                        join sol in context.TC_Solicitud on tc.solicitud equals sol.idSolicitud
                        join lug in context.TT_Lugar on tc.lugar equals lug.idLugar
                        join tras in context.TT_Lugar on tc.LugarTraslado equals tras.idLugar
                        from pac in tc.TC_Paciente
                        join mat in context.TC_Maternidad on tc.idIncidente equals mat.idIncidente

                        select new 
                        {
                            fecha = tc.Fecha.ToString(),
                            hora = tc.horaSalida.ToString().Remove(8, 8),
                            lugar = lug.direccion,
                            lugarTraslado = tras.institucio,
                            edad = pac.edad.ToString(),
                          
                            fallecido = pac.fallecido.ToString(),
                            parto = mat.atencionDeParto,
                            placenta = mat.RetencionDePlacenta,
                             mat.aborto                           
                        };

            var queryMaternidades = query.ToList();

            foreach (var qM in queryMaternidades)
            {
                string ab = "";
                string ap = "";
                if (bool.Parse( qM.parto.ToString()))
                {
                    ab = "x";
                }
                 else if(bool.Parse(qM.placenta.ToString()))
                {
                    ap = "Retencion de Placenta";
                }
                else
                {
                    ap = "x";
                }

                maternidades.Add(new DataGridMaternidadDatos {fecha = qM.fecha, hora = qM.hora, lugar = qM.lugar, lugarTraslado = qM.lugarTraslado, edad = qM.edad, fallecido = qM.fallecido, aborto =ab, parto = ap  });
            }

            return maternidades;
        }

        /// <summary>
        /// obtener datos para la creacion de la certificación
        /// </summary>
        /// <param name="idSolicitud"></param>
        /// <returns></returns>
        public DatosCertificacion obtenerCertificacion(int idSolicitud, int idCertificacion)
        {
            DatosCertificacion datosCertificacion = new DatosCertificacion();
            bitacoraBomberoaContext context = new bitacoraBomberoaContext();

            var queryPerInc = from sol in context.TC_Solicitud
                              where sol.idSolicitud == idSolicitud
                              join solPer in context.TC_Persona on sol.solicitante equals solPer.idPersona
                              join radio in context.TC_Bombero on sol.radioTelefonista equals radio.idBombero
                              join perRadio in context.TC_Persona on radio.persona equals perRadio.idPersona
                              join med in context.TV_MedioSolicitud on sol.medioSolicitud equals med.idSolicitud
                            
                             
                              from inc in sol.TC_Incidente
                              join tipoInc in context.TV_TipoIncidente on inc.tipoIncidente equals tipoInc.idTipo
                              join lug in context.TT_Lugar on inc.lugar equals lug.idLugar
                              join tras in context.TT_Lugar on inc.LugarTraslado equals tras.idLugar
                              join formPor in context.TC_Bombero on inc.formuladioPor equals formPor.idBombero
                              join jefeServicio in context.TC_Bombero on inc.formuladioPor equals jefeServicio.idBombero
                              join perFom in context.TC_Persona on formPor.persona equals perFom.idPersona
                              join perJefe in context.TC_Persona on jefeServicio.persona equals perJefe.idPersona
                              select new
                                    {
                                    sol.idSolicitud,
                                    solicitante = solPer.nombres.TrimEnd() + " " + solPer.apellidos.TrimEnd(),
                                    radioTelefonista = perRadio.nombres.TrimEnd() + " " + perRadio.apellidos.TrimEnd(),
                                    sol.noTelefono,
                                    med.medio,
                                    tipoIncidente = tipoInc.nombre,

                                  //datos del incidente
                                    inc.idIncidente,
                                     inc.HoraEntrada,
                                    inc.horaSalida,
                                    inc.observaciones,
                                    lugar = lug.direccion.TrimEnd(),
                                    tras = tras.institucio.TrimEnd(),
                                    fecha = inc.Fecha,
                                    redactor = perFom.nombres.TrimEnd() + " " + perFom.apellidos.TrimEnd(),
                                    vobo = perJefe.nombres.TrimEnd() + " " + perJefe.apellidos.TrimEnd()
                              };
            var obt = queryPerInc.SingleOrDefault();


            datosCertificacion.MinutosTrabajados = (obt.horaSalida - obt.HoraEntrada).ToString();
            datosCertificacion.solicitantes = obt.solicitante;
            /// TODO
            /// corregir error
            datosCertificacion.HoraEntradaDeCompañia = obt.horaSalida.ToString();
            datosCertificacion.HoraSalidaDeCompañia = obt.HoraEntrada.ToString();
            datosCertificacion.numeroTelefono = obt.noTelefono;
            datosCertificacion.radioTelefonista = obt.radioTelefonista;
            datosCertificacion.traslado = obt.tras;
            datosCertificacion.tipoServico = obt.tipoIncidente;
            datosCertificacion.direccion = obt.lugar.TrimEnd();
            datosCertificacion.fecha = DateTime.Parse( obt.fecha.ToString());
            datosCertificacion.observaciones = obt.observaciones;
            datosCertificacion.redactor = obt.redactor;
            datosCertificacion.vobo = obt.vobo;


            //obtención de pacientes
            var queryPac = from inc in context.TC_Incidente
                           where inc.idIncidente == obt.idIncidente
                           from pac in inc.TC_Paciente
                           join pacPer in context.TC_Persona on pac.Persoan equals pacPer.idPersona
                           select new
                           {
                               nombre= pacPer.nombres.TrimEnd() + " " + pacPer.apellidos.TrimEnd(),
                               pac.idPaciente,
                               pac.domicilio,
                               pac.edad
                           };


     
            var pacientes = queryPac.ToList();
            if(pacientes.Count > 0)
            {
                datosCertificacion.nombrePaciente = "";
                datosCertificacion.acompaniante = "";
                datosCertificacion.domicilio = "";
                datosCertificacion.edad = "";
                foreach (var paciente in pacientes)
                {
                    if (datosCertificacion.nombrePaciente.Count() > 0)
                    {
                        datosCertificacion.nombrePaciente = datosCertificacion.nombrePaciente + ",";
                    }
                    datosCertificacion.nombrePaciente = datosCertificacion.nombrePaciente + " "+ paciente.nombre.TrimEnd();

                    if (datosCertificacion.domicilio.Count() > 0)
                    {
                        datosCertificacion.domicilio = datosCertificacion.domicilio + ",";
                    }
                    datosCertificacion.domicilio = datosCertificacion.domicilio + " " + paciente.domicilio.TrimEnd();

                    if (datosCertificacion.edad.Count() > 0)
                    {
                        datosCertificacion.edad = datosCertificacion.edad + ",";
                    }
                    datosCertificacion.edad = datosCertificacion.edad + " " + paciente.edad.ToString();


                    var query = from pac in context.TC_Paciente
                                where pac.idPaciente == paciente.idPaciente
                                from acomp in pac.TC_Persona1
                                select new
                                {
                                    nombre = acomp.nombres.TrimEnd() + " " + acomp.apellidos.TrimEnd(),

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
                            datosCertificacion.acompaniante = datosCertificacion.acompaniante.TrimEnd() + " " + acompaniante.nombre.TrimEnd();
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
                                    piloto = nombrePiloto.nombres.TrimEnd() + " " + nombrePiloto.apellidos.TrimEnd(),
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
                                from bomb in inc.TC_Bombero3
                                join bombPer in context.TC_Persona on bomb.persona equals bombPer.idPersona
                                select new
                                {
                                    nombre = bombPer.nombres.TrimEnd() + " " + bombPer.apellidos.TrimEnd()
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


            var querycertificacion = from cert in context.TC_Certificacion
                                     where cert.idCertificacion == idCertificacion
                                     select new { solicitante = cert.solicitante.TrimEnd(), profesion= cert.profesion.TrimEnd() };
            var certi = querycertificacion.SingleOrDefault();
            datosCertificacion.solicitanteCertificacion = certi.solicitante;
            datosCertificacion.oficioSolicitanteCertificacion = certi.profesion;


            return datosCertificacion;

        }

        public List<DataGridBusqueCertificacionDatos> busquedaDatosCertificacion(int idTipoIncidente, DateTime fechaInicio, DateTime fechaFinal)
        {
            bitacoraBomberoaContext context = new bitacoraBomberoaContext();
            List<DataGridBusqueCertificacionDatos> datos = new List<DataGridBusqueCertificacionDatos>();
            var query = from tc in context.TC_Incidente
                        where tc.tipoIncidente == idTipoIncidente && tc.Fecha < fechaFinal && tc.Fecha > fechaInicio
                        select new{tc.idIncidente, tc.solicitud, tc.Fecha };
               
            foreach(var q in query)
            {
                string pacientes = "";
                var querypac = from tc in context.TC_Incidente
                               where tc.idIncidente == q.idIncidente
                               from pac in tc.TC_Paciente
                               join pacPer in context.TC_Persona on pac.Persoan equals pacPer.idPersona
                               select new
                               {
                                   nombre = pacPer.nombres + " " + pacPer.apellidos
                               };
                foreach (var qp in querypac)
                {
                    if(pacientes != "")
                    {
                        pacientes = pacientes + ",";
                    }
                    pacientes = pacientes + " " + qp.nombre;
                }
                datos.Add(new DataGridBusqueCertificacionDatos { id = q.solicitud.ToString(), fecha = q.Fecha.ToString(), pacientes = pacientes });
            }

                    


            return datos;

        }

        public List<DataGridIntoxicadosDatos> obtenerIntoxicados(DateTime fechaInicial, DateTime fechaFinal)
        {
            bitacoraBomberoaContext context = new bitacoraBomberoaContext();

            var query = from tc in context.TC_Incidente
                        where tc.tipoIncidente == 6 && tc.Fecha < fechaFinal && tc.Fecha > fechaInicial
                        join lug in context.TT_Lugar on tc.lugar equals lug.idLugar
                        from pac in tc.TC_Paciente
                        from cau in pac.TV_CausaIntoxicacion

                        select new DataGridIntoxicadosDatos
                        {   
                            fecha = tc.Fecha.ToString(),
                            hora = tc.horaSalida.ToString().Remove(8, 8),
                            lugar = lug.direccion.TrimEnd(),
                            edad = pac.edad.ToString(),
                            sexo = pac.Sexo,
                            fallecido = pac.fallecido.ToString(),
                            causas = cau.nombre
                            
                        };
            return query.ToList();
            
        }

        public List<CantidadTipoIncidente> obtenerCantidadesCertificacion(DateTime fechaInicial, DateTime fechaFinal)
        {
            bitacoraBomberoaContext context = new bitacoraBomberoaContext();
            List<CantidadTipoIncidente> cantidadTipoIncidentes = new List<CantidadTipoIncidente>();
            var query = from inc in context.TC_Incidente
                        where inc.Fecha > fechaInicial && inc.Fecha < fechaFinal
                        group inc by inc.tipoIncidente into GrupoIncidente
                        select new 
                        {
                           idTipo =GrupoIncidente.Key,
                           cantidad = GrupoIncidente.Count()

                        };
            var incidentes = query.ToList();

            foreach (var incidente in incidentes)
            {
                var queryInc = from tipoInc in context.TV_TipoIncidente
                            where tipoInc.idTipo == incidente.idTipo
                            select new
                            {
                                tipoInc.nombre
                            };
                var tipo = queryInc.SingleOrDefault();
                cantidadTipoIncidentes.Add(new CantidadTipoIncidente { nombreIncidente = tipo.nombre, cantidad = incidente.cantidad });
            }
            return cantidadTipoIncidentes;
        }

        


    }
}
