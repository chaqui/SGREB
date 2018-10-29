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
    /// Lógica de interacción para SolicitanteCertificacionForm.xaml
    /// </summary>
    public partial class SolicitanteCertificacionForm : Window
    {
        public int id;
        public bool cancelar;
        private int idSolicitud;
        public SolicitanteCertificacionForm(int idSolicitud)
        {
            InitializeComponent();
            this.idSolicitud = idSolicitud;
            
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            cancelar = false;
            if(txNombre.Text =="" || txProfesion.Text == "")
            {
                MessageBox.Show("Le faltan datos");
                return;
            }
            string nombre = txNombre.Text;
            string profesion = txProfesion.Text;
            if(nombre.Count() > 75 || profesion.Count() >75)
            {
                MessageBox.Show("Exceso de Caracteres");
                return;
            }

            Certificacion certificacion = new Certificacion();
            id = certificacion.crear(new TC_Certificacion { solicitante = nombre, profesion = profesion, idSolicitud = idSolicitud, fecha = DateTime.Today });

            this.Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            cancelar = true;
            this.Close();
        }
    }
}
