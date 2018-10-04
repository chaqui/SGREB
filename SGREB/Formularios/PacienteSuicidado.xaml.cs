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
    public partial class PacienteSuicidadoForm : Window
    {
        public PacienteGrid pacienteGrid;
        public PacienteSuicidadoForm()
        {
            InitializeComponent();
            pacienteGrid = new PacienteGrid();
        }

        private void btGuardar_Click(object sender, RoutedEventArgs e)
        {
            var nombreI = txNombres.Text;
            var apellidosI = txApellidos.Text;
            var dpiI = txDPI.Text;
            var sexo = cmbSexo.SelectedItem.ToString();
            var edad = txEdad.Text;
            if(nombreI == "" && apellidosI == "")
            {
                MessageBox.Show("Información importante faltante");
                return;
            }
            pacienteGrid.nombre = nombreI;
            pacienteGrid.apellido = apellidosI;
            pacienteGrid.dpi = dpiI;
            pacienteGrid.sexo = sexo;
            pacienteGrid.edad = edad;
            this.Close();
        }

        private void btCancelar_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
