using SGREB.Controlador;
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
            Grado grado = new Grado(nombre);
            grado.Crear();
            this.Close();
        }
    }
}
