using SGREB.Controlador;
using SGREB.Models;
using System.Windows;

namespace SGREB.Formularios
{
    /// <summary>
    /// Lógica de interacción para TipoServicioVariosForm.xaml
    /// </summary>
    public partial class TipoServicioVariosForm : Window
    {
        public TipoServicioVariosForm()
        {
            InitializeComponent();
        }

        private void btGuardar_Click(object sender, RoutedEventArgs e)
        {
            if(txNombre.Text == "")
            {
                MessageBox.Show("No ingreso nombre", "error de ingreso");
                return;
            }

            TipoServicio tipoServicio = new TipoServicio();
            TV_TipoServicio tvTipoServiciio = new TV_TipoServicio { nombre = txNombre.Text };
            tipoServicio.crear(tvTipoServiciio);
            MessageBox.Show("tipo de servicio creado");
            this.Close();
        }

        private void btCancelar_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
