using SGREB.Controlador;
using SGREB.Models;
using System.Windows;

namespace SGREB.Formularios
{
    /// <summary>
    /// Lógica de interacción para Rol.xaml
    /// </summary>
    public partial class InstitucionForm : Window
    {
        public InstitucionForm()
        {
            InitializeComponent();
        }

        private void btRol_click(object sender, RoutedEventArgs e)
        {
            TT_Lugar ttLugar = new TT_Lugar();
            ttLugar.institucio = nombreRol.Text;
            Lugar lugar = new Lugar();
            lugar.crear(ttLugar);
            this.Close();
        }
    }
}
