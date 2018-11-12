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
    /// Lógica de interacción para CausaSuicidioForm.xaml
    /// </summary>
    public partial class IntoxicacionForm : Window
    {
        private int idIntoxicacion;
        private int forma;
        public IntoxicacionForm()
        {
            InitializeComponent();
            this.forma = 1;
        }

        public IntoxicacionForm(int idIntoxicacion)
        {
            this.idIntoxicacion = idIntoxicacion;
            this.forma = 2;
            InitializeComponent();
            CausaIntoxicacion causaIntoxicacion = new CausaIntoxicacion();

            txNombreCausa.Text = causaIntoxicacion.obtener(idIntoxicacion).nombre;
        }

        private void btCancelar_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }


        private void btGuardar_Click(object sender, RoutedEventArgs e)
        {
            string nombre = txNombreCausa.Text;

            if(nombre == "")
            {
                MessageBox.Show("no ha ingresado ningun nombre");
                return;
            }
            TV_CausaIntoxicacion causa = new TV_CausaIntoxicacion { nombre = nombre };
            CausaIntoxicacion causaIntoxicacion = new CausaIntoxicacion();
            if(forma == 1)
            {
                causaIntoxicacion.crear(causa);
            }
            else
            {
                causa.idCausaIntoxicacion = idIntoxicacion;
                causaIntoxicacion.modificar(causa);
            }
            
            this.Close();
        }
    }
}
