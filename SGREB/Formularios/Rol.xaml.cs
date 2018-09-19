using SGREB.Models;
using System.Windows;

namespace SGREB.Formularios
{
    /// <summary>
    /// Lógica de interacción para Rol.xaml
    /// </summary>
    public partial class Rol : Window
    {
        public Rol()
        {
            InitializeComponent();
        }

        private void btRol_click(object sender, RoutedEventArgs e)
        {
            TV_Rol tvrol = new TV_Rol();
            tvrol.nombre = nombreRol.Text;
            Controlador.Rol rol = new Controlador.Rol();
            rol.Crear(tvrol);
            this.Close();
        }
    }
}
