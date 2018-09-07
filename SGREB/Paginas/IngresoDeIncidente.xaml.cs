using SGREB.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SGREB
{
    /// <summary>
    /// Lógica de interacción para IngresoDeIncidente.xaml
    /// </summary>
    public partial class IngresoDeIncidente : UserControl
    {
        private int idTipoIncidente;
        private List<TipoIncidente> tiposDeIncidentes;
        public IngresoDeIncidente()
        {
            InitializeComponent();
            LlenarIncidentes();
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
        /// muestra y oculta los formularios, por medio del id, buscado por medio del 
        /// nombre del incidente seleccionado en el comboBox.
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //se obtiene el nombre de incidente
            String nombreIncidente = cmBxTipoDeIncidente.SelectedItem.ToString();


            idTipoIncidente = obtenerIdIncidente(nombreIncidente);

            //si retorna 0 la función de busqueda 
            if (idTipoIncidente == 0)
            {
                return;
            }

            //se ocultan todos los formularios de incidentes
            gridServiciosVarios.Visibility = Visibility.Collapsed;
            gridComun.Visibility = Visibility.Collapsed;
            gridUnidades.Visibility= Visibility.Collapsed;
            gridMaternidad.Visibility = Visibility.Collapsed;
            gridAtropellados.Visibility = Visibility.Collapsed;
            gridIntoxicados.Visibility = Visibility.Collapsed;
            gridMordidos.Visibility = Visibility.Collapsed;
            gridAccidenteTransito.Visibility = Visibility.Collapsed;
            gridServicioDeAgua.Visibility = Visibility.Collapsed;
            gridIncendiosDeViviendas.Visibility = Visibility.Collapsed;
            gridElementos.Visibility = Visibility.Collapsed;

            //seleccion de formulario por id
            switch (idTipoIncidente)
            {
                
                case 1: //incidentes varios
                    gridServiciosVarios.Visibility = Visibility.Visible;
                    this.Height = 800;
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
            gridUnidades.Visibility = Visibility.Visible;
        }

        /// <summary>
        /// Formulario para seleccionar todos los incidentes, para que 
        /// </summary>

        private void LlenarIncidentes()
        {
            TipoIncidente tipoIncidente = new TipoIncidente();
            tiposDeIncidentes = tipoIncidente.obtenerIncidentes();
            foreach (TipoIncidente incidente in tiposDeIncidentes)
                {
                cmBxTipoDeIncidente.Items.Add(incidente.nombre);
            }
        }

        /// <summary>
        /// Se busca el id del incidente basado en el nombre
        /// </summary>
        /// <param name="nombreIncidente"></param>
        /// <returns name="idTipo">tipo de incidente </returns>
        private int obtenerIdIncidente(String nombreIncidente)
        {
            foreach (TipoIncidente incidente in tiposDeIncidentes)
            {
                if (nombreIncidente.Equals(incidente.nombre))
                {
                    return incidente.idTipo;
                }
                  
            }
            return 0;
        }

        /// <summary>
        /// uncion para mostrar el formulario común
        /// </summary>
        /// <param name="nombreIncidente"></param>
        private void mostrarGridComun(String nombreIncidente)
        {
            tituloIncidenteComun.Content = nombreIncidente;
            gridComun.Visibility = Visibility.Visible;
            this.Height = 1400;
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
            this.Height = 1400;
        }

    }
}
