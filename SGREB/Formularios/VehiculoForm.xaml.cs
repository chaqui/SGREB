using SGREB.Controlador;
using SGREB.Models;
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
    /// Lógica de interacción para CausaSuicidioForm.xaml
    /// </summary>
    public partial class VehiculoForm : Window
    {
        public VehiculoForm()
        {
            InitializeComponent();
        }

        private void btCancelar_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }


        private void btGuardar_Click(object sender, RoutedEventArgs e)
        {
            string nombre = txNombreCausa.Text;

            if(nombre == "")
            {
                MessageBox.Show("no ha ingresado ningun nombre");
                return;
            }
            TV_TipoVehiculo tvVehiculo = new TV_TipoVehiculo { tipo = nombre };
            TipoVehiculo vehiculo = new TipoVehiculo();
            vehiculo.crear(tvVehiculo);
        }
    }
}
