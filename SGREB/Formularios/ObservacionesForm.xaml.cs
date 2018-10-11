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
using System.Windows.Shapes;

namespace SGREB.Formularios
{
    /// <summary>
    /// Lógica de interacción para observaciones.xaml
    /// </summary>
    public partial class ObservacionesForm : Window
    {
        public string contenidoObservaciones;
        public ObservacionesForm()
        {
            InitializeComponent();
        }

        private void btAceptar_Click(object sender, RoutedEventArgs e)
        {
            contenidoObservaciones = txObservaciones.Text;
            this.Close();
        }

        private void btCancelar_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
