using SGREB.miscellany;
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
    /// Lógica de interacción para PacienteForm.xaml
    /// </summary>
    public partial class PacienteForm : Window
    {
        public PacienteGrid pacienteGrid;
        public PacienteForm()
        {
            InitializeComponent();
            pacienteGrid = new PacienteGrid();
        }

        private void btGuardar_Click(object sender, RoutedEventArgs e)
        {
            var nombreI = txNombres.Text;
            var apellidosI = txApellidos.Text;
            var dpiI = txDPI.Text;
            var sexo = cmbSexo.SelectionBoxItem.ToString();
            var edad = txEdad.Text;
            try
            {
                int.Parse(edad);
            }
            catch
            {
                MessageBox.Show("La edad debe de ser en numeros");
                return;
                
            }
            var fallecido = "";
            var herido = "";
            if(nombreI == "" && apellidosI == "")
            {
                MessageBox.Show("Información importante faltante");
                return;
            }

            if (rbFallecido.IsChecked == true)
            {
                fallecido = "x";
            }

            if(rbHerido.IsChecked == true)
            {
                herido = "x";
            }
            pacienteGrid.nombre = nombreI;
            pacienteGrid.apellido = apellidosI;
            pacienteGrid.dpi = dpiI;
            pacienteGrid.sexo = sexo;
            pacienteGrid.edad = edad;
            pacienteGrid.fallecido = fallecido;
            pacienteGrid.herido = herido;
            this.Close();
        }

        private void rbHerido_Checked(object sender, RoutedEventArgs e)
        {
            rbFallecido.IsEnabled = false;
            rbFallecido.IsChecked = false;
        }
    }
}
