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
    /// Lógica de interacción para GenerarReporte1.xaml
    /// </summary>
    public partial class GenerarReporte1 : UserControl
    {
        private int[] comunes = new int[] {  3, 4, 7, 9, 14, 15, 19, 21, 22, 23, 24, 28, 30, 31, 32, 33, 34 };
        private int[] incendios = new int[] { 16, 17, 18, 25, 26, 27, 28 };
        private int idIncidente;
       
        public GenerarReporte1()
        {
            InitializeComponent();
        }

        private void btBuscar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                idIncidente = int.Parse(txTipoReporte.Text);
                if (Array.IndexOf(comunes, idIncidente) != -1)
                {
                    buscarComunes(idIncidente);
                }
                else if (Array.IndexOf(incendios, idIncidente) != -1)
                {
                    buscarIncendios();
                }

                else if (idIncidente == 2)
                {
                    buscarEnfermedadComun();
                }
                else if (idIncidente == 4)
                {
                    buscarMaternidad();
                }
                else if (idIncidente == 5)
                {
                    buscarAtropellados();
                }
                else if (idIncidente == 6)
                {
                    buscarIntoxicados();
                }
                else if (idIncidente == 8)
                {
                    buscarMordidos();
                }
                else if (idIncidente == 12)
                {
                    buscarServicioDeAgua();
                }
                else if (idIncidente == 20)
                {
                    buscarSuicidios();
                }
                else if (idIncidente == 29)
                {

                }
            }
            catch
            {

            }
        }

        private void buscarEnfermedadComun()
        {
            try
            {
                DateTime fechaInicio = DateTime.Parse(dpInicio.SelectedDate.ToString());
                DateTime fechaFinal = DateTime.Parse(dpFinal.SelectedDate.ToString());

                Reportes reportes = new Reportes();
                List<DataGridEnfermedadComunDatos> resultado = reportes.obtenerReporteEnfermedadComun(idIncidente, fechaInicio, fechaFinal);

                int i = 1;
                dgSuicidio.Items.Clear();
                foreach (var item in resultado)
                {
                    item.Cantidad = i.ToString();
                    dgEComun.Items.Add(item);
                    i++;
                }
                dgSuicidio.Visibility = Visibility.Visible;
            }
            catch
            {

            }
        }

        private void buscarSuicidios()
        {
            try
            {
                DateTime fechaInicio = DateTime.Parse(dpInicio.SelectedDate.ToString());
                DateTime fechaFinal = DateTime.Parse(dpFinal.SelectedDate.ToString());

                Reportes reportes = new Reportes();
                List<DataGridFallecimientoDatos> resultado = reportes.obtenerSuicidios(idIncidente, fechaInicio, fechaFinal);

                int i = 1;
                dgSuicidio.Items.Clear();
                foreach (var item in resultado)
                {
                    item.cantidad = i.ToString();
                    item.hora = item.hora + " Hrs.";
                    dgSuicidio.Items.Add(item);
                    i++;
                }
                dgSuicidio.Visibility = Visibility.Visible;
            }
            catch
            {

            }
        }

        private void buscarServicioDeAgua()
        {
            try
            {
                DateTime fechaInicio = DateTime.Parse(dpInicio.SelectedDate.ToString());
                DateTime fechaFinal = DateTime.Parse(dpFinal.SelectedDate.ToString());

                Reportes reportes = new Reportes();
                List<DataGridServiciosDeAguaDatos> resultado = reportes.obtnerServiciosDeAgua(idIncidente, fechaInicio, fechaFinal);

                int i = 1;
                dgServicosDeAgua.Items.Clear();
                foreach (var item in resultado)
                {
                    item.cantidad = i.ToString();
                    item.hora = item.hora + " Hrs.";
                    dgServicosDeAgua.Items.Add(item);
                    i++;
                }
                dgServicosDeAgua.Visibility = Visibility.Visible;
            }
            catch
            {

            }
        }

        private void buscarMordidos()
        {
            throw new NotImplementedException();
        }

        private void buscarIntoxicados()
        {
            throw new NotImplementedException();
        }

        private void buscarAtropellados()
        {
            try
            {
                DateTime fechaInicio = DateTime.Parse(dpInicio.SelectedDate.ToString());
                DateTime fechaFinal = DateTime.Parse(dpFinal.SelectedDate.ToString());

                Reportes reportes = new Reportes();
                List<DataGridAtropelladosDatos> resultado = reportes.obtenerreportesAtropellados(idIncidente, fechaInicio, fechaFinal);

                int i = 1;
                dgAtropellados.Items.Clear();

                foreach (var item in resultado)
                {
                    item.cantidad = i.ToString();
                    item.fallecido = item.fallecido == "True" ? "x" : " ";
                    item.vivo = item.vivo == "True" ? "x" : " ";
                    item.hora = item.hora + " Hrs.";
                    dgAtropellados.Items.Add(item);
                    i++;
                }
                dgAtropellados.Visibility = Visibility.Visible;
            }
            catch
            {

            }
        }

        private void buscarMaternidad()
        {
            throw new NotImplementedException();
        }

        private void buscarIncendios()
        {
            try
            {
                DateTime fechaInicio = DateTime.Parse(dpInicio.SelectedDate.ToString());
                DateTime fechaFinal = DateTime.Parse(dpFinal.SelectedDate.ToString());

                Reportes reportes = new Reportes();
                List<DataGridIncendiosDatos> resultado = reportes.obtenerIncendios(idIncidente, fechaInicio, fechaFinal);

                int i = 1;
                dgIncendiosA.Items.Clear();
                foreach (var item in resultado)
                {
                    item.Cantidad = i.ToString();
                    item.Hora = item.Hora + " Hrs.";
                    dgIncendiosA.Items.Add(item);
                    i++;
                }
                dgIncendiosA.Visibility = Visibility.Visible;
            }
            catch
            {

            }
        }

        private void buscarComunes(int idIncidente)
        {
            try
            {
                DateTime fechaInicio = DateTime.Parse(dpInicio.SelectedDate.ToString());
                DateTime fechaFinal = DateTime.Parse(dpFinal.SelectedDate.ToString());

                Reportes reportes = new Reportes();
                List<DataGridComunDatos> resultado = reportes.obtenerReproteComunes(idIncidente, fechaInicio, fechaFinal);

                int i = 1;
                dgComun.Items.Clear();
                foreach (var item in resultado) {
                    item.Cantidad = i.ToString();
                    item.Fallecido = item.Fallecido == "True" ? "x" : " ";
                    item.Vivo = item.Vivo == "True" ? "x" : " ";
                    item.Hora = item.Hora + " Hrs.";
                    dgComun.Items.Add(item);
                    i++;
                }
                dgComun.Visibility = Visibility.Visible;
            }
            catch
            {

            }

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

            try
            {
                if (Array.IndexOf(comunes, idIncidente) != -1)
                {
                    crearPdfComun();
                }
                else if (Array.IndexOf(incendios, idIncidente) != -1)
                {
                    crearPdfIncendio();
                }
                else if (idIncidente == 2)
                {
                    crearPdfEComun();
                }

                else if (idIncidente == 4)
                {
                    crearPdfMaternidad();
                }
                else if (idIncidente == 5)
                {
                    crearPdfAtropellados();
                }
                else if (idIncidente == 6)
                {
                    crearPdfIntoxicados();
                }
                else if (idIncidente == 8)
                {
                    crearPdfMordidos();
                }
                else if (idIncidente == 12)
                {
                    crearPdfServicioAgua();

                }
                else if (idIncidente == 20)
                {
                    crearPdfSuicidios();
                }
                else if (idIncidente == 29)
                {
                    crearPdfInundaciones();
                }

            }
            catch
            {

            }

        }

        private void crearPdfEComun()
        {
            DateTime fechaInicio = DateTime.Parse(dpInicio.SelectedDate.ToString());
            DateTime fechaFinal = DateTime.Parse(dpFinal.SelectedDate.ToString());
            List<DataGridEnfermedadComunDatos> datos = new List<DataGridEnfermedadComunDatos>();
            foreach (var item in dgComun.Items)
            {
                datos.Add((DataGridEnfermedadComunDatos)item);
            }

            PDFCreador pdf = new PDFCreador();

            TipoIncidente tipo = new TipoIncidente();
            var nombreTipo = tipo.obtenerNombre(idIncidente);

            string ubicaciion = obtenerLugar();
            if (ubicaciion != "")
            {
                pdf.crearPDFEComun(nombreTipo, fechaInicio, fechaFinal, datos, new BomberoInforme { NombreCompleto = "Juan Pedro Paz" }, new BomberoInforme { NombreCompleto = "Pedro Antonio Yoc Perez" }, ubicaciion);
            }
            else
            {
                MessageBox.Show("No coloco correctamente la ubicacion");
            }
        }

        private void crearPdfInundaciones()
        {
            throw new NotImplementedException();
        }

        private void crearPdfSuicidios()
        {
            DateTime fechaInicio = DateTime.Parse(dpInicio.SelectedDate.ToString());
            DateTime fechaFinal = DateTime.Parse(dpFinal.SelectedDate.ToString());
            List<DataGridFallecimientoDatos> datos = new List<DataGridFallecimientoDatos>();
            foreach (var item in dgSuicidio.Items)
            {
                datos.Add((DataGridFallecimientoDatos)item);
            }

            PDFCreador pdf = new PDFCreador();

            TipoIncidente tipo = new TipoIncidente();
            var nombreTipo = tipo.obtenerNombre(idIncidente);

            string ubicaciion = obtenerLugar();
            if (ubicaciion != "")
            {
                pdf.crearPdfSuicidios(nombreTipo, fechaInicio, fechaFinal, datos, new BomberoInforme { NombreCompleto = "Juan Pedro Paz" }, new BomberoInforme { NombreCompleto = "Pedro Antonio Yoc Perez" }, ubicaciion);
            }
            else
            {
                MessageBox.Show("No coloco correctamente la ubicacion");
            }
        }

        private void crearPdfServicioAgua()
        {
            DateTime fechaInicio = DateTime.Parse(dpInicio.SelectedDate.ToString());
            DateTime fechaFinal = DateTime.Parse(dpFinal.SelectedDate.ToString());
            List<DataGridServiciosDeAguaDatos> datos = new List<DataGridServiciosDeAguaDatos>();
            foreach (var item in dgAtropellados.Items)
            {
                datos.Add((DataGridServiciosDeAguaDatos)item);
            }

            PDFCreador pdf = new PDFCreador();

            TipoIncidente tipo = new TipoIncidente();
            var nombreTipo = tipo.obtenerNombre(idIncidente);

            string ubicaciion = obtenerLugar();
            if (ubicaciion != "")
            {
                pdf.crearPdfServiciosDeAgua(nombreTipo, fechaInicio, fechaFinal, datos, new BomberoInforme { NombreCompleto = "Juan Pedro Paz" }, new BomberoInforme { NombreCompleto = "Pedro Antonio Yoc Perez" }, ubicaciion);
            }
            else
            {
                MessageBox.Show("No coloco correctamente la ubicacion");
            }
        }

        private void crearPdfMordidos()
        {
            throw new NotImplementedException();
        }

        private void crearPdfIntoxicados()
        {
            throw new NotImplementedException();
        }

        private void crearPdfAtropellados()
        {
            DateTime fechaInicio = DateTime.Parse(dpInicio.SelectedDate.ToString());
            DateTime fechaFinal = DateTime.Parse(dpFinal.SelectedDate.ToString());
            List<DataGridAtropelladosDatos> datos = new List<DataGridAtropelladosDatos>();
            foreach (var item in dgAtropellados.Items)
            {
                datos.Add((DataGridAtropelladosDatos)item);
            }

            PDFCreador pdf = new PDFCreador();

            TipoIncidente tipo = new TipoIncidente();
            var nombreTipo = tipo.obtenerNombre(idIncidente);

            string ubicaciion = obtenerLugar();
            if (ubicaciion != "")
            {
                pdf.crearPDFAtropellado(nombreTipo, fechaInicio, fechaFinal, datos, new BomberoInforme { NombreCompleto = "Juan Pedro Paz" }, new BomberoInforme { NombreCompleto = "Pedro Antonio Yoc Perez" }, ubicaciion);
            }
            else
            {
                MessageBox.Show("No coloco correctamente la ubicacion");
            }
        }

        private void crearPdfMaternidad()
        {
            throw new NotImplementedException();
        }

        private void crearPdfIncendio()
        {
            DateTime fechaInicio = DateTime.Parse(dpInicio.SelectedDate.ToString());
            DateTime fechaFinal = DateTime.Parse(dpFinal.SelectedDate.ToString());
            List<DataGridIncendiosDatos> datos = new List<DataGridIncendiosDatos>();
            foreach (var item in dgIncendiosA.Items)
            {
                datos.Add((DataGridIncendiosDatos)item);
            }

            PDFCreador pdf = new PDFCreador();

            TipoIncidente tipo = new TipoIncidente();
            var nombreTipo = tipo.obtenerNombre(idIncidente);

            string ubicaciion = obtenerLugar();
            if (ubicaciion != "")
            {
                pdf.crearPDFIncendio(nombreTipo, fechaInicio, fechaFinal, datos, new BomberoInforme { NombreCompleto = "Juan Pedro Paz" }, new BomberoInforme { NombreCompleto = "Pedro Antonio Yoc Perez" }, ubicaciion);
            }
            else
            {
                MessageBox.Show("No coloco correctamente la ubicacion");
            }
            
        }

        private void crearPdfComun()
        {
            DateTime fechaInicio = DateTime.Parse(dpInicio.SelectedDate.ToString());
            DateTime fechaFinal = DateTime.Parse(dpFinal.SelectedDate.ToString());
            List<DataGridComunDatos> datos = new List<DataGridComunDatos>();
            foreach (var item in dgComun.Items)
            {
                datos.Add((DataGridComunDatos)item);
            }

            PDFCreador pdf = new PDFCreador();

            TipoIncidente tipo = new TipoIncidente();
            var nombreTipo = tipo.obtenerNombre(idIncidente);

            string ubicaciion = obtenerLugar();
            if (ubicaciion != "")
            {
                pdf.crearPDFcomun(nombreTipo, fechaInicio, fechaFinal, datos, new BomberoInforme { NombreCompleto = "Juan Pedro Paz" }, new BomberoInforme { NombreCompleto = "Pedro Antonio Yoc Perez" }, ubicaciion);
            }
            else
            {
                MessageBox.Show("No coloco correctamente la ubicacion");
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
