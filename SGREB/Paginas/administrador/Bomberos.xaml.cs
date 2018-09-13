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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SGREB.Paginas.administrador
{
    /// <summary>
    /// Lógica de interacción para Bomberos.xaml
    /// </summary>
    public partial class Bomberos : UserControl
    {
        public Bomberos()
        {
            InitializeComponent();
            

        }

        private void btAgregarElemento_Click(object sender, RoutedEventArgs e)
        {

        }

        private void obtenerBomberos()
        {
            var bitacora = new bitacoraBomberoaContext();
            var bomberos = bitacora.TC_Bombero;

            if (bomberos.Count() == 0)
            {
                
            }
            else
            {
                foreach(var bombero in bomberos)
                {
                    var grado = new Grado();
                    grado = grado.obtener(bombero.grado);

                }
            }
        }
    }
}
