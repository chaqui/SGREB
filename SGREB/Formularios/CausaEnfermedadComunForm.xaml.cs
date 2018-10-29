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
    public partial class CausaEnfermedadComunForm : Window
    {

        private int forma;
        private int idEnfermedadComun;
        public CausaEnfermedadComunForm()
        {
            InitializeComponent();
            forma = 1;
        }

        public CausaEnfermedadComunForm(int id )
        {
            InitializeComponent();
            forma = 2;
            idEnfermedadComun = id;
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
            TV_CausaEnfermedadComun causa = new TV_CausaEnfermedadComun { nombre = nombre };
            CausaEnfermedadComun causaEnfermedad = new CausaEnfermedadComun();
            if(forma == 1)
            {
                causaEnfermedad.crear(causa);
            }
            else
            {
                causa.idCausa = idEnfermedadComun;
                causaEnfermedad.modificar(causa);
            }
            
            this.Close();
        }
    }
}
