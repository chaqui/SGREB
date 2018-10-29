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
    /// Lógica de interacción para MedioForm.xaml
    /// </summary>
    public partial class MedioForm : Window
    {
        private int IdMedio;
        private int forma;

        public MedioForm()
        {   
            InitializeComponent();
            forma = 1;
        }

        public MedioForm(int idMedio)
        {
            this.IdMedio = idMedio;
            forma = 2;
            InitializeComponent();
        }

        /// <summary>
        /// funcion para guardar el medio
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btAceptar_Click(object sender, RoutedEventArgs e)
        {
            string nombre = txNombre.Text;
            if(nombre == "")
            {
                MessageBox.Show("no a ingresado ningun nombre", "error");
                return;
            }
            TV_MedioSolicitud tvMedio = new TV_MedioSolicitud();
            tvMedio.medio = nombre;
            MedioSolicitud medio = new MedioSolicitud();
            if(forma == 1)
            {                   
            medio.crear(tvMedio);
            MessageBox.Show("Medio creado");
            }
            else
            {
                tvMedio.idSolicitud = IdMedio; 
                medio.modificar(tvMedio);
            }
            this.Close();
        }

        private void btCancelar_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
