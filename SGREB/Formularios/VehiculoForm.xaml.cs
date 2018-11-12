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
        private int idTipoVehiculo;
        private int forma;
        public VehiculoForm()
        {
            forma = 1;
            InitializeComponent();

        }

        public VehiculoForm(int idTipoVehiculo)
        {
            forma = 2;
            this.idTipoVehiculo = idTipoVehiculo;
            InitializeComponent();
            TipoVehiculo vehiculo = new TipoVehiculo();
            txNombreCausa.Text = vehiculo.obtener(idTipoVehiculo).tipo;
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
            if (forma == 1)
            {
                vehiculo.crear(tvVehiculo);
            }
            else if(forma == 2)
            {
                tvVehiculo.idTipoVehiculo = idTipoVehiculo;
                vehiculo.modificar(tvVehiculo);
            }
            
            this.Close();
        }
    }
}
