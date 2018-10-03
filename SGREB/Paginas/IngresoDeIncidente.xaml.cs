using SGREB.Controlador;
using SGREB.Formularios;
using SGREB.miscellany;
using SGREB.Models;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Linq;

namespace SGREB
{
    /// <summary>
    /// Lógica de interacción para IngresoDeIncidente.xaml
    /// </summary>
    public partial class IngresoDeIncidente : UserControl
    {
        private int idTipoIncidente;
        private List<TipoIncidente> tiposDeIncidentes;
        private int[] comunes = new int[] { 2, 3, 4, 7, 9,14,15,19,21,22,23,28,30,31,32,33,34 };
        private int[] incendios = new int[] { 16, 17, 18, 25, 26, 27, 28 };
        private List<TV_MedioSolicitud> medios;
        private List<BomberoComboBox> radiotelefonistas;
        private List<TV_TipoServicio> tipoServiciosVarios;
        private List<UniidadIncidenteForm> uniidadIncidenteForms;
        private List<BomberoComboBox> bomberos;
        private IEnumerable<String> direccionItems;
        public IngresoDeIncidente()
        {
            InitializeComponent();
            obtenerMedios();
            radiotelefonistas = new List<BomberoComboBox>();
            tipoServiciosVarios = new List<TV_TipoServicio>();
            uniidadIncidenteForms = new List<UniidadIncidenteForm>();

            bomberos = new List<BomberoComboBox>();
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

        private void guardarIncidenteComun(int idIncidente)
        {
            guardarBOmberos(idIncidente);
            guardarPaciente(idIncidente);
            guardarUnidades(idIncidente);
                
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
            try { 
            idTipoIncidente = int.Parse(txTipoIncidente.Text);
            }
            catch
            {
                MessageBox.Show("Solo se aceptan numeros", "error");
                return;
            }
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
            obtenerTiposDeServicioVarios();
            gridServiciosVarios.Visibility = Visibility.Visible;
            btGuardarVarios.Visibility = Visibility.Visible;


            this.Height = 800;

        }

        private void obtenerTiposDeServicioVarios()
        {
            TipoServicio tipoServicio = new TipoServicio();
            combBoxClaseServicio.Items.Clear();
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
        /// guarda la solcituda 
        /// </summary>
        /// <param name="cmb"> true: se envio a los bomberos municipales, 
        ///                    false: no se envio </param>
        /// <returns>id de la solicitud creada</returns>
        private int guardarSolicitud(Boolean cmb, Boolean falsaAlarma)
        {
            try
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
            catch
            {
                return -1;
            }
        }



        private void btGuardarCompleto_Click(object sender, RoutedEventArgs e)
        {
            var id = guardarIncidente(false, false);

            if(Array.IndexOf(comunes, idTipoIncidente) != -1)
            {
                guardarIncidenteComun(id);
            }
            else if(Array.IndexOf(incendios, idTipoIncidente) != -1){
                guardarIncendio(id);
            }

        }

        private void guardarIncendio(int id)
        {
            throw new NotImplementedException();
        }

        private void guardarBOmberos(int idIncidente)
        {
            foreach( var item in gridBomberos.Items )
            {
                var bombero = (BomberoComboBox)item;
                Incidente incidente = new Incidente();
                incidente.agregarBombero(bombero, idIncidente);
            }

        }

        private void guardarUnidades(int idIncidente)
        {
            foreach(var u in uniidadIncidenteForms)
            {
                TC_UnidadParaIncidente unidad = new TC_UnidadParaIncidente();
                unidad.IdUnidad = u.idUnidad;
                unidad.Incidente = idIncidente;
                unidad.piloto = u.idBombero;
                UnidadParaInicidente unidadParaInicidente = new UnidadParaInicidente();
                unidadParaInicidente.crear(unidad);
            }

        }


        private int guardarPaciente(int idIncidente)
        {
            Paciente paciente = new Paciente();
            foreach (var item in PacienteGrid.Items)
            {
                var seleccionado = (PacienteGrid) item;
               var id=  paciente.agregar(seleccionado, idIncidente);
                if(id == -1)
                {
                    return -1;
                }

            }
            return 0;
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
            try {
                int idSolicitud = guardarSolicitud(cbm, falsaAlarma);
                if (idSolicitud == -1)
                {
                    return -1;
                }

                int tipoIncidente = int.Parse(txTipoIncidente.Text);


                TC_Incidente tcIncidente = new TC_Incidente();

                tcIncidente.Fecha = fechaSolicitud.SelectedDate;
                tcIncidente.tipoIncidente = tipoIncidente;
                tcIncidente.HoraEntrada = TimeSpan.Parse(Convert.ToDateTime(tPhoraEntrada.Text).ToString("HH:mm"));
                tcIncidente.horaSalida = TimeSpan.Parse(Convert.ToDateTime(tPhoraSalida.Text).ToString("HH:mm"));

                Lugar lugar = new Lugar();
                var idLugar = lugar.crear(new TT_Lugar { direccion = txLugar.Text });
                tcIncidente.lugar = idLugar;
                tcIncidente.solicitud = idSolicitud;

                Incidente incidente = new Incidente();
                return incidente.crear(tcIncidente);
            }
            catch
            { 

              return -1;
            }
        }

        private void rBFalsaArlarma_Checked(object sender, RoutedEventArgs e)
        {
            btGuardarVarios.Visibility = Visibility.Collapsed;
            btGuardarFalsaAlarma.Visibility = Visibility.Visible;
            combBoxClaseServicio.IsEnabled = false;
        }

        private void combBoxClaseServicio_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try { 
            var seleccion = combBoxClaseServicio.SelectedItem.ToString();
            if(seleccion == "Agregar Tipo Servicio")
            {
                TipoServicioVariosForm form = new TipoServicioVariosForm();
                form.ShowDialog();
                obtenerTiposDeServicioVarios();
            }
            }
            catch
            {

            }
        }

        /// <summary>
        /// agregar unidades que cubren los incidentes 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btAgregarUnidad_Click(object sender, RoutedEventArgs e)
        {
            UnidadPilotoForm unidadPiloto = new UnidadPilotoForm();
            unidadPiloto.Show();
            var r = unidadPiloto.unidadPiloto;
            uniidadIncidenteForms.Add(r);
            actualizarGridDeUnidad();
        }

        private void actualizarGridDeUnidad()
        {
            dgUnidades.Items.Clear();
            foreach( var u in uniidadIncidenteForms)
            {
                TipoUnidad tipoUnidad = new TipoUnidad();
                Unidad unidad = new Unidad();
                var t = unidad.obtener(u.idUnidad);
                var tvTipoUnidad= tipoUnidad.obtener(t.tipo);
                UnidadDataGrid unidadDataGrid = new UnidadDataGrid { placa = u.idUnidad, tipo = tvTipoUnidad.nombreTipo };
                dgUnidades.Items.Add(unidadDataGrid);
            }
            
        }

        private void btAgregarElementos_Click(object sender, RoutedEventArgs e)
        {
            var seleccion = cmbBomberos.SelectedItem.ToString();
            foreach(var b in bomberos)
            {
                if(b.nombre == seleccion)
                {
                    gridBomberos.Items.Add(b);
                }
            }
        }


        /// <summary>
        /// Guardar Servicios Varios
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btGuardarVarios_Click(object sender, RoutedEventArgs e)
        {
            var id = guardarIncidente(false, false);
            var seleccion = combBoxClaseServicio.SelectedItem.ToString();
            int idTipo = 0;
            foreach (var tipoServicioVarios in tipoServiciosVarios)
            {
                if(seleccion == tipoServicioVarios.nombre)
                {
                    idTipo = tipoServicioVarios.idTipoServicio;
                } 
            }
            if(idTipo == 0)
            {
                return;
            }
            TC_servicioVarios tC_ServicioVarios = new TC_servicioVarios { tipoServicio = idTipo, idIncidente = id };
            ServiciosVarios servicios = new ServiciosVarios();
            servicios.Crear(tC_ServicioVarios);
 
        }

        private void 


        private void btGuardarCBM_Click_2(object sender, RoutedEventArgs e)
        {
            var resultado = guardarIncidente(true, false);

        if (resultado != -1)
            {
                MessageBox.Show("Incidente Guardado");
            }
            else
            {
                MessageBox.Show("Error al guardar", "error");
            }

        }

        private void btAgregarPacienteIncendio_Click(object sender, RoutedEventArgs e)
        {
            PacienteForm pacienteForm = new PacienteForm();
            pacienteForm.ShowDialog();
            var paciente = pacienteForm.pacienteGrid;
            PacienteGrid.Items.Add(paciente);
        }
    }
}
