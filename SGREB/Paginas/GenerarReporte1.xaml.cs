﻿using SGREB.Controlador;
using SGREB.miscellany;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace SGREB.Paginas
{
    /// <summary>
    /// Lógica de interacción para GenerarReporte1.xaml
    /// </summary>
    public partial class GenerarReporte1 : UserControl
    {
        private int[] comunes = new int[] {  3, 7, 9, 14, 15, 19, 21, 22, 23, 24, 28, 30, 31, 32, 33, 34 };
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
                dgComun.Items.Clear();
                dgEComun.Items.Clear();
                dgMaternidad.Items.Clear();
                dgAtropellados.Items.Clear();
                dgIncendiosA.Items.Clear();
                dgAtropellados.Items.Clear();
                dgIncendiosA.Items.Clear();
                dgServicosDeAgua.Items.Clear();
                dgSuicidio.Items.Clear();
                dgAccidentesTransito.Items.Clear();
                dgComun.Visibility = Visibility.Collapsed;
                dgEComun.Visibility = Visibility.Collapsed;
                dgMaternidad.Visibility = Visibility.Collapsed;
                dgAtropellados.Visibility = Visibility.Collapsed;
                dgIncendiosA.Visibility = Visibility.Collapsed;
                dgAccidentesTransito.Visibility = Visibility.Collapsed;
                dgServicosDeAgua.Visibility = Visibility.Collapsed;
                dgSuicidio.Visibility = Visibility.Collapsed;
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
                else if (idIncidente == 10)
                {
                    buscarAccidentes();
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

        private void buscarAccidentes()
        {
            try
            {
                DateTime fechaInicio = DateTime.Parse(dpInicio.SelectedDate.ToString());
                DateTime fechaFinal = DateTime.Parse(dpFinal.SelectedDate.ToString());
                Reportes reportes = new Reportes();
                List<DataGridAccidenteTransito> resultado = reportes.obtenerReporteAccidenteTransito(idIncidente, fechaInicio, fechaFinal);

                foreach(var item in resultado)
                {
                    item.cantidad = "1";
                    item.herido = item.herido == "True" ? "x" : " ";
                    item.fallecido = item.fallecido == "True" ? "x" : " ";
                    item.hora = item.hora + " Hrs.";
                    dgAccidentesTransito.Items.Add(item);
                }
                dgAccidentesTransito.Visibility = Visibility.Visible;
            }
            catch
            {
                MessageBox.Show("Error en la busqueda");
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
                dgEComun.Items.Clear();
                foreach (var item in resultado)
                {
                    item.Cantidad = i.ToString();
                    dgEComun.Items.Add(item);
                }
                dgEComun.Visibility = Visibility.Visible;
            }
            catch
            {
                MessageBox.Show("Error en la busqueda");
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
                MessageBox.Show("Error en la busqueda");
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
            DateTime fechaInicio = DateTime.Parse(dpInicio.SelectedDate.ToString());
            DateTime fechaFinal = DateTime.Parse(dpFinal.SelectedDate.ToString());

            Reportes reportes = new Reportes();
            List < DataGridAnimalDatos> resultado = reportes.obtenerMordidos(fechaInicio, fechaFinal);


            dgIntoxicados.Items.Clear();

            foreach (var item in resultado)
            {
                item.cantidad = "1";
                item.vivo = item.fallecido == "False" ? "x" : item.fallecido == null ? "x" : " ";
                item.fallecido = item.fallecido == "True" ? "x" : " ";
                item.hora = item.hora + " Hrs.";
                dgIntoxicados.Items.Add(item);

            }
            dgIntoxicados.Visibility = Visibility.Visible;
        }

        private void buscarIntoxicados()
        {
            DateTime fechaInicio = DateTime.Parse(dpInicio.SelectedDate.ToString());
            DateTime fechaFinal = DateTime.Parse(dpFinal.SelectedDate.ToString());

            Reportes reportes = new Reportes();
            List<DataGridIntoxicadosDatos> resultado = reportes.obtenerIntoxicados(fechaInicio, fechaFinal);


            dgIntoxicados.Items.Clear();

            foreach (var item in resultado)
            {
                item.cantidad = "1";
                item.vivo = item.fallecido == "False" ? "x" : item.fallecido == null ? "x" : " ";
                item.fallecido = item.fallecido == "True" ? "x" : " ";
                item.hora = item.hora + " Hrs.";
                dgIntoxicados.Items.Add(item);

            }
            dgIntoxicados.Visibility = Visibility.Visible;
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
                MessageBox.Show("Error en la busqueda");
            }
        }

        private void buscarMaternidad()
        {
            try
            {
                DateTime fechaInicio = DateTime.Parse(dpInicio.SelectedDate.ToString());
                DateTime fechaFinal = DateTime.Parse(dpFinal.SelectedDate.ToString());

                Reportes reportes = new Reportes();
                List<DataGridMaternidadDatos> resultado = reportes.obtenerMaternidad(idIncidente, fechaInicio, fechaFinal);


                dgMaternidad.Items.Clear();

                foreach (var item in resultado)
                {
                    item.cantidad = "1";
                    item.vivo = item.fallecido == "False" ? "x" : item.fallecido == null?"x": " ";
                    item.fallecido = item.fallecido == "True" ? "x" : " ";
                    item.hora = item.hora + " Hrs.";
                    dgMaternidad.Items.Add(item);

                }
                dgMaternidad.Visibility = Visibility.Visible;
            }
            catch
            {
                MessageBox.Show("Error en la busqueda");
            }
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
                MessageBox.Show("Error en la busqueda");
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
                MessageBox.Show("Error en la busqueda");
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
                else if(idIncidente == 10 )
                {
                    crearPdfAccidentesDeTransiont();
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

        private void crearPdfAccidentesDeTransiont()
        {
            DateTime fechaInicio = DateTime.Parse(dpInicio.SelectedDate.ToString());
            DateTime fechaFinal = DateTime.Parse(dpFinal.SelectedDate.ToString());
            List<DataGridAccidenteTransito> datos = new List<DataGridAccidenteTransito>();
            foreach (var item in dgAccidentesTransito.Items)
            {
                datos.Add((DataGridAccidenteTransito)item);
            }

            PDFCreador pdf = new PDFCreador();

            TipoIncidente tipo = new TipoIncidente();
            var nombreTipo = tipo.obtenerNombre(idIncidente);

            List<string> ubicaciion = obtenerLugar();

            if (ubicaciion[0] != "")
            {
                pdf.crearPDFAccidenteTransito(nombreTipo, fechaInicio, fechaFinal, datos, new BomberoInforme { NombreCompleto = "Juan Pedro Paz" }, new BomberoInforme { NombreCompleto = "Pedro Antonio Yoc Perez" }, ubicaciion[0]);
            }
            else
            {
                MessageBox.Show("No coloco correctamente la ubicacion");
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

            List<string> ubicaciion = obtenerLugar();
            if (ubicaciion[0] != "")
            {
                pdf.crearPDFEComun(nombreTipo, fechaInicio, fechaFinal, datos, new BomberoInforme { NombreCompleto = "Juan Pedro Paz" }, new BomberoInforme { NombreCompleto = "Pedro Antonio Yoc Perez" }, ubicaciion[0]);
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

            List<string> ubicaciion = obtenerLugar();
            if (ubicaciion[0] != "")
            {
                pdf.crearPdfSuicidios(nombreTipo, fechaInicio, fechaFinal, datos, new BomberoInforme { NombreCompleto = "Juan Pedro Paz" }, new BomberoInforme { NombreCompleto = "Pedro Antonio Yoc Perez" }, ubicaciion[0]);
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

            List<string> ubicaciion = obtenerLugar();
            if (ubicaciion[0] != "")
            {
                pdf.crearPdfServiciosDeAgua(nombreTipo, fechaInicio, fechaFinal, datos, new BomberoInforme { NombreCompleto = "Juan Pedro Paz" }, new BomberoInforme { NombreCompleto = "Pedro Antonio Yoc Perez" }, ubicaciion[0]);
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

            List<string> ubicaciion = obtenerLugar();
            if (ubicaciion[0] != "")
            {
                pdf.crearPDFAtropellado(nombreTipo, fechaInicio, fechaFinal, datos, new BomberoInforme { NombreCompleto = "Juan Pedro Paz" }, new BomberoInforme { NombreCompleto = "Pedro Antonio Yoc Perez" }, ubicaciion[0]);
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

            List<String> ubicaciion = obtenerLugar();
            if (ubicaciion[0] != "")
            {
                pdf.crearPDFIncendio(nombreTipo, fechaInicio, fechaFinal, datos, new BomberoInforme { NombreCompleto = "Juan Pedro Paz" }, new BomberoInforme { NombreCompleto = "Pedro Antonio Yoc Perez" }, ubicaciion[0]);
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

            List<string> ubicaciion = obtenerLugar();
            if (ubicaciion[0] != "")
            {
                pdf.crearPDFcomun(nombreTipo, fechaInicio, fechaFinal, datos, new BomberoInforme { NombreCompleto = "Juan Pedro Paz" }, new BomberoInforme { NombreCompleto = "Pedro Antonio Yoc Perez" }, ubicaciion[0]);
            }
            else
            {
                MessageBox.Show("No coloco correctamente la ubicacion");
            }
    }

        private List<string> obtenerLugar()
        {
            List<string> resultados = new List<string>();
            System.Windows.Forms.SaveFileDialog saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            saveFileDialog1.Filter = "PDF|*.pdf | DOCX|*.docx";
            saveFileDialog1.Title = "Guardar PDF";
            saveFileDialog1.ShowDialog();
            if (saveFileDialog1.Filter == "")
            {
                MessageBox.Show("No selecciono el tipo de formato");
                return null;
            }
            if (saveFileDialog1.FileName != "")
            {
                resultados.Add( saveFileDialog1.FileName);
                resultados.Add(saveFileDialog1.Filter);
                return resultados;
            }
            return null;
        }

    }
}