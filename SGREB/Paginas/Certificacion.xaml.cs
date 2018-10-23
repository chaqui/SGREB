using SGREB.Controlador;
using SGREB.Formularios;
using SGREB.miscellany;
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

namespace SGREB.Paginas
{
    /// <summary>
    /// Lógica de interacción para Certificacion.xaml
    /// </summary>
    public partial class Certificacion : UserControl
    {
        public Certificacion()
        {
            InitializeComponent();
        }

        private void btBuscar_Click(object sender, RoutedEventArgs e)
        {
            int id = 0;
            if (txTipo.Text != "")
            {
                try
                {
                    id = int.Parse(txTipo.Text);
                }
                catch
                {
                    MessageBox.Show("debe de ingresar numeros");
                }
            }
            else
            {
                MessageBox.Show("No ingreso el tipo");
                return;
            }

            if (dpInicial.SelectedDate.ToString() == "" || dpFinal.SelectedDate.ToString() == "")
            {
                MessageBox.Show("Le falto una fecha");
                return;
            }

            DateTime fechaInicio = DateTime.Parse(dpInicial.SelectedDate.ToString());
            DateTime fechaFinal = DateTime.Parse(dpFinal.SelectedDate.ToString());
            Reportes reportes = new Reportes();
            List<DataGridBusqueCertificacionDatos> datos = reportes.busquedaDatosCertificacion(id, fechaInicio, fechaFinal);
            foreach (DataGridBusqueCertificacionDatos d in datos)
            {
                dgBusqueda.Items.Add(d);
            }

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Reportes reportes = new Reportes();
            PDFCreador creador = new PDFCreador();

            var seleccionado = (DataGridBusqueCertificacionDatos)dgBusqueda.SelectedItem;
            SolicitanteCertificacionForm solicitante = new SolicitanteCertificacionForm(int.Parse(seleccionado.id));
            solicitante.ShowDialog();

            if (solicitante.cancelar)
            {
                return; 
            }
            var datos = reportes.obtenerCertificacion(int.Parse(seleccionado.id), solicitante.id);
            string ubicaciion = obtenerLugar();
            if (ubicaciion != "")
            {
                creador.crearCertificacion(datos, new BomberoInforme { NombreCompleto = "Juan Pedro Paz", rol="Secretario" }, ubicaciion);
            }
        }

        private string obtenerLugar()
        {
            System.Windows.Forms.SaveFileDialog saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            saveFileDialog1.Filter = "PDF|*.pdf";
            saveFileDialog1.Title = "Guardar PDF";
            saveFileDialog1.ShowDialog();
            if (saveFileDialog1.FileName != "")
            {
                return saveFileDialog1.FileName;
            }
            return "";

        }
    }
}
