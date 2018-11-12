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
        private int idGrado;
        private int forma;
        public GradoForm()
        {
            forma = 1;
            InitializeComponent();
            
        }

        public GradoForm(int idGrado)
        {
            forma = 2;
            this.idGrado = idGrado;
            InitializeComponent();
            Grado grado = new Grado();
            nombreGrado.Text = grado.obtener(idGrado).nombreGrado;
        }

        private void btGrado_Click(object sender, RoutedEventArgs e)
        {
            var nombre = this.nombreGrado.Text;
            Grado grado = new Grado();
            var tvGrado = new TV_Grado();
            tvGrado.nombreGrado = nombre;

            if(forma ==1)
            {
                grado.Crear(tvGrado);
            }
            else
            {
                tvGrado.idGrado = idGrado;
                grado.modificar(tvGrado);
            }
            
            this.Close();
        }

        private void btCancelar_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
