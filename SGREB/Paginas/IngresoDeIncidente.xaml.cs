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
    /// 
    public partial class IngresoDeIncidente : UserControl
    {
        private int idTipoIncidente;
        private List<TipoIncidente> tiposDeIncidentes;
        private int[] comunes = new int[] {3, 7, 9, 11, 12, 16, 17, 22, 24, 25, 26, 27, 28, 32, 34, 35, 36, 37, 38}; //19
        private int[] incendios = new int[] { 13, 18, 20, 21, 29, 30, 31 };
        private List<TV_MedioSolicitud> medios;
        private List<BomberoComboBox> radiotelefonistas;
        private List<TV_TipoServicio> tipoServiciosVarios;
        private List<UniidadIncidenteForm> uniidadIncidenteForms;
        private List<BomberoComboBox> bomberos;
        private List<BomberoComboBox> bomberosRev;
        private List<TV_CausaSuicidio> causasSuicidio;
        private List<TV_Animal> animales;
        private List<TV_CausaIntoxicacion> causas;
        private List<TV_TipoVehiculo> vehiculos;
        private List<TV_CausaEnfermedadComun> causasEnfermedadComun;
        private List<TT_Lugar> LugaresDeTraslado;
        private string observaciones;
        public IngresoDeIncidente()
        {
            InitializeComponent();
            obtenerMedios();
            radiotelefonistas = new List<BomberoComboBox>();
            tipoServiciosVarios = new List<TV_TipoServicio>();
            uniidadIncidenteForms = new List<UniidadIncidenteForm>();
            causasEnfermedadComun = new List<TV_CausaEnfermedadComun>();
            bomberos = new List<BomberoComboBox>();
            bomberosRev = new List<BomberoComboBox>();

            causasSuicidio = new List<TV_CausaSuicidio>();

            causas = new List<TV_CausaIntoxicacion>();
            obtenerIncidentes();
            obternerRadioTelefonistas();
            obtenerElementosRev();
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

        private string obtenerIdBomberoRev(string nombre)
        {
            foreach (var b in bomberosRev)
            {
                if (b.nombre == nombre)
                {
                    return b.id;
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
            obtenerLugaresDeTraslado();
                     obtenerLugaresComunes();
            tituloIncidenteComun.Content = nombreIncidente;
            gridComun.Visibility = Visibility.Visible;
            this.Height = 2000;
        }

        private void guardarIncidenteComun(int idIncidente)
        {
            try
            { 
            guardarBOmberos(idIncidente);
            guardarPaciente(idIncidente);
            guardarUnidades(idIncidente);
                MessageBox.Show("Guardado Correctamente");
            }
            catch
            {
                MessageBox.Show("Error al guardar");
            }


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
            gridSuicidios.Visibility = Visibility.Collapsed;
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
            gridEComun.Visibility = Visibility.Collapsed;
            gridIncendioVehiculo.Visibility = Visibility.Collapsed;
            btGuardarVarios.Visibility = Visibility.Collapsed;

            //seleccion de formulario por id
            switch (idTipoIncidente)
            {

                case 1: //incidentes varios
                    mostrarServiciosVarios();
                    break;
                case 2: //Enfermedad Común
                    mostrarEnfermedadComun();
                    break;
                case 3: //Caidas casuales
                    mostrarGridComun(nombreIncidente);
                    break;
                case 4: //Maternidad
                    obtenerLugaresDeTraslado();
                    obtenerLugarresMaternidad();
                    gridMaternidad.Visibility = Visibility.Visible;
                    this.Height = 1750;
                    break;
                case 5: //Atropellados
                    obtenerTiposDeVehiculos();
                    obtenerLugaresDeTraslado();
                    obtenerLugaresAtropellado();
                    gridAtropellados.Visibility = Visibility.Visible;
                    this.Height = 1750;
                    break;
                case 6: //Intoxicados
                    obtenerLugaresIntoxicados();
                    obtenerCausasIntoxicacion();
                    gridIntoxicados.Visibility = Visibility.Visible;
                    this.Height = 1750;
                    break;
                case 7: //Quemados
                    mostrarGridComun(nombreIncidente);
                    break;
                case 8: //Mordidos por Animales
                    obtenerLugaresDeTraslado();
                    obtenerLugaresMordido();
                    obtenerAnimales();
                    gridMordidos.Visibility = Visibility.Visible;
                    this.Height = 1750;
                    break;
                case 9: //Ataque de objeto Contundente
                    mostrarGridComun(nombreIncidente);
                    break;
                case 10: //Accidente de Transito
                    obtenerVehiculosAccidenteDeTransito();
                    obtenerLugaresDeTraslado();
                    obtenerLugaresDeAccidente();
                    gridAccidenteTransito.Visibility = Visibility.Visible;
                    break;
                case 11: //Accidente de Motocicleta
                    mostrarGridComun(nombreIncidente);
                    break;
                case 12: //Accidente de Bicicleta
                    mostrarGridComun(nombreIncidente);
                    break;
                case 13: //Fugas de Gas Propano 
                    obtenerLugaresDeTraslado();
                    obtenerLugaresTrasladoIncendio();
                    mostrarIncidendios(nombreIncidente);
                    break;
                case 14: //Servicio de Agua
                    gridServicioDeAgua.Visibility = Visibility.Visible;
                    break;
                case 15: //Prevenciones
                    break;
                case 16: //Accidente Laboral
                    mostrarGridComun(nombreIncidente);
                    break;
                case 17: //Hechos de Violencia
                    mostrarGridComun(nombreIncidente);
                    break;
                case 18: //Incendios de Viviendas 
                    obtenerLugaresDeTraslado();
                    obtenerLugaresTrasladoIncendio();
                    mostrarIncidendios(nombreIncidente);
                    break;
                case 19: //Incendio de Vehiculos 
                    obtenerLugaresDeTraslado();
                    obtenerLugaresTrasladoIncendioVehiculo();
                    gridIncendioVehiculo.Visibility = Visibility.Visible;
                    break;
                case 20: //Incendios Forestales
                    obtenerLugaresDeTraslado();
                    obtenerLugaresTrasladoIncendio();
                    mostrarIncidendios(nombreIncidente);
                    break;
                case 21: //Conatos de Incendios
                    obtenerLugaresDeTraslado();
                    obtenerLugaresTrasladoIncendio();
                    mostrarIncidendios(nombreIncidente);
                    break;
                case 22: //Vapuleados
                    mostrarGridComun(nombreIncidente);
                    break;
                case 23: //suicidados
                    obtenerCausasSuicidio();
                    gridSuicidios.Visibility = Visibility.Visible;
                    break;
                case 24: //Linchados
                    mostrarGridComun(nombreIncidente);
                    break;
                case 25: //Lapidados
                    mostrarGridComun(nombreIncidente);
                    break;
                case 26: //Quemados Con Juegos Pirotecnicos
                    mostrarGridComun(nombreIncidente);
                    break;
                case 27: //Picados por Abejas
                    mostrarGridComun(nombreIncidente);
                    break;
                case 28:
                    mostrarGridComun(nombreIncidente);
                    break;
                case 29: //Incendios de Mercados
                    obtenerLugaresDeTraslado();
                    obtenerLugaresTrasladoIncendio();
                    mostrarIncidendios(nombreIncidente);
                    break;
                case 30: //Incendios en Gasolineras
                    obtenerLugaresDeTraslado();
                    obtenerLugaresTrasladoIncendio();
                    mostrarIncidendios(nombreIncidente);
                    break;
                case 31: //Incendios en Locales Comerciales
                    obtenerLugaresDeTraslado();
                    obtenerLugaresTrasladoIncendio();
                    mostrarIncidendios(nombreIncidente);
                    break;
                case 32: //persona electrocutada
                    mostrarGridComun(nombreIncidente);
                    break;
                case 33: //inundaciones
                    gridInundaciones.Visibility = Visibility.Visible;
                    break;
                case 34: //Rescate en Barrancos
                    mostrarGridComun(nombreIncidente);
                    break;
                case 35: //Rescate en Posos
                    mostrarGridComun(nombreIncidente);
                    break;
                case 36: //Rastreo Efectuado
                    mostrarGridComun(nombreIncidente);
                    break;
                case 37: //Accidente aereo
                    mostrarGridComun(nombreIncidente);
                    break;
                case 38: //Rescate con equipo especial
                    mostrarGridComun(nombreIncidente);
                    break;


            }
            gridUnidades.Visibility = Visibility.Visible;
            gridElementos.Visibility = Visibility.Visible;
            obtenerElementos();
        }


        /// <summary>
        /// ingresar los lugare de maternidad al combo box 
        /// </summary>
        private void obtenerLugarresMaternidad()
        {
            cmbTrasladoaAMaternidad.Items.Clear();
            try
            {
                foreach (var l in LugaresDeTraslado)
                {
                    cmbTrasladoaAMaternidad.Items.Add(l.institucio);
                }
            }
            catch
            {
               
            }
            finally
            {
                cmbTrasladoaAMaternidad.Items.Add("Agregar Nueva Institucion...");
            }
        }

        /// <summary>
        /// obtener los lugares de traslado a los pacientes y alamacenarlos en una variable
        /// s para hacerlo utilizarlo en un incendio
        /// </summary>
        private void obtenerLugaresTrasladoIncendio()
        {
            cmbTrasladoIncendio.Items.Clear();
            try
            {
                foreach (var l in LugaresDeTraslado)
                {
                    cmbTrasladoIncendio.Items.Add(l.institucio);
                }
            }
            catch
            {

            }
            finally
            {
                cmbTrasladoIncendio.Items.Add("Agregar Nueva Institucion...");
            }
        }

        /// <summary>
        /// obtener los lugares de traslado a los pacientes y alamacenarlos en una variable
        /// s para hacerlo utilizarlo en un incendio de un vehiculo
        /// </summary>
        private void obtenerLugaresTrasladoIncendioVehiculo()
        {
            cmbTrasladoIncendio.Items.Clear();
            try
            {
                foreach (var l in LugaresDeTraslado)
                {
                    cmbTrasladoVehiculoIncendiado.Items.Add(l.institucio);
                }
            }
            catch
            {

            }
            finally
            {
                cmbTrasladoVehiculoIncendiado.Items.Add("Agregar Nueva Institucion...");
            }
        }
        /// <summary>
        /// obtener los lugares de traslado a los pacientes y alamacenarlos en una variable
        /// s para hacerlo utilizarlo cuando es mordido por un animal
        /// </summary>
        private void obtenerLugaresMordido()
        {
            cmbTrasladoMordido.Items.Clear();
            try
            {
                foreach (var l in LugaresDeTraslado)
                {
                    cmbTrasladoMordido.Items.Add(l.institucio);
                }
            }
            catch
            {

            }
            finally
            {
                cmbTrasladoMordido.Items.Add("Agregar Nueva Institucion...");
            }
          
        }

        /// <summary>
        /// obtener los lugares de traslado a los pacientes y alamacenarlos en una variable
        /// s para hacerlo utilizarlo en un paciebnte intoxicado
        /// </summary>
        private void obtenerLugaresIntoxicados()
        {
            cmbTrasladoIntoxicados.Items.Clear();
            try
            {
                foreach (var l in LugaresDeTraslado)
                {
                    cmbTrasladoIntoxicados.Items.Add(l.institucio);
                }
            }
            catch

            {

            }
            
            finally
            {
                cmbTrasladoIntoxicados.Items.Add("Agregar Nueva Institucion...");
            }
            
        }
        /// <summary>
        /// obtener los lugares de traslado a los pacientes y alamacenarlos en una variable
        /// s para hacerlo utilizarlo en un atropellado
        /// </summary>
        private void obtenerLugaresAtropellado()
        {
            cmbTrasladoAtropellado.Items.Clear();
            try
            {
                foreach (var l in LugaresDeTraslado)
                {
                    cmbTrasladoAtropellado.Items.Add(l.institucio);
                }
            }
            catch
            {

            }
            finally
            {

                cmbTrasladoAtropellado.Items.Add("Agregar Nueva Institucion...");
            }
        }

        /// <summary>
        /// obtener los lugares de traslado a los pacientes y alamacenarlos en una variable
        /// </summary>
        private void obtenerLugaresDeTraslado()
        {

            Lugar lugar = new Lugar();
            LugaresDeTraslado = lugar.obtenerVariasInstituciones();
        }

        private void mostrarEnfermedadComun()
        {
            obtenerCausasComunes();
            obtenerLugaresDeTraslado();
            obtenerLugaresComunes();
            gridEComun.Visibility = Visibility.Visible;
            this.Height = 2000;
            obtenerLugaresEnfermedadComun();
        }

        private void obtenerLugaresEnfermedadComun()
        {
            try
            {

            
            cmbTrasladoEnfermedadComun.Items.Clear();
            foreach (var l in LugaresDeTraslado)
            {
                cmbTrasladoEnfermedadComun.Items.Add(l.institucio);
            }
       
            }
            catch
            {

            }
            finally
            {
                cmbTrasladoEnfermedadComun.Items.Add("Agregar Nueva Institucion...");
            }
        }

        private void obtenerLugaresComunes()
        {
            cmbTraslado.Items.Clear();
            try
            {

            
            foreach(var l in LugaresDeTraslado)
            {
                cmbTraslado.Items.Add(l.institucio);
            }
            }
            catch
            {

            }
            finally
            { 
            cmbTraslado.Items.Add("Agregar Nueva Institucion...");
            }
        }

        

        private void obtenerCausasComunes()
        {
            CausaEnfermedadComun causa = new CausaEnfermedadComun();
            causasEnfermedadComun = causa.obtenerTodos();
            cmbCausaEComun.Items.Clear();
            foreach(var c in causasEnfermedadComun)
            {
                cmbCausaEComun.Items.Add(c.nombre);
            }
            cmbCausaEComun.Items.Add("Crear una nueva causa...");

        }


        private void obtenerElementos()
        {
            if(bomberos.Count == 0)
            {
                Persona persona = new Persona();
                Controlador.Bombero bombero = new Controlador.Bombero();

                var bomberosO = bombero.obtenerVarios();
                foreach (var b in bomberosO)
                {
                    var p = persona.obtener(b.persona);
                    this.bomberos.Add(new BomberoComboBox { nombre = p.nombres + " " + p.apellidos, id = b.idBombero });

                }
                cmbBomberos.Items.Clear();
                foreach (var b in bomberos)
                {
                    cmbBomberos.Items.Add(b.nombre);
                }
            }
            
        }


        private void obtenerElementosRev()
        {
            Persona persona = new Persona();
            Controlador.Bombero bombero = new Controlador.Bombero();
            var bomberosO = bombero.obtenerVarios();
            foreach (var b in bomberosO)
            {
                var p = persona.obtener(b.persona);
                this.bomberosRev.Add(new BomberoComboBox { nombre = p.nombres.TrimEnd() + " " + p.apellidos, id = b.idBombero });

            }
            foreach (var b in bomberosRev)
            {
                cmbVoBo.Items.Add(b.nombre);
                cmbFormuladoPor.Items.Add(b.nombre);
            }
        }


        /// <summary>
        /// mostrar la lista de lista de servicios varios en el grid de Servicios Varios 
        /// </summary>
        private void mostrarServiciosVarios()
        {
            obtenerTiposDeServicioVarios();
            gridServiciosVarios.Visibility = Visibility.Visible;
            btGuardarVarios.Visibility = Visibility.Visible;


            this.Height = 2000;

        }

        /// <summary>
        /// obtener todos los servicios varios de la base de datos y almacenarlo en una lista
        /// </summary>
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
            try
            {
                var nombre = cmbMedioSolicitud.SelectedItem.ToString();
                if (nombre == "crear un nuevo medio...")
                {
                    MedioForm unidadForm = new MedioForm();
                    unidadForm.ShowDialog();
                    obtenerMedios();
                }
                else{
                    nombre = nombre.Replace(" ", "");
                    if (nombre == "telefono" || nombre == "Telefono")
                    {
                        lbTelefono.Visibility = Visibility.Visible;
                        txTelefono.Visibility = Visibility.Visible;
                    }
                }

            }
            catch
            {

            }
        }


        /// <summary>
        /// guarda la solcituda 
        /// </summary>
        /// <param name="cmb"> true: se envio a los bomberos municipales, 
        ///                    false: no se envio </param>
        ///           
        /// <returns>id de la solicitud creada</returns>
        private int guardarSolicitud(Boolean cmb, Boolean falsaAlarma)
        {
            ///<exception cref="">verificar si se almacena el elemento</exception>
            try
            { 

                var idRadioTelefonista = obtenerIdRadioTelefonista(cmbRadioTelefonista.SelectedItem.ToString());
                var idMedio = obtenerIdMedio(cmbMedioSolicitud.SelectedItem.ToString());
                var nombre = txNombresSolicitante.Text;
                var apellidos = txApellidosSolicitante.Text;
                var telefono = "";
                var medio = cmbMedioSolicitud.SelectedItem.ToString();
                medio = medio.Replace(" ", "");
                
                ///<summary>si el medio es telefono, obtener el numero de telefono</summary>
                if (medio == "telefono" || medio == "Telefono")
                {
                    try
                    {
                        int.Parse(txTelefono.Text);
                    }
                    catch
                    {
                        return -1;
                    }
                    telefono = txTelefono.Text.Replace(" ", "").Replace("\n", "").Replace("\r", "");
                }
                
                ///<summary>obtener el DPI del solicitante</summary>
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

                TC_Solicitud tcSolicitud = new TC_Solicitud { medioSolicitud = idMedio, solicitante = idPersona, radioTelefonista = idRadioTelefonista, TraspasoACBM = cmb, ingresadoPor = "rene", falsaAlarma= falsaAlarma, noTelefono= telefono };
                Solicitud solicitud = new Solicitud();
                return solicitud.crear(tcSolicitud);
            }
            catch
            {

                return -1;
            }
        }

        /// <summary>
        /// funcion para guardar la mayoria de incidentes
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btGuardarCompleto_Click(object sender, RoutedEventArgs e)
        {
            
            int id = -1;
            if (idTipoIncidente==14)
            {
                id = guardarIncidente(false, false, false);
            }
            else
            {
                id = guardarIncidente(false, false, true);
            }
            if(id == -1)
            {
                MessageBox.Show("error al guardar el incidente");
                return;
            }

            if(Array.IndexOf(comunes, idTipoIncidente) != -1)
            {
                guardarIncidenteComun(id);
            }
            else if(Array.IndexOf(incendios, idTipoIncidente) != -1){
                guardarIncendio(id);
            }
            //GuardarEnfermedadComun
            else if(idTipoIncidente == 2)
            {
                guardarEnfermedadCOmun(id);
            }
            //Guardar Maternidad
            else if(idTipoIncidente == 4)
            {
                guardarMaternidad(id);
            }
            //Guardar Atropellados
            else if(idTipoIncidente == 5)
            {
                guardarAtropellados(id);
            }
            //Guardar Intoxicados
            else if(idTipoIncidente == 6)
            {
                guardarIntoxicados(id);
            }
            //Guardar Mordidos
            else if(idTipoIncidente == 8)
            {
                guardarMordidos(id);
            }
            //Guardar Accidentess De Transito
            else if(idTipoIncidente == 10)
            {
                guardarAccidentesDeTransito(id);
            }
            //Guardar Servicios de Agua
            else if(idTipoIncidente == 14)
            {
                guardarServicioDeAgua(id);
            }
            //Guardar Vehiculos Incendiados
            else if(idTipoIncidente == 19)
            {
                guardarVehiculosIncendiados(id);
            }
            //Guardar Suicidios
            else if(idTipoIncidente == 23)
            {
                guardarSuicidios(id);
            }
            //Guardar Inundaciones
            else if(idTipoIncidente == 33)
            {
                guardarInundaciones(id);
            }
        }

        /// <summary>
        /// guardar Vehiculos incendiados
        /// Pendiente
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        private int guardarVehiculosIncendiados(int id)
        {
            try
            {
                if (id == -1) return id;
                return 0;
            }
            catch
            {
                return -1;
            }
        }


        /// <summary>
        /// funcion para guardar los accidentes de transito
        /// </summary>
        /// Pendiente
        /// <permission cref="private"></permission>
        /// <param name="id"></param>
        /// <returns></returns>
        private int guardarAccidentesDeTransito(int id)
        {
            try
            {
                if (id == -1) return id;
                guardarPacienteAccidenteTransito(id);

                string placa = txtPlaca.Text;
                string tipo = cmbTipoVehiculoAccidente.SelectedItem.ToString();
                if(tipo == "")
                {
                    MessageBox.Show("no selecciono el tipo de vehiculo");
                    return -1;
                }
                int idTipo = 0;
                foreach( var v in vehiculos)
                {
                    if(tipo == v.tipo)
                    {
                        idTipo = v.idTipoVehiculo;
                        break;
                    }
                }
                TC_AccidenteTransito accidenteTransito = new TC_AccidenteTransito { placa = placa, tipoVehiculo = idTipo, idIncidente = id };
                AccidenteTransito accidente = new AccidenteTransito();
                accidente.Crear(accidenteTransito);

                return 0;
            }
            catch
            {
                return -1;
            }
        }


        /// <summary>
        /// guardar incidentes de enfermedad común
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        private int guardarEnfermedadCOmun(int id)
        {
            try
            {
                if (id == -1) return id;

                guardarPacienteEnfermadadComun(id);
                string nombre = cmbCausaEComun.SelectedItem.ToString();
                var idCausa = obtenerIdCAusaEComun(nombre);
                Incidente incidente = new Incidente();
                incidente.agregarEnfermedadComun(idCausa, id);
                guardarBOmberos(id);
                guardarUnidades(id);
                return 0;
            }
            catch
            {
                return -1;
            }
        }


        /// <summary>
        /// obtener el id de la causa común
        /// </summary>
        /// <param name="nombre"> nombre de la causa comun</param>
        /// <returns></returns>
        private int obtenerIdCAusaEComun(string nombre)
        {
            foreach (var causa in causasEnfermedadComun)
            {
                if (causa.nombre == nombre)
                {
                    return causa.idCausa;
                }
            }
            return -1;
        }

        /// <summary>
        /// guardar inundanciones
        /// </summary>
        /// <param name="id"></param>
        private void guardarInundaciones(int id)
        {
            throw new NotImplementedException();
        }

       

        private int guardarSuicidios(int id)
        {
           try
            {
                if (id == -1) return id;

                guardarPacienteSuicidio(id);
                string nombre = cmbCausa.SelectedItem.ToString();
                var idCausa = obtenerIdCAusaSuicidio(nombre);
                Suicidio suicidio = new Suicidio();
                suicidio.crearSuiciidio(new TC_Suicidio { Causa = idCausa, incidente = id });
                guardarBOmberos(id);
                guardarUnidades(id);
                return 0;
            }
            catch
            {
                return -1;
            }
        }

        private  int obtenerIdCAusaSuicidio(string nombre)
        {
            foreach (var causa in causasSuicidio)
            {
                if(causa.CausaSuicidio == nombre)
                {
                    return causa.idCausa;
                }
            }
            return -1;
        }

        private int guardarServicioDeAgua(int id)
        {
            try
            {
                if (id == -1) return id;

                int galones = int.Parse(txtGalones.Text);
                TC_ServicioDeGalones servicio = new TC_ServicioDeGalones { Galones = galones, idIncidente= id };
                servicioDeGalones Sgalones = new servicioDeGalones();
                 int idR = Sgalones.crear(servicio);

                return idR;
            }
            catch
            {
                return -1;
            }


        }

        private int guardarMordidos(int id)
        {
          
                var seleccion = cmbAnimales.SelectedItem.ToString();
                var idAnimal = obtenerIdAnimal(seleccion);

                if (id == -1) return id;
                if (idAnimal == -1) return idAnimal;
                Paciente paciente = new Paciente();
                foreach(var item in dgPacientesMordidos.Items)
                {
                    paciente.agregarMordioPorAnimal((PacienteGrid)item, id, idAnimal);
                }
                guardarBOmberos(id);
                guardarUnidades(id);
                return 0;
          

        }

        private int obtenerIdIntoxicados(string seleccion)
        {
            foreach (var a in this.causas)
            {
                if (a.nombre == seleccion)
                {
                    return a.idCausaIntoxicacion;
                }
            }
            return -1;
        }

        private int obtenerIdAnimal(string seleccion)
        {
           foreach(var a in animales)
            {
                if(a.tipo == seleccion)
                {
                    return a.idAnimal;
                }
            }
            return -1;
        }

        private int guardarIntoxicados(int id)
        {
            try
            {
                
                var seleccion = cmbIntoxicacion.SelectedItem.ToString();
                var idIntoxicado = obtenerIdIntoxicados(seleccion);

                if (id == -1) return id;
                if (idIntoxicado == -1) return idIntoxicado;
                Paciente paciente = new Paciente();
                foreach (var item in dgIntoxicados.Items)
                {
                    paciente.agregarMordioPorIntoxicacion((PacienteGrid)item, id, idIntoxicado);
                }
                guardarBOmberos(id);
                guardarUnidades(id);
                return 0;
            }
            catch
            {
                return -1;
            }
        }

        private int guardarAtropellados(int id)
        {

            if (id == -1) return id;
            var seleccion = cmbTipoVehiculo.SelectedItem.ToString();
            var placa = txPlaca.Text;
            var tipo = obtenerIdTipoDeVehiculo(seleccion);
            TC_AccidenteTransito accidenteTransito = new TC_AccidenteTransito { placa = placa, tipoVehiculo = tipo,idIncidente= id };
            AccidenteTransito accidente = new AccidenteTransito();
            accidente.Crear(accidenteTransito);
            guardarPacientesAtropellados(id);
            guardarBOmberos(id);
            guardarUnidades(id);

            return 1;
        }

        private int guardarPacientesAtropellados(int idIncidente)
        {
            
                 Paciente paciente = new Paciente();
            foreach (var item in gdPacientesAtropellados.Items)
            {
                var seleccionado = (PacienteGrid)item;
                var id = paciente.agregar(seleccionado, idIncidente);
                if (id == -1)
                {
                    return -1;
                }

            }
            return 0;
        }

        private int obtenerIdTipoDeVehiculo(string nombre)
        {
            foreach (var v in vehiculos)
            {
                if (v.tipo == nombre)
                {
                    return v.idTipoVehiculo;
                }
            }
            return -1;
        }

        /// <summary>
        /// guardar incidente de Maternidad
        /// </summary>
        /// <param name="idIncidente"></param>
        private void guardarMaternidad(int idIncidente)
        {

            guardarBOmberos(idIncidente);
            guardarUnidades(idIncidente);
            PacienteGrid paciente = new PacienteGrid();
            Paciente pacienteA = new Paciente();
            try
            {
                int.Parse(txEdadPaciente.Text);
            }
            catch
            {
                MessageBox.Show("La edad debe de ser en numeros");
                return;
            }

            try
            {
                int.Parse(txMesesEmbarazo.Text);
            }
            catch
            {
                MessageBox.Show("Los meses deben de ser en numeros");
                return;
            }
            paciente.edad = txEdadPaciente.Text;
            paciente.nombre = TxNombrePaciente.Text;
            paciente.sexo = "F";
            paciente.domicilio = txDomicilio.Text;
            if (radioButtonFallecido.IsChecked == true)
            {
                paciente.fallecido = "x";
            }
            paciente.dpi = txDPIPaciente.Text;
            var id = pacienteA.agregar(paciente, idIncidente);
            TC_Maternidad tC_Maternidad = new TC_Maternidad
            {
                aborto = radButAborto.IsChecked,
                atencionDeParto = radButtonAtencionParto.IsChecked,
                RetencionDePlacenta = radButtonRetencion_de_Placenta.IsChecked,
                idIncidente = idIncidente,
                mesesDeEmbarazo = int.Parse(txMesesEmbarazo.Text)
            };
            Maternidad maternidad = new Maternidad();
            maternidad.crear(tC_Maternidad);
        }

        private void guardarIncendio(int idIncidente)
        {
                   
            guardarPacientesIncendio(idIncidente);
            guardarUnidades(idIncidente);
            Incendio tcIncendio = new Incendio();
            var aguaUtilizada = Convert.ToSingle(Double.Parse( txGalones.Text));
            var propietario = txtPropietario.Text;
            var perdidas = Convert.ToSingle (Double.Parse(txtPerdidas.Text));
                Persona persona = new Persona();
                var id = persona.Crear(new TC_Persona { nombres = propietario });
                tcIncendio.crear(new TC_Incendio { perdidas = perdidas, propietario = id, aguaUtilizada = aguaUtilizada, idIncidente = idIncidente });
          
        }

        private void guardarBOmberos(int idIncidente)
        {
            foreach( var item in gridBomberos.Items )
            {
                var bombero = (BomberoComboBox)item;
                Incidente incidente = new Incidente();
                incidente.agregarBombero(bombero.id, idIncidente);
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

        private int guardarPacienteAccidenteTransito(int idIncidente)
        {
            Paciente paciente = new Paciente();
            foreach (var item in dataGridPacientesAccidenteTransito.Items)
            {
                var seleccionado = (PacienteGrid)item;
                var id = paciente.agregar(seleccionado, idIncidente);
                if (id == -1)
                {
                    return -1;
                }

            }
            return 0;
        }



        private int guardarPacienteEnfermadadComun(int idIncidente)
        {
            Paciente paciente = new Paciente();
            foreach (var item in gridEnfComun.Items)
            {
                var seleccionado = (PacienteGrid)item;
                var id = paciente.agregar(seleccionado, idIncidente);
                if (id == -1)
                {
                    return -1;
                }

            }
            return 0;
        }
        private int guardarPacienteSuicidio(int idIncidente)
        {
            Paciente paciente = new Paciente();
            foreach (var item in gdPacientesSucicidados.Items)
            {
                var seleccionado = (PacienteGrid)item;
                var id = paciente.agregarSuicidio(seleccionado, idIncidente);
                if (id == -1)
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

        private void btAgregarPacienteC_Click(object sender, RoutedEventArgs e)
        {
            PacienteForm pacienteForm = new PacienteForm();
            pacienteForm.ShowDialog();
            var paciente = pacienteForm.pacienteGrid;
            gridEnfComun.Items.Add(paciente);
        }


        private void EliminarPaciente_Click(object sender, RoutedEventArgs e)
        {
            PacienteGrid.Items.Remove(PacienteGrid.SelectedItem);
        }

        private void EliminarPacienteC_Click(object sender, RoutedEventArgs e)
        {
            gridEnfComun.Items.Remove(gridEnfComun.SelectedItem);
        }

        private void btGuardarFalsaAlarma_Click(object sender, RoutedEventArgs e)
        {
            var resultado = guardarIncidente(false, true, false);
            if (resultado != -1)
            {
                MessageBox.Show("Incidente Guardado");
            }
            else
            {
                MessageBox.Show("error al guardar", "error");
            }
        }
        public int guardarIncidente(Boolean cbm, Boolean falsaAlarma, Boolean trasladoC)
        {
            
               
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
                tcIncidente.observaciones = observaciones;
                if (cmbFormuladoPor.SelectedItem.ToString().Equals(""))
                {
                    MessageBox.Show("Error no ingreso quien formulo el Reporte");
                    return -1;
                }
                if (cmbVoBo.SelectedItem.ToString().Equals(""))
                {
                    MessageBox.Show("Error no ingreso quien dio el Visto Bueno al Reporte");
                    return -1;
                }
                tcIncidente.formuladioPor = obtenerIdBomberoRev(cmbFormuladoPor.SelectedItem.ToString());
                tcIncidente.JefeDeServicio = obtenerIdBomberoRev(cmbVoBo.SelectedItem.ToString());
            
                
                Lugar lugar = new Lugar();
                var idLugar = lugar.guardar(new TT_Lugar { direccion = txLugar.Text });
                tcIncidente.lugar = idLugar;
                tcIncidente.solicitud = idSolicitud;
            if (trasladoC)
            {
                int traslado = obtenerIdLugar();
                if(traslado != -1) { }
                tcIncidente.LugarTraslado = traslado;
            }

            Incidente incidente = new Incidente();
                return incidente.crear(tcIncidente);

       
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
            unidadPiloto.ShowDialog();
            var r = unidadPiloto.unidadPiloto;
            uniidadIncidenteForms.Add(r);
            actualizarGridDeUnidad();
        }

        private void actualizarGridDeUnidad()
        {
            try
            {
                dgUnidades.Items.Clear();
                foreach (var u in uniidadIncidenteForms)
                {
                    TipoUnidad tipoUnidad = new TipoUnidad();
                    Unidad unidad = new Unidad();
                    var t = unidad.obtener(u.idUnidad);
                    var tvTipoUnidad = tipoUnidad.obtener(t.tipo);
                    UnidadDataGrid unidadDataGrid = new UnidadDataGrid { placa = u.idUnidad, tipo = tvTipoUnidad.nombreTipo };
                    dgUnidades.Items.Add(unidadDataGrid);
                }
            }
            catch
            {

            }
            
            
        }

        private void btAgregarElementos_Click(object sender, RoutedEventArgs e)
        {
            try
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
            catch
            {
                MessageBox.Show("No selecciono ningun(a) Bombero");
            }
        }


        /// <summary>
        /// Guardar Servicios Varios
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btGuardarVarios_Click(object sender, RoutedEventArgs e)
        {

            var id = guardarIncidente(false, false, false);
            var seleccion = combBoxClaseServicio.SelectedItem.ToString();
            int idTipo = -1;
            if(id == -1)
            {
                MessageBox.Show("No se guardo el incidente");
                return;
            }
            foreach (var tipoServicioVarios in tipoServiciosVarios)
            {
                if(seleccion == tipoServicioVarios.nombre)
                {
                    idTipo = tipoServicioVarios.idTipoServicio;
                } 
            }
            if(idTipo == -1)
            {
                return;
            }
            TC_servicioVarios tC_ServicioVarios = new TC_servicioVarios { tipoServicio = idTipo, idIncidente = id };
            ServiciosVarios servicios = new ServiciosVarios();
            servicios.Crear(tC_ServicioVarios);
 
        }

        private int guardarPacientesIncendio(int idIncidente)
        {
            Paciente paciente = new Paciente();
            foreach (var item in dgPacientesIncendio.Items)
            {
                var seleccionado = (PacienteGrid)item;
                var id = paciente.agregar(seleccionado, idIncidente);
                if (id == -1)
                {
                    return -1;
                }

            }
            return 0;
        }


        private void btGuardarCBM_Click_2(object sender, RoutedEventArgs e)
        {
            var resultado = guardarIncidente(true, false, false);

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
            dgPacientesIncendio.Items.Add(paciente);
        }

        private void cmbCausa_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                string nombre = cmbCausa.SelectedItem.ToString();
                if (nombre == "crear una nueva causa...")
                {
                    CausaSuicidioForm causaForm = new CausaSuicidioForm();
                    causaForm.ShowDialog();
                    obtenerCausasSuicidio();
                }
            }
            catch
            {

            }
        }

        private void obtenerCausasSuicidio()
        {
            if (cmbCausa.Items.Count > 0)
            {
                cmbCausa.Items.Clear();
            }
            CausaSuicidio causa = new CausaSuicidio();
            causasSuicidio = causa.obtenerTodos();
            foreach (var c in causasSuicidio)
            {
                cmbMedioSolicitud.Items.Add(c.CausaSuicidio);
            }
            cmbMedioSolicitud.Items.Add("crear una nueva causa...");
        }

        private void btAgregarSuicidado_Click(object sender, RoutedEventArgs e)
        {
            PacienteSuicidadoForm pacienteForm = new PacienteSuicidadoForm();
            pacienteForm.ShowDialog();
            var paciente = pacienteForm.pacienteGrid;
            gdPacientesSucicidados.Items.Add(paciente);
        }

        private void cmbAnimales_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                string nombre = cmbAnimales.SelectedItem.ToString();
                if (nombre == "ingresar un nuevo Animal...")
                {
                    AnimalForm causaForm = new AnimalForm();
                    causaForm.ShowDialog();
                    obtenerAnimales();
                }
            }
            catch
            {

            }
        }

        private void obtenerAnimales()
        {
            if (cmbAnimales.Items.Count > 0)
            {
                cmbAnimales.Items.Clear();
            }
            Animal animal = new Animal();
            animales = animal.obtenerVarios();
            foreach (var a in animales)
            {
                cmbAnimales.Items.Add(a.tipo);
            }
            cmbAnimales.Items.Add("ingresar un nuevo Animal...");
        }

        private void cmbIntoxicacion_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                string nombre = cmbIntoxicacion.SelectedItem.ToString();
                if (nombre == "crear una nueva Causa...")
                {
                    IntoxicacionForm causaForm = new IntoxicacionForm();
                    causaForm.ShowDialog();
                    obtenerCausasIntoxicacion();
                }
            }
            catch
            {

            }
        }

        private void obtenerCausasIntoxicacion()
        {
            CausaIntoxicacion causa = new CausaIntoxicacion();
            try
            {
                if (cmbIntoxicacion.Items.Count > 0)
            {
                cmbIntoxicacion.Items.Clear();
            }
            
            causas = causa.obtenerTodos();
            foreach (var a in causas)
            {
                cmbIntoxicacion.Items.Add(a.nombre);
            }
            }
            catch { }
            finally {
                cmbIntoxicacion.Items.Add("crear una nueva Causa...");
            }
        }

        private void btAgregarPacienteIntoxicados_Click(object sender, RoutedEventArgs e)
        {
            PacienteForm pacienteForm = new PacienteForm();
            pacienteForm.ShowDialog();
            var paciente = pacienteForm.pacienteGrid;
            dgIntoxicados.Items.Add(paciente);
        }

        private void btAgregarPacienteMordido_Click(object sender, RoutedEventArgs e)
        {
            PacienteForm pacienteForm = new PacienteForm();
            pacienteForm.ShowDialog();
            var paciente = pacienteForm.pacienteGrid;
            dgPacientesMordidos.Items.Add(paciente);
        }

        private void btAgregarPaciente2_Click(object sender, RoutedEventArgs e)
        {
            PacienteForm pacienteForm = new PacienteForm();
            pacienteForm.ShowDialog();
            var paciente = pacienteForm.pacienteGrid;
            gdPacientesAtropellados.Items.Add(paciente);
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            try
            {
                string nombre = cmbTipoVehiculo.SelectedItem.ToString();
                if (nombre == "crear un nuevo tipo de vehiculo....")
                {
                    VehiculoForm causaForm = new VehiculoForm();
                    causaForm.ShowDialog();
                    obtenerTiposDeVehiculos();
                }
            }
            catch
            {

            }
        }

        private void obtenerTiposDeVehiculos()
        {
            if (cmbTipoVehiculo.Items.Count > 0)
            {
                cmbTipoVehiculo.Items.Clear();
            }
            TipoVehiculo tipo = new TipoVehiculo();
            vehiculos = tipo.obtenerVarios();
            foreach (var a in vehiculos)
            {
                cmbTipoVehiculo.Items.Add(a.tipo);
            }
            cmbTipoVehiculo.Items.Add("crear un nuevo tipo de vehiculo....");
        }

        private void btEliminarElementos_Click(object sender, RoutedEventArgs e)
        {
            gridBomberos.Items.Remove(gridBomberos.SelectedItem);
        }

        private void EliminarUnidad_Click(object sender, RoutedEventArgs e)
        {
            dgUnidades.Items.Remove(dgUnidades.SelectedItem);
        }

        private void cmbCausaEComun_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            { 
                var seleccion = cmbCausaEComun.SelectedItem.ToString();
                if(seleccion == "Agregar Nueva Institucion...")
                {
                    abrirFormularioDeInstitucion();
                    obtenerLugaresDeTraslado();
                    obtenerLugaresComunes();
                }           
            }
            catch
            {

            }
        }

        private void abrirFormularioDeInstitucion()
        {
            InstitucionForm institucionForm = new InstitucionForm();
            institucionForm.ShowDialog();
          
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ObservacionesForm observacionesForm = new ObservacionesForm();
            observacionesForm.ShowDialog();
            observaciones = observacionesForm.contenidoObservaciones;
        }

        private void cmbTraslado_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                var seleccion = cmbTraslado.SelectedItem.ToString();
                if (seleccion == "Crear una nueva causa...")
                {
                    CausaEnfermedadComunForm causaEnfermedadForm = new CausaEnfermedadComunForm();
                    causaEnfermedadForm.ShowDialog();
                    obtenerCausasComunes();
                }
            }
            catch
            {

            }
        }

        private void cmbTrasladoEnfermedadComun_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                var seleccion = cmbTrasladoEnfermedadComun.SelectedItem.ToString();
                if (seleccion == "Agregar Nueva Institucion...")
                {
                    abrirFormularioDeInstitucion();
                    obtenerLugaresDeTraslado();
                    obtenerLugaresEnfermedadComun();
                }
            }
            catch
            {

            }
        }

        private void cmbTrasladoAtropellado_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                var seleccion = cmbTrasladoAtropellado.SelectedItem.ToString();
                if (seleccion == "Agregar Nueva Institucion...")
                {
                    abrirFormularioDeInstitucion();
                    obtenerLugaresDeTraslado();
                    obtenerLugaresAtropellado();
                }
            }
            catch
            {

            }
        }

        private void cmbTrasladoIntoxicados_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                var seleccion = cmbTrasladoIntoxicados.SelectedItem.ToString();
                if (seleccion == "Agregar Nueva Institucion...")
                {
                    abrirFormularioDeInstitucion();
                    obtenerLugaresDeTraslado();
                    obtenerLugaresIntoxicados();
                }
            }
            catch
            {

            }
        }

        private void cmbTrasladoMordido_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                var seleccion = cmbTrasladoMordido.SelectedItem.ToString();
                if (seleccion == "Agregar Nueva Institucion...")
                {
                    abrirFormularioDeInstitucion();
                    obtenerLugaresDeTraslado();
                    obtenerLugaresMordido();
                }
            }
            catch
            {

            }
        }

        private int obtenerIdLugar()
        {
            MessageBox.Show(idTipoIncidente.ToString());
            if (Array.IndexOf(comunes, idTipoIncidente) != -1)
            {
                return obtenerIdLugar(cmbTraslado.SelectedItem.ToString());
            }
            else if (idTipoIncidente == 2)
            {
                return obtenerIdLugar(cmbTrasladoEnfermedadComun.SelectedItem.ToString());
            }
            else if(idTipoIncidente == 4)
            {
                return obtenerIdLugar(cmbTrasladoaAMaternidad.SelectedItem.ToString());
            }
            else if (idTipoIncidente == 5)
            {
                return obtenerIdLugar(cmbTrasladoAtropellado.SelectedItem.ToString());
            }
            else if (idTipoIncidente == 6)
            {
                return obtenerIdLugar(cmbTrasladoIntoxicados.SelectedItem.ToString());
            }
            else if (idTipoIncidente == 8)
            {
                return obtenerIdLugar(cmbTrasladoMordido.SelectedItem.ToString());
            }
            else if (idTipoIncidente == 10 )
            {
                return obtenerIdLugar(cmbTrasladoAccidenteTransito.SelectedItem.ToString());
            }
            else if(Array.IndexOf(incendios, idTipoIncidente) != -1)
            {
                return obtenerIdLugar(cmbTrasladoIncendio.SelectedItem.ToString());
            }
           
            return -1;
        }

        private int obtenerIdLugar(string nombre)
        {
            foreach(var l in LugaresDeTraslado)
            {
                if(l.institucio == nombre)
                {
                    return l.idLugar;
                }
            }
            return -1;
        }

        private void cmbTrasladoaAMaternidad_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                var seleccion = cmbTrasladoaAMaternidad.SelectedItem.ToString();
                if (seleccion == "Agregar Nueva Institucion...")
                {
                    abrirFormularioDeInstitucion();
                    obtenerLugaresDeTraslado();
                    obtenerLugarresMaternidad();
                }
            }
            catch
            {

            }
        }

        private void btEliminarPacienteMordido_Click(object sender, RoutedEventArgs e)
        {
            dgPacientesMordidos.Items.Remove(dgPacientesMordidos.SelectedItem);
        }

        private void cmbTipoVehiculoAccidente_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                var seleccion = cmbTipoVehiculoAccidente.SelectedItem.ToString();
                if (seleccion == "crear un nuevo tipo de vehiculo....")
                {
                    VehiculoForm tipoDeVehiculoForm = new VehiculoForm();
                    tipoDeVehiculoForm.ShowDialog();
                    obtenerVehiculosAccidenteDeTransito();
                }
            }
            catch
            {

            }
        }

        private void obtenerVehiculosAccidenteDeTransito()
        {
            try
            {
                if (cmbTipoVehiculoAccidente.Items.Count > 0)
                {
                    cmbTipoVehiculo.Items.Clear();
                }
                TipoVehiculo tipo = new TipoVehiculo();
                vehiculos = tipo.obtenerVarios();
                foreach (var a in vehiculos)
                {
                    cmbTipoVehiculoAccidente.Items.Add(a.tipo);
                }
            }
            catch
            {

            }
            finally
            {
                cmbTipoVehiculoAccidente.Items.Add("crear un nuevo tipo de vehiculo....");
            }
           
        }

        private void btAgregarPacienteAccidenteTransito_Click(object sender, RoutedEventArgs e)
        {
            PacienteForm pacienteForm = new PacienteForm();
            pacienteForm.ShowDialog();
            var paciente = pacienteForm.pacienteGrid;
            dataGridPacientesAccidenteTransito.Items.Add(paciente);
        }

        private void btEliminarPacienteAccidenteTransito_Click(object sender, RoutedEventArgs e)
        {
            dataGridPacientesAccidenteTransito.Items.Remove(dataGridPacientesAccidenteTransito.SelectedItem);
        }

        private void cmbTrasladoAccidenteTransito_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                var seleccion = cmbTrasladoAccidenteTransito.SelectedItem.ToString();
                if (seleccion == "Agregar Nueva Institucion...")
                {
                    abrirFormularioDeInstitucion();
                    obtenerLugaresDeTraslado();
                    obtenerLugaresDeAccidente();
                }
            }
            catch
            {

            }
        }

        private void obtenerLugaresDeAccidente()
        {
            cmbTrasladoAccidenteTransito.Items.Clear();
            try
            {
                foreach (var l in LugaresDeTraslado)
                {
                    cmbTrasladoAccidenteTransito.Items.Add(l.institucio);
                }
            }
            catch
            {

            }
            finally
            {
                cmbTrasladoAccidenteTransito.Items.Add("Agregar Nueva Institucion...");
            }
        }

        private void cmbTrasladoIncendio_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                var seleccion = cmbTrasladoIncendio.SelectedItem.ToString();
                if (seleccion == "Agregar Nueva Institucion...")
                {
                    abrirFormularioDeInstitucion();
                    obtenerLugaresDeTraslado();
                    obtenerLugaresTrasladoIncendio();
                }
            }
            catch
            {

            }
        }
    }
}
