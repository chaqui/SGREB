using SGREB.Models;
using System.Windows;

namespace SGREB.Formularios
{
    /// <summary>
    /// Lógica de interacción para Rol.xaml
    /// </summary>
    public partial class Rol : Window
    {
        private int idRol;
        private int forma;

        public Rol()
        {

            InitializeComponent();
            this.forma = 1;
        }

        public Rol(int idRol)
        {
            this.idRol = idRol;
            this.forma = 2;
            InitializeComponent();
            Controlador.Rol rol = new Controlador.Rol();
            nombreRol.Text = rol.obtener(idRol).nombre;
        }

        private void btRol_click(object sender, RoutedEventArgs e)
        {
            TV_Rol tvrol = new TV_Rol();
            tvrol.nombre = nombreRol.Text;
            Controlador.Rol rol = new Controlador.Rol();
            if(forma == 1)
            {
                rol.Crear(tvrol);
            }
            else
            {
                tvrol.idRol = idRol;
                rol.modificar(tvrol);
            }
         
            this.Close();
        }
    }
}
