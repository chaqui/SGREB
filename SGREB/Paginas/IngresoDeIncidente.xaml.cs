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
        private List<String> incidentes; 
        public IngresoDeIncidente()
        {
            InitializeComponent();
            incidentes.Add("Servicios Varios");

            
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

        }

        private void llenarIncidentes()
        {
            foreach (String incidente in incidentes)
                {
                cmBxTipoDeIncidente.Items.Add(incidente);
            }
        }
    }
}
