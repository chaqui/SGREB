using SGREB.Controlador;
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
    /// Lógica de interacción para GenerarReportes.xaml
    /// </summary>
    public partial class GenerarReportes : UserControl
    {
        private int[] comunes = new int[] {  3, 4, 7, 9, 14, 15, 19, 21, 22, 23, 24, 28, 30, 31, 32, 33, 34 };
        private int[] incendios = new int[] { 16, 17, 18, 25, 26, 27, 28 };
        public GenerarReportes()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

            DateTime inicio;
            DateTime final;
            string ubicacion;

            System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();

            if (folderBrowserDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                ubicacion = folderBrowserDialog1.SelectedPath;
            }
            else
            {
                return;
            }

            try
            {
                 inicio = DateTime.Parse(fechaInicial.SelectedDate.ToString());
                 final = DateTime.Parse(fechaFinal.SelectedDate.ToString());
            }
            catch
            {
                return;
            }
            
            Reportes reportes = new Reportes();
            PDFCreador creator = new PDFCreador();
            TipoIncidente tipoIncidente = new TipoIncidente();
            Bombero bombero = new Bombero();
            foreach (var comun in comunes)
            {
               List< DataGridComunDatos> datos = reportes.obtenerReproteComunes(comun, inicio, final);
                
                if(datos.Count > 0)
                {
                    creator.crearPDFcomun(tipoIncidente.obtenerNombre(comun), inicio, final, datos, bombero.seleccionarJefeDeCompania(),bombero.secretario(), ubicacion+"/"+tipoIncidente.obtenerNombre(comun));
                }

            }

            foreach (var incendio in incendios)
            {
                List<DataGridIncendiosDatos> datos = reportes.obtenerIncendios(incendio, inicio, final);
                if (datos.Count > 0)
                {
                    creator.crearPDFIncendio(tipoIncidente.obtenerNombre(incendio), inicio, final, datos, bombero.seleccionarJefeDeCompania(), bombero.secretario(), ubicacion + "/" + tipoIncidente.obtenerNombre(incendio));
                }

            }

        }
    }
}
