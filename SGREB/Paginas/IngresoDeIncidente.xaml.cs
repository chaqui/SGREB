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

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            String nombreIncidente = cmBxTipoDeIncidente.SelectedItem.ToString();
            idTipoIncidente = obtenerIdIncidente(nombreIncidente);

            if (idTipoIncidente == 0)
            {
                return;
            }
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

            switch (idTipoIncidente)
            {
                case 1:
                    gridServiciosVarios.Visibility = Visibility.Visible;
                    this.Height = 800;
                    break;
                case 2:
                    mostrarGridComun(nombreIncidente);
                    break;
                case 3:
                    mostrarGridComun(nombreIncidente);
                    break;
                case 4:
                    gridMaternidad.Visibility = Visibility.Visible;
                    break;
                case 5:
                    gridAtropellados.Visibility = Visibility.Visible;
                    break;
                case 6:
                    gridIntoxicados.Visibility = Visibility.Visible;
                    break;
                case 7:
                    mostrarGridComun(nombreIncidente);
                    break;
                case 8:
                    gridMordidos.Visibility = Visibility.Visible;
                    break;
                case 9:
                    mostrarGridComun(nombreIncidente);
                    break;
                case 10:
                    gridAccidenteTransito.Visibility = Visibility.Visible;
                    break;
                case 11:
                    mostrarGridComun(nombreIncidente);
                    break;
                case 12:
                    gridServicioDeAgua.Visibility = Visibility.Visible;
                    break;
                case 13: 
                    break;
                case 14:
                    mostrarGridComun(nombreIncidente);
                    break;
                case 15:
                    mostrarGridComun(nombreIncidente);
                    break;
                case 16:
                    mostrarIncidendios(nombreIncidente);
                    break;
                case 17:
                    mostrarIncidendios(nombreIncidente);
                    break;
                case 18:
                    mostrarIncidendios(nombreIncidente);
                    break;
                case 19:
                    mostrarGridComun(nombreIncidente);
                    break;
                case 21:
                    mostrarGridComun(nombreIncidente);
                    break;
                case 22:
                    mostrarGridComun(nombreIncidente);
                    break;
                case 23:
                    mostrarGridComun(nombreIncidente);
                    break;
                case 31:
                    mostrarGridComun(nombreIncidente);
                    break;
                case 32:
                    mostrarGridComun(nombreIncidente);
                    break;
                case 33:
                    mostrarGridComun(nombreIncidente);
                    break;
         
            

            }
            gridUnidades.Visibility = Visibility.Visible;

        }

        private void LlenarIncidentes()
        {
            TipoIncidente tipoIncidente = new TipoIncidente();
            tiposDeIncidentes = tipoIncidente.obtenerIncidentes();
            foreach (TipoIncidente incidente in tiposDeIncidentes)
                {
                cmBxTipoDeIncidente.Items.Add(incidente.nombre);
            }
        }
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
        private void mostrarGridComun(String nombreIncidente)
        {
            tituloIncidenteComun.Content = nombreIncidente;
            gridComun.Visibility = Visibility.Visible;
            this.Height = 1200;
        }

        private void mostrarIncidendios(String nombreIncidente)
        {
            tituloIncendio.Content = nombreIncidente;
            gridIncendiosDeViviendas.Visibility = Visibility.Visible;
            this.Height = 1200;
        }

    }
}
