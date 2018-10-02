﻿using SGREB.Controlador;
using SGREB.Formularios;
using SGREB.miscellany;
using SGREB.Models;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace SGREB
{
    /// <summary>
    /// Lógica de interacción para IngresoDeIncidente.xaml
    /// </summary>
    public partial class IngresoDeIncidente : UserControl
    {
        private int idTipoIncidente;
        private List<TipoIncidente> tiposDeIncidentes;
        private List<TV_MedioSolicitud> medios;
        private List<BomberoComboBox> radiotelefonistas;
        private List<TV_TipoServicio> tipoServiciosVarios;
        private List<TC_Unidad> tcUnidades;
        public IngresoDeIncidente()
        {
            InitializeComponent();
            obtenerMedios();
            radiotelefonistas = new List<BomberoComboBox>();
            tipoServiciosVarios = new List<TV_TipoServicio>();
            obtenerIncidentes();
            obternerRadioTelefonistas();
        }

        /// <summary>
        /// obtener todos los medios de solicitud y agregarlos al com
        /// </summary>
        public void obtenerMedios()
        {
            if (cmbMedioSolicitud.Items.Count > 0) { 
                cmbMedioSolicitud.Items.Clear();
            }
            MedioSolicitud medio = new MedioSolicitud();
            medios = medio.obtenerTodos();
            foreach(var m in medios)
            {
                cmbMedioSolicitud.Items.Add(m.medio);
            }
            cmbMedioSolicitud.Items.Add("crear un nuevo medio...");
        }

        /// <summary>
        /// obtenr id del Medio Seleccionado
        /// </summary>
        /// <param name="nombre"> nombre del medio</param>
        /// <returns>id del medio</returns>
        private int obtenerIdMedio(string nombre)
        {
            foreach(var m in medios)
            {
                if(m.medio == nombre)
                {
                    return m.idSolicitud;
                }
            }
            return -1;
        }

        /// <summary>
        /// obtner el id del radio Telefonista
        /// </summary>
        /// <param name="nombre">nombre del radio telefonista</param>
        /// <returns>id del radio telefonista</returns>
        private string obtenerIdRadioTelefonista(string nombre)
        {
            foreach( var r in radiotelefonistas)
            {
                if(r.nombre == nombre)
                {
                    return r.id;
                }
            }
            return "";
        }
        /// <summary>
        /// obtener los incidentes
        /// </summary>
        private void obtenerIncidentes()
        {
            TipoIncidente tipoIncidente = new TipoIncidente();
            tiposDeIncidentes = tipoIncidente.obtenerIncidentes();
        }

        /// <summary>
        /// obtener todos los radiotelefonistas de la base de datos 
        /// y guardarlos en el comboBox para siu futura selección
        /// </summary>
        public void obternerRadioTelefonistas()
        {
            if(cmbRadioTelefonista.Items.Count > 0)
            {
                cmbRadioTelefonista.Items.Clear();
            }
            Controlador.Rol rol = new Controlador.Rol();

            var r = rol.obtener("telefonista");
            Controlador.Bombero bombero = new Controlador.Bombero();
            var bomberos = bombero.obtenerVarios(r.idRol);
            foreach(var b in bomberos)
            {
                Persona persona = new Persona();
                var p = persona.obtener(b.persona);
                radiotelefonistas.Add( new BomberoComboBox { nombre = p.nombres + ' ' + p.apellidos, id = b.idBombero });
            }

            foreach(var rt in radiotelefonistas)
            {
                cmbRadioTelefonista.Items.Add(rt.nombre);
            }

        }

        private void obtenerUnidades()
        {
            Unidad unidad = new Unidad();
            tcUnidades = unidad.obtenerVarios();
            foreach (var u in tcUnidades)
            {
                cmbUnidades.Items.Add(u.placa);
            }
        }



        /// <summary>
        /// Evento del radio button de que es enviado a los Bomberos Municipales 
        /// 
        /// Se habilita el boton de guardar directanente
        /// </summary>
        private void RadioButton_Checked(object sender, RoutedEventArgs e)
        {
            if(rBcbm.IsChecked == true)
            {
                btGuardarCBM.Visibility = Visibility.Visible;
                gridIncidente.Visibility = Visibility.Collapsed;
            }
            else
            {
                btGuardarCBM.Visibility = Visibility.Collapsed;
                gridIncidente.Visibility = Visibility.Visible;
            }
           
        }



        /// <summary>
        /// uncion para mostrar el formulario común
        /// </summary>
        /// <param name="nombreIncidente"></param>
        private void mostrarGridComun(String nombreIncidente)
        {
            tituloIncidenteComun.Content = nombreIncidente;
            gridComun.Visibility = Visibility.Visible;
            this.Height = 2000;
        }

        /// <summary>
        /// Funcion para mostrar el formulario común de  incidentes con Fuego.
        /// </summary>
        /// <param name="nombreIncidente"></param>
        /// 
        private void mostrarIncidendios(String nombreIncidente)
        {
            tituloIncendio.Content = nombreIncidente;
            gridIncendiosDeViviendas.Visibility = Visibility.Visible;
            this.Height = 2000;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="idIncidente"></param>
        /// <returns></returns>

        private String obtenerNombre(int idIncidente)
        {
            foreach(TipoIncidente incidente in tiposDeIncidentes)
            {
                if (incidente.idTipo == idIncidente)
                {
                    return incidente.nombre;
                }
            }
            return "";
        }

        /// <summary>
        /// Seleccionar los formularios por tipo de incidente
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        private void txTipoIncidente_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (txTipoIncidente.Text == "")
            {
                return;
            }
            idTipoIncidente = int.Parse(txTipoIncidente.Text);
           
            //si retorna 0 la función de busqueda 
            if (idTipoIncidente == 0)
            {
                return;
            }
            String nombreIncidente = obtenerNombre(idTipoIncidente);
            //se ocultan todos los formularios de incidentes
            gridServiciosVarios.Visibility = Visibility.Collapsed;
            gridComun.Visibility = Visibility.Collapsed;
            gridUnidades.Visibility = Visibility.Collapsed;
            gridMaternidad.Visibility = Visibility.Collapsed;
            gridAtropellados.Visibility = Visibility.Collapsed;
            gridIntoxicados.Visibility = Visibility.Collapsed;
            gridMordidos.Visibility = Visibility.Collapsed;
            gridAccidenteTransito.Visibility = Visibility.Collapsed;
            gridServicioDeAgua.Visibility = Visibility.Collapsed;
            gridIncendiosDeViviendas.Visibility = Visibility.Collapsed;
            gridInundaciones.Visibility = Visibility.Collapsed;
            gridElementos.Visibility = Visibility.Collapsed;
            gridBaleados.Visibility = Visibility.Collapsed;

            //seleccion de formulario por id
            switch (idTipoIncidente)
            {

                case 1: //incidentes varios
                    mostrarServiciosVarios();
                    break;
                case 2: //Enfermedad Común
                    mostrarGridComun(nombreIncidente);
                    break;
                case 3: //Caidas casuales
                    mostrarGridComun(nombreIncidente);
                    break;
                case 4: //Maternidad
                    gridMaternidad.Visibility = Visibility.Visible;
                    break;
                case 5: //Atropellados
                    gridAtropellados.Visibility = Visibility.Visible;
                    break;
                case 6: //Intoxicados
                    gridIntoxicados.Visibility = Visibility.Visible;
                    break;
                case 7: //Quemados
                    mostrarGridComun(nombreIncidente);
                    break;
                case 8: //Mordidos por Animales
                    gridMordidos.Visibility = Visibility.Visible;
                    break;
                case 9: //Ataque de objeto Contundente
                    mostrarGridComun(nombreIncidente);
                    break;
                case 10: //Accidente de Transito
                    gridAccidenteTransito.Visibility = Visibility.Visible;
                    break;
                case 11: //Accidente de Motocicleta
                    mostrarGridComun(nombreIncidente);
                    break;
                case 12: //Servicio de Agua
                    gridServicioDeAgua.Visibility = Visibility.Visible;
                    break;
                case 13: //Prevenciones
                    break;
                case 14: //Accidente Laboral
                    mostrarGridComun(nombreIncidente);
                    break;
                case 15: //Hechos de Violencia
                    mostrarGridComun(nombreIncidente);
                    break;
                case 16: //Incendios de Viviendas 
                    mostrarIncidendios(nombreIncidente);
                    break;
                case 17: //Conatos de Incendios
                    mostrarIncidendios(nombreIncidente);
                    break;
                case 18: //Incendios Forestales
                    mostrarIncidendios(nombreIncidente);
                    break;
                case 19: //Vapuleados
                    mostrarGridComun(nombreIncidente);
                    break;
                case 20: //suicidados
                    gridSuicidios.Visibility = Visibility.Visible;
                    break;
                case 21: //Linchados
                    mostrarGridComun(nombreIncidente);
                    break;
                case 22: //Lapidados
                    mostrarGridComun(nombreIncidente);
                    break;
                case 23: //Picados por Abejas
                    mostrarGridComun(nombreIncidente);
                    break;
                case 24:
                    gridBaleados.Visibility = Visibility.Visible;
                    break;
                case 25: //Incendios de Mercados
                    mostrarIncidendios(nombreIncidente);
                    break;
                case 26: //Incendios en Gasolineras
                    mostrarIncidendios(nombreIncidente);
                    break;
                case 27: //Incendios en Locales Comerciales
                    mostrarIncidendios(nombreIncidente);
                    break;
                case 28: //persona electrocutada
                    mostrarGridComun(nombreIncidente);
                    break;
                case 29: //inundaciones
                    gridInundaciones.Visibility = Visibility.Visible;
                    break;
                case 30: //Rescate en Posos
                    mostrarGridComun(nombreIncidente);
                    break;
                case 31: //Rescate en Posos
                    mostrarGridComun(nombreIncidente);
                    break;
                case 32: //Rastreo Efectuado
                    mostrarGridComun(nombreIncidente);
                    break;
                case 33: //Accidente aereo
                    mostrarGridComun(nombreIncidente);
                    break;
                case 34: //Rescate con equipo especial
                    mostrarGridComun(nombreIncidente);
                    break;


            }
            gridUnidades.Visibility = Visibility.Visible;
            gridElementos.Visibility = Visibility.Visible;

        }



        private void mostrarServiciosVarios()
        {
            gridServiciosVarios.Visibility = Visibility.Visible;
            this.Height = 800;
        }

        private void obtenerTiposDeServicioVarios()
        {
            TipoServicio tipoServicio = new TipoServicio();
            tipoServiciosVarios = tipoServicio.obtenerTodos();
            foreach(var tipoServicioVarios in tipoServiciosVarios)
            {
                combBoxClaseServicio.Items.Add(tipoServicioVarios.nombre);
            }
            combBoxClaseServicio.Items.Add("Agregar Tipo Servicio");
        }

        /// <summary>
        /// evento para abrir el formulario para crear un Medio
        /// </summary>  
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmbMedioSolicitud_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string nombre = cmbMedioSolicitud.SelectedItem.ToString();
            if (nombre == "crear un nuevo medio...")
            {
                MedioForm unidadForm = new MedioForm();
                unidadForm.ShowDialog();
                obtenerMedios();
            }
        }

        /// <summary>
        /// guardar un incidente enviado a los bomberos municipales
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btGuardarCBM_Click(object sender, RoutedEventArgs e)
        {
            var resultado = guardarIncidente(true, false);
            if (resultado != -1) {
                MessageBox.Show("Incidente Guardado");
            }
            else
            {
                MessageBox.Show("Error al guardar", "error");
            }
            
        }

        /// <summary>
        /// guarda la solcituda 
        /// </summary>
        /// <param name="cmb"> true: se envio a los bomberos municipales, 
        ///                    false: no se envio </param>
        /// <returns>id de la solicitud creada</returns>
        private int guardarSolicitud(Boolean cmb, Boolean falsaAlarma)
        {
            var idRadioTelefonista = obtenerIdRadioTelefonista(cmbRadioTelefonista.SelectedItem.ToString());
            var idMedio = obtenerIdMedio(cmbMedioSolicitud.SelectedItem.ToString());
            var nombre = txNombresSolicitante.Text;
            var apellidos = txApellidosSolicitante.Text;
            var dpi = txDPISolicitante.Text;
            if (nombre == "" && apellidos =="")
            {
                MessageBox.Show("no ingreso el solicitante", "error de ingreso");
                return -1;
            }
            if (idRadioTelefonista == "")
            {
                MessageBox.Show("no selecciono al radioTelefonista", "error de ingreso");
                return -1;
            }
            if (idMedio == -1)
            {
                MessageBox.Show("no selecciono el Medio de Solicitud", "error de ingreso");
                return -1;
            }
            if(dpi != "")
            {
                if(dpi.Length != 13)
                {
                    MessageBox.Show("no ingreso un dpi correcto", "error de ingreso");
                    return -1;
                }
            }
            TC_Persona tcPersona = new TC_Persona();
            Persona persona = new Persona();
            tcPersona.nombres = nombre;
            tcPersona.apellidos = apellidos;
            tcPersona.dpi = dpi;
            int idPersona = persona.Crear(tcPersona);

            TC_Solicitud tcSolicitud = new TC_Solicitud { medioSolicitud = idMedio, solicitante = idPersona, radioTelefonista = idRadioTelefonista, TraspasoACBM = cmb, ingresadoPor = "rene", falsaAlarma= falsaAlarma };
            Solicitud solicitud = new Solicitud();
            return solicitud.crear(tcSolicitud);
        }



        private void btGuardarCompleto_Click(object sender, RoutedEventArgs e)
        {
            var id = guardarSolicitud(false, false);

        }

        private void guardarBOmberos(int idIncidente)
        {

        }

        private void guardarUnidades(int idIncidente)
        {

        }

        private void guardarPaciente(int idIncidente)
        {

        }
        /// <summary>
        /// Agregar Paciente al incidente
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btAgregarPaciente_Click(object sender, RoutedEventArgs e)
        {
            PacienteForm pacienteForm = new PacienteForm();
            pacienteForm.ShowDialog();
            var paciente = pacienteForm.pacienteGrid;
            PacienteGrid.Items.Add(paciente);
        }

        private void EliminarPaciente_Click(object sender, RoutedEventArgs e)
        {
            PacienteGrid.Items.Remove(PacienteGrid.SelectedItem);
        }

        private void btGuardarFalsaAlarma_Click(object sender, RoutedEventArgs e)
        {
            var resultado = guardarIncidente(false, true);
            if (resultado != -1)
            {
                MessageBox.Show("Incidente Guardado");
            }
            else
            {
                MessageBox.Show("error al guardar", "error");
            }
        }
        public int guardarIncidente(Boolean cbm, Boolean falsaAlarma)
        {
            int idSolicitud = guardarSolicitud(cbm, falsaAlarma);
            if (idSolicitud == -1)
            {
                return -1;
            }
            TC_Incidente tcIncidente = new TC_Incidente();
            tcIncidente.Fecha = fechaSolicitud.SelectedDate;
            Incidente incidente = new Incidente();
            return incidente.crear(tcIncidente);
        }

        private void rBFalsaArlarma_Checked(object sender, RoutedEventArgs e)
        {
            btGuardarFalsaAlarma.Visibility = Visibility.Visible;
            combBoxClaseServicio.IsEnabled = false;
        }

        private void combBoxClaseServicio_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var seleccion = combBoxClaseServicio.SelectedItem.ToString();
            if(seleccion == "Agregar Tipo Servicio")
            {
                TipoServicioVariosForm form = new TipoServicioVariosForm();
                form.Show();
                obtenerTiposDeServicioVarios();
            }
        }

        /// <summary>
        /// agregar unidades que cubren los incidentes 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btAgregarUnidad_Click(object sender, RoutedEventArgs e)
        {
            var unidadSeleccionada = cmbUnidades.SelectedItem.ToString();
            Unidad unidad = new Unidad();
            var tcUnidad = unidad.obtener(unidadSeleccionada);
            TipoUnidad tipo = new TipoUnidad();
            var tvTipoUnidad = tipo.obtener(tcUnidad.tipo);
            UnidadDataGrid unidadDataGrid = new UnidadDataGrid { placa = tcUnidad.placa, tipo = tvTipoUnidad.nombreTipo };
            dgUnidades.Items.Add(unidadDataGrid);
        }
    }
}
