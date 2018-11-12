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
    public partial class CausaSuicidioForm : Window
    {
        private int idCausaSuicidio;
        private int forma;
        public CausaSuicidioForm()
        {
            forma = 1;
            InitializeComponent();
        }

        public CausaSuicidioForm(int idCausaSuicidio)
        {
            this.idCausaSuicidio = idCausaSuicidio;
            forma = 2;
             InitializeComponent();
            CausaSuicidio causaSuicidio = new CausaSuicidio();
            txNombreCausa.Text = causaSuicidio.obtener(idCausaSuicidio).CausaSuicidio;
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
            TV_CausaSuicidio causa = new TV_CausaSuicidio { CausaSuicidio = nombre };
            CausaSuicidio causaSuicidio = new CausaSuicidio();
            if (forma == 1)
            {
                causaSuicidio.crear(causa);
            }
            else
            {
                causa.idCausa = idCausaSuicidio;
                causaSuicidio.modificar(causa);
            }
           
        }
    }
}
