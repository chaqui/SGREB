using SGREB.Controlador;
using SGREB.Models;
using System.Windows;

namespace SGREB.Formularios
{
    /// <summary>
    /// Lógica de interacción para Grado.xaml
    /// </summary>
    public partial class GradoForm : Window
    {
        public GradoForm()
        {
            InitializeComponent();
        }

        private void btGrado_Click(object sender, RoutedEventArgs e)
        {
            var nombre = this.nombreGrado.Text;
            Grado grado = new Grado();
            var tvGrado = new TV_Grado();
            tvGrado.nombreGrado = nombre;
            grado.Crear(tvGrado);
            this.Close();
        }

        private void btCancelar_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
