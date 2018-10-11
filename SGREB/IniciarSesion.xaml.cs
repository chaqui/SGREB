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
using SGREB.Controlador;

namespace SGREB
{
    /// <summary>
    /// Lógica de interacción para IniciarSesion.xaml
    /// </summary>
    public partial class IniciarSesion : Window
    {
        private InicioDeSesion inicioDeSesion;
        public IniciarSesion()
        {
            InicioDeSesion = new InicioDeSesion();
            InitializeComponent();
        }

        internal InicioDeSesion InicioDeSesion { get => inicioDeSesion; set => inicioDeSesion = value; }

        private void btInciarSesion_Click(object sender, RoutedEventArgs e)
        {
            String usuario = txUsuario.Text;
            String contrasenia = pBcontrsenia.Password;
            iniciarSesion(usuario, contrasenia);
            this.Close();

        }

        private void iniciarSesion(String usuario, String contrasenia)
        {
            inicioDeSesion.ingreso = true;
            if (usuario == "a")
            {
                
                inicioDeSesion.administrador = true;
               
            }
            else
            {
                inicioDeSesion.normal = true;
            }
        }
    }
}
