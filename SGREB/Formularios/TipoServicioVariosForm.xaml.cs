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
        private int idTipoServicio;
        private int forma;

        public TipoServicioVariosForm()
        {
            InitializeComponent();
            forma = 1; 
        }

        public TipoServicioVariosForm(int idTipoServicio)
        {
            this.idTipoServicio = idTipoServicio;
            forma = 2;
            InitializeComponent();
            TipoServicio tipoServicio = new TipoServicio();
            txNombre.Text = tipoServicio.obtener(idTipoServicio).nombre;
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

            if  (forma == 1)
            {
                tipoServicio.crear(tvTipoServiciio);
                MessageBox.Show("tipo de servicio creado");          
            }
            else
            {
                tvTipoServiciio.idTipoServicio = idTipoServicio;
                tipoServicio.Modificar(tvTipoServiciio);
            }
            this.Close();

        }

        private void btCancelar_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
