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
using System.Windows.Shapes;

namespace SGREB.Formularios
{
    /// <summary>
    /// Lógica de interacción para TipoUnidadForm.xaml
    /// </summary>
    public partial class TipoUnidadForm : Window
    {
        public TipoUnidadForm()
        {
            InitializeComponent();
        }



        private void btCancelar_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btIngresarTipo_Click(object sender, RoutedEventArgs e)
        {
            var unidad = txTipoUnidad.Text;
            if(unidad == "")
            {
                MessageBox.Show("No ingreso ningun dato", "error");
                return;
            }
            else
            {
                TipoUnidad unidadTipo = new TipoUnidad();
                var tvTipoUnidad = new TV_TipoUnidad();
                tvTipoUnidad.nombreTipo = unidad;
                unidadTipo.Crear(tvTipoUnidad);
                this.Close();
            }
        }
    }
}
