using SGREB.miscellany;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xceed.Words.NET;

namespace SGREB.Controlador
{
    class WordCreador
    {
        private Formatting titleFormat;
        public WordCreador()
        {
            titleFormat = new Formatting();
            titleFormat.FontFamily = new Font("Helvetica");
            titleFormat.Size = 12;
            titleFormat.FontColor = System.Drawing.Color.Black;
            titleFormat.Bold = true;

        }
        public void crearWordcomun(string evento, DateTime fechaInicio, DateTime fechaFinal, List<DataGridComunDatos> elementosInforme, BomberoInforme director, BomberoInforme secretario, String ubicacion)
        {
            //abrir el documento
            var doc = DocX.Create(@ubicacion);
            doc.PageLayout.Orientation = Orientation.Landscape;

            //crear el titulo
            string title = "Benemerito Comite de Bomberos Voluntarios" + Environment.NewLine +
                "19a. Compañia de Bomberos Voluntarios" + Environment.NewLine +
                "Estadisticas de " + evento + Environment.NewLine +
                "Correspondiente del " + fechaInicio.ToShortDateString() + " al " + fechaFinal.ToShortDateString();
            Paragraph paragraphTitle = doc.InsertParagraph(title, false, titleFormat);
            paragraphTitle.Alignment = Alignment.center;

            doc.InsertParagraph(Environment.NewLine + Environment.NewLine);

            ///crear Tabla 
            ///
            Table t = doc.AddTable(elementosInforme.Count + 1, 8);
            t.Alignment = Alignment.center;
            t.Design = TableDesign.ColorfulGrid;
            //titulo de las tablas 
            t.Rows[0].Cells[0].Paragraphs.First().Append("Fecha").Bold();
            t.Rows[0].Cells[1].Paragraphs.First().Append("Hora").Bold();
            t.Rows[0].Cells[2].Paragraphs.First().Append("Cantidad").Bold();
            t.Rows[0].Cells[3].Paragraphs.First().Append("Lugar").Bold();
            t.Rows[0].Cells[4].Paragraphs.First().Append("Edad").Bold();
            t.Rows[0].Cells[5].Paragraphs.First().Append("Sexo").Bold();
            t.Rows[0].Cells[6].Paragraphs.First().Append("Vivo").Bold();
            t.Rows[0].Cells[7].Paragraphs.First().Append("Fallecido").Bold();

            //elementos de la tabla 
            int filas = 1;
            foreach (DataGridComunDatos elemento in elementosInforme)
            {
                t.Rows[filas].Cells[0].Paragraphs.First().Append(elemento.Fecha);
                t.Rows[filas].Cells[1].Paragraphs.First().Append(elemento.Hora);
                t.Rows[filas].Cells[2].Paragraphs.First().Append(elemento.Cantidad);
                t.Rows[filas].Cells[3].Paragraphs.First().Append(elemento.Lugar);
                t.Rows[filas].Cells[4].Paragraphs.First().Append(elemento.Edad);
                t.Rows[filas].Cells[5].Paragraphs.First().Append(elemento.sexo);
                t.Rows[filas].Cells[6].Paragraphs.First().Append(elemento.Vivo);
                t.Rows[filas].Cells[7].Paragraphs.First().Append(elemento.Fallecido);
                filas++;
            }
            doc.InsertTable(t);
            doc.InsertParagraph(Environment.NewLine + Environment.NewLine);

            Table tf = doc.AddTable(3, 2);
            tf.Alignment = Alignment.center;
            tf.Rows[0].Cells[0].Paragraphs.First().Append("f." + "__________:___");
            tf.Rows[1].Cells[0].Paragraphs.First().Append(director.NombreCompleto);
            tf.Rows[2].Cells[0].Paragraphs.First().Append("Director");

            tf.Rows[0].Cells[1].Paragraphs.First().Append("f." + "______________");
            tf.Rows[1].Cells[1].Paragraphs.First().Append(secretario.NombreCompleto);
            tf.Rows[2].Cells[1].Paragraphs.First().Append("Secretario");
            doc.InsertTable(tf);

            doc.Save();
            Process.Start("WINWORD.EXE", @ubicacion);

        }

        public void crearWordAccidenteTransito(string evento, DateTime fechaInicio, DateTime fechaFinal, List<DataGridAccidenteTransito> elementosInforme, BomberoInforme director, BomberoInforme secretario, String ubicacion)
        {
            //abrir el documento
            var doc = DocX.Create(@ubicacion);
            doc.PageLayout.Orientation = Orientation.Landscape;

            //crear el titulo
            string title = "Benemerito Comite de Bomberos Voluntarios" + Environment.NewLine +
                "19a. Compañia de Bomberos Voluntarios" + Environment.NewLine +
                "Estadisticas de " + evento + Environment.NewLine +
                "Correspondiente del " + fechaInicio.ToShortDateString() + " al " + fechaFinal.ToShortDateString();
            Paragraph paragraphTitle = doc.InsertParagraph(title, false, titleFormat);
            paragraphTitle.Alignment = Alignment.center;

            doc.InsertParagraph(Environment.NewLine + Environment.NewLine);

            ///crear Tabla 
            ///
            Table t = doc.AddTable(elementosInforme.Count + 1, 8);
            t.Alignment = Alignment.center;
            t.Design = TableDesign.ColorfulGrid;
            //titulo de las tablas 
            t.Rows[0].Cells[0].Paragraphs.First().Append("Fecha").Bold();
            t.Rows[0].Cells[1].Paragraphs.First().Append("Hora").Bold();
            t.Rows[0].Cells[2].Paragraphs.First().Append("Cantidad").Bold();
            t.Rows[0].Cells[3].Paragraphs.First().Append("Lugar").Bold();
            t.Rows[0].Cells[4].Paragraphs.First().Append("Tipo Vehiculo").Bold();
            t.Rows[0].Cells[5].Paragraphs.First().Append("Sexo").Bold();
            t.Rows[0].Cells[6].Paragraphs.First().Append("Vivo").Bold();
            t.Rows[0].Cells[7].Paragraphs.First().Append("Fallecido").Bold();

            //elementos de la tabla 
            int filas = 1;
            foreach (DataGridAccidenteTransito elemento in elementosInforme)
            {
                t.Rows[filas].Cells[0].Paragraphs.First().Append(elemento.fecha);
                t.Rows[filas].Cells[1].Paragraphs.First().Append(elemento.hora);
                t.Rows[filas].Cells[2].Paragraphs.First().Append(elemento.cantidad);
                t.Rows[filas].Cells[3].Paragraphs.First().Append(elemento.lugar);
                t.Rows[filas].Cells[4].Paragraphs.First().Append(elemento.tipoVehiculo);
                t.Rows[filas].Cells[5].Paragraphs.First().Append(elemento.sexo);
                t.Rows[filas].Cells[6].Paragraphs.First().Append(elemento.herido);
                t.Rows[filas].Cells[7].Paragraphs.First().Append(elemento.fallecido);
                filas++;
            }
            doc.InsertTable(t);
            doc.InsertParagraph(Environment.NewLine + Environment.NewLine);

            Table tf = doc.AddTable(3, 2);
            tf.Alignment = Alignment.center;
            tf.Rows[0].Cells[0].Paragraphs.First().Append("f." + "__________:___");
            tf.Rows[1].Cells[0].Paragraphs.First().Append(director.NombreCompleto);
            tf.Rows[2].Cells[0].Paragraphs.First().Append("Director");

            tf.Rows[0].Cells[1].Paragraphs.First().Append("f." + "______________");
            tf.Rows[1].Cells[1].Paragraphs.First().Append(secretario.NombreCompleto);
            tf.Rows[2].Cells[1].Paragraphs.First().Append("Secretario");
            doc.InsertTable(tf);

            doc.Save();
            Process.Start("WINWORD.EXE", @ubicacion);

        }
        public void crearWordIncendio(string evento, DateTime fechaInicio, DateTime fechaFinal, List<DataGridIncendiosDatos> elementosInforme, BomberoInforme director, BomberoInforme secretario, String ubicacion)
        {
            //abrir el documento
            var doc = DocX.Create(@ubicacion);
            doc.PageLayout.Orientation = Orientation.Landscape;

            //crear el titulo
            string title = "Benemerito Comite de Bomberos Voluntarios" + Environment.NewLine +
                "19a. Compañia de Bomberos Voluntarios" + Environment.NewLine +
                "Estadisticas de " + evento + Environment.NewLine +
                "Correspondiente del " + fechaInicio.ToShortDateString() + " al " + fechaFinal.ToShortDateString();
            Paragraph paragraphTitle = doc.InsertParagraph(title, false, titleFormat);
            paragraphTitle.Alignment = Alignment.center;

            doc.InsertParagraph(Environment.NewLine + Environment.NewLine);

            ///crear Tabla 
            ///
            Table t = doc.AddTable(elementosInforme.Count + 1, 9);
            t.Alignment = Alignment.center;
            t.Design = TableDesign.ColorfulGrid;
            //titulo de las tablas 
            t.Rows[0].Cells[0].Paragraphs.First().Append("Fecha").Bold();
            t.Rows[0].Cells[1].Paragraphs.First().Append("Hora").Bold();
            t.Rows[0].Cells[2].Paragraphs.First().Append("Cantidad").Bold();
            t.Rows[0].Cells[3].Paragraphs.First().Append("Lugar").Bold();
            t.Rows[0].Cells[4].Paragraphs.First().Append("Propietario").Bold();
            t.Rows[0].Cells[5].Paragraphs.First().Append("Perdidas").Bold();
            t.Rows[0].Cells[6].Paragraphs.First().Append("Agua Utilizada").Bold();
            t.Rows[0].Cells[7].Paragraphs.First().Append("Fallecidos").Bold();
            t.Rows[0].Cells[8].Paragraphs.First().Append("Vivos").Bold();

            //elementos de la tabla 
            int filas = 1;
            foreach (DataGridIncendiosDatos elemento in elementosInforme)
            {
                t.Rows[filas].Cells[0].Paragraphs.First().Append(elemento.Fecha);
                t.Rows[filas].Cells[1].Paragraphs.First().Append(elemento.Hora);
                t.Rows[filas].Cells[2].Paragraphs.First().Append(elemento.Cantidad);
                t.Rows[filas].Cells[3].Paragraphs.First().Append(elemento.Lugar);
                t.Rows[filas].Cells[4].Paragraphs.First().Append(elemento.propietario);
                t.Rows[filas].Cells[5].Paragraphs.First().Append(elemento.perdidas);
                t.Rows[filas].Cells[6].Paragraphs.First().Append(elemento.aguaUtilizada);
                t.Rows[filas].Cells[7].Paragraphs.First().Append(elemento.Fallecidos);
                t.Rows[filas].Cells[8].Paragraphs.First().Append(elemento.Vivos);
                filas++;
            }
            doc.InsertTable(t);
            doc.InsertParagraph(Environment.NewLine + Environment.NewLine);

            Table tf = doc.AddTable(3, 2);
            tf.Alignment = Alignment.center;
            tf.Rows[0].Cells[0].Paragraphs.First().Append("f." + "__________:___");
            tf.Rows[1].Cells[0].Paragraphs.First().Append(director.NombreCompleto);
            tf.Rows[2].Cells[0].Paragraphs.First().Append("Director");

            tf.Rows[0].Cells[1].Paragraphs.First().Append("f." + "______________");
            tf.Rows[1].Cells[1].Paragraphs.First().Append(secretario.NombreCompleto);
            tf.Rows[2].Cells[1].Paragraphs.First().Append("Secretario");
            doc.InsertTable(tf);

            doc.Save();
            Process.Start("WINWORD.EXE", @ubicacion);
        }
        public void crearWordEComun(string evento, DateTime fechaInicio, DateTime fechaFinal, List<DataGridEnfermedadComunDatos> elementosInforme, BomberoInforme director, BomberoInforme secretario, string ubicacion)
        {
            //abrir el documento
            var doc = DocX.Create(@ubicacion);
            doc.PageLayout.Orientation = Orientation.Landscape;

            //crear el titulo
            string title = "Benemerito Comite de Bomberos Voluntarios" + Environment.NewLine +
                "19a. Compañia de Bomberos Voluntarios" + Environment.NewLine +
                "Estadisticas de " + evento + Environment.NewLine +
                "Correspondiente del " + fechaInicio.ToShortDateString() + " al " + fechaFinal.ToShortDateString();
            Paragraph paragraphTitle = doc.InsertParagraph(title, false, titleFormat);
            paragraphTitle.Alignment = Alignment.center;

            doc.InsertParagraph(Environment.NewLine + Environment.NewLine);

            ///crear Tabla 
            ///
            Table t = doc.AddTable(elementosInforme.Count + 1, 9);
            t.Alignment = Alignment.center;
            t.Design = TableDesign.ColorfulGrid;
            //titulo de las tablas 
            t.Rows[0].Cells[0].Paragraphs.First().Append("Fecha").Bold();
            t.Rows[0].Cells[1].Paragraphs.First().Append("Hora").Bold();
            t.Rows[0].Cells[2].Paragraphs.First().Append("Cantidad").Bold();
            t.Rows[0].Cells[3].Paragraphs.First().Append("Lugar").Bold();
            t.Rows[0].Cells[4].Paragraphs.First().Append("Edad").Bold();
            t.Rows[0].Cells[5].Paragraphs.First().Append("Sexo").Bold();
            t.Rows[0].Cells[6].Paragraphs.First().Append("Causas").Bold();
            t.Rows[0].Cells[7].Paragraphs.First().Append("Vivo").Bold();
            t.Rows[0].Cells[8].Paragraphs.First().Append("Fallecido").Bold();

            //elementos de la tabla 
            int filas = 1;
            foreach (DataGridEnfermedadComunDatos elemento in elementosInforme)
            {
                t.Rows[filas].Cells[0].Paragraphs.First().Append(elemento.Fecha);
                t.Rows[filas].Cells[1].Paragraphs.First().Append(elemento.Hora);
                t.Rows[filas].Cells[2].Paragraphs.First().Append(elemento.Cantidad);
                t.Rows[filas].Cells[3].Paragraphs.First().Append(elemento.Lugar);
                t.Rows[filas].Cells[4].Paragraphs.First().Append(elemento.Edad);
                t.Rows[filas].Cells[5].Paragraphs.First().Append(elemento.sexo);
                t.Rows[filas].Cells[6].Paragraphs.First().Append(elemento.Causa);
                t.Rows[filas].Cells[7].Paragraphs.First().Append(elemento.Vivo);
                t.Rows[filas].Cells[8].Paragraphs.First().Append(elemento.Fallecido);
                filas++;
            }
            doc.InsertTable(t);
            doc.InsertParagraph(Environment.NewLine + Environment.NewLine);

            Table tf = doc.AddTable(3, 2);
            tf.Alignment = Alignment.center;
            tf.Rows[0].Cells[0].Paragraphs.First().Append("f." + "__________:___");
            tf.Rows[1].Cells[0].Paragraphs.First().Append(director.NombreCompleto);
            tf.Rows[2].Cells[0].Paragraphs.First().Append("Director");

            tf.Rows[0].Cells[1].Paragraphs.First().Append("f." + "______________");
            tf.Rows[1].Cells[1].Paragraphs.First().Append(secretario.NombreCompleto);
            tf.Rows[2].Cells[1].Paragraphs.First().Append("Secretario");
            doc.InsertTable(tf);

            doc.Save();
            Process.Start("WINWORD.EXE", @ubicacion);
        }
        public void crearWordMaternidad(string evento, DateTime fechaInicio, DateTime fechaFinal, List<DataGridMaternidadDatos> elementosInforme, BomberoInforme director, BomberoInforme secretario, string ubicacion)
        {
            //abrir el documento
            var doc = DocX.Create(@ubicacion);
            doc.PageLayout.Orientation = Orientation.Landscape;

            //crear el titulo
            string title = "Benemerito Comite de Bomberos Voluntarios" + Environment.NewLine +
                "19a. Compañia de Bomberos Voluntarios" + Environment.NewLine +
                "Estadisticas de " + evento + Environment.NewLine +
                "Correspondiente del " + fechaInicio.ToShortDateString() + " al " + fechaFinal.ToShortDateString();
            Paragraph paragraphTitle = doc.InsertParagraph(title, false, titleFormat);
            paragraphTitle.Alignment = Alignment.center;

            doc.InsertParagraph(Environment.NewLine + Environment.NewLine);

            ///crear Tabla 
            ///
            Table t = doc.AddTable(elementosInforme.Count + 1, 10);
            t.Alignment = Alignment.center;
            t.Design = TableDesign.ColorfulGrid;
            //titulo de las tablas 
            t.Rows[0].Cells[0].Paragraphs.First().Append("Fecha").Bold();
            t.Rows[0].Cells[1].Paragraphs.First().Append("Hora").Bold();
            t.Rows[0].Cells[2].Paragraphs.First().Append("Cantidad").Bold();
            t.Rows[0].Cells[3].Paragraphs.First().Append("Lugar").Bold();
            t.Rows[0].Cells[4].Paragraphs.First().Append("Edad").Bold();
            t.Rows[0].Cells[5].Paragraphs.First().Append("Aborto").Bold();
            t.Rows[0].Cells[6].Paragraphs.First().Append("Atención de Parto").Bold();
            t.Rows[0].Cells[7].Paragraphs.First().Append("Traslado a:").Bold();
            t.Rows[0].Cells[8].Paragraphs.First().Append("Vivo").Bold();
            t.Rows[0].Cells[9].Paragraphs.First().Append("Fallecido").Bold();

            //elementos de la tabla 
            int filas = 1;
            foreach (DataGridMaternidadDatos elemento in elementosInforme)
            {
                t.Rows[filas].Cells[0].Paragraphs.First().Append(elemento.fecha);
                t.Rows[filas].Cells[1].Paragraphs.First().Append(elemento.hora);
                t.Rows[filas].Cells[2].Paragraphs.First().Append(elemento.cantidad);
                t.Rows[filas].Cells[3].Paragraphs.First().Append(elemento.lugar);
                t.Rows[filas].Cells[4].Paragraphs.First().Append(elemento.edad);
                t.Rows[filas].Cells[5].Paragraphs.First().Append(elemento.aborto);
                t.Rows[filas].Cells[6].Paragraphs.First().Append(elemento.parto);
                t.Rows[filas].Cells[7].Paragraphs.First().Append(elemento.lugarTraslado);
                t.Rows[filas].Cells[8].Paragraphs.First().Append(elemento.vivo);
                t.Rows[filas].Cells[9].Paragraphs.First().Append(elemento.fallecido);
                filas++;
            }
            doc.InsertTable(t);
            doc.InsertParagraph(Environment.NewLine + Environment.NewLine);

            Table tf = doc.AddTable(3, 2);
            tf.Alignment = Alignment.center;
            tf.Rows[0].Cells[0].Paragraphs.First().Append("f." + "__________:___");
            tf.Rows[1].Cells[0].Paragraphs.First().Append(director.NombreCompleto);
            tf.Rows[2].Cells[0].Paragraphs.First().Append("Director");

            tf.Rows[0].Cells[1].Paragraphs.First().Append("f." + "______________");
            tf.Rows[1].Cells[1].Paragraphs.First().Append(secretario.NombreCompleto);
            tf.Rows[2].Cells[1].Paragraphs.First().Append("Secretario");
            doc.InsertTable(tf);

            doc.Save();
            Process.Start("WINWORD.EXE", @ubicacion);
        }
        public void crearWordAtropellado(string evento, DateTime fechaInicio, DateTime fechaFinal, List<DataGridAtropelladosDatos> elementosInforme, BomberoInforme director, BomberoInforme secretario, String ubicacion)
        {
            //abrir el documento
            var doc = DocX.Create(@ubicacion);
            doc.PageLayout.Orientation = Orientation.Landscape;

            //crear el titulo
            string title = "Benemerito Comite de Bomberos Voluntarios" + Environment.NewLine +
                "19a. Compañia de Bomberos Voluntarios" + Environment.NewLine +
                "Estadisticas de " + evento + Environment.NewLine +
                "Correspondiente del " + fechaInicio.ToShortDateString() + " al " + fechaFinal.ToShortDateString();
            Paragraph paragraphTitle = doc.InsertParagraph(title, false, titleFormat);
            paragraphTitle.Alignment = Alignment.center;

            doc.InsertParagraph(Environment.NewLine + Environment.NewLine);

            ///crear Tabla 
            ///
            Table t = doc.AddTable(elementosInforme.Count + 1, 9);
            t.Alignment = Alignment.center;
            t.Design = TableDesign.ColorfulGrid;
            //titulo de las tablas 
            t.Rows[0].Cells[0].Paragraphs.First().Append("Fecha").Bold();
            t.Rows[0].Cells[1].Paragraphs.First().Append("Hora").Bold();
            t.Rows[0].Cells[2].Paragraphs.First().Append("Cantidad").Bold();
            t.Rows[0].Cells[3].Paragraphs.First().Append("Lugar").Bold();
            t.Rows[0].Cells[4].Paragraphs.First().Append("Tipo Vehiculo").Bold();
            t.Rows[0].Cells[5].Paragraphs.First().Append("Edad").Bold();
            t.Rows[0].Cells[6].Paragraphs.First().Append("Sexo").Bold();
            t.Rows[0].Cells[7].Paragraphs.First().Append("Vivo").Bold();
            t.Rows[0].Cells[8].Paragraphs.First().Append("Fallecido").Bold();

            //elementos de la tabla 
            int filas = 1;
            foreach (DataGridAtropelladosDatos elemento in elementosInforme)
            {
                t.Rows[filas].Cells[0].Paragraphs.First().Append(elemento.fecha);
                t.Rows[filas].Cells[1].Paragraphs.First().Append(elemento.hora);
                t.Rows[filas].Cells[2].Paragraphs.First().Append(elemento.cantidad);
                t.Rows[filas].Cells[3].Paragraphs.First().Append(elemento.lugar);
                t.Rows[filas].Cells[4].Paragraphs.First().Append(elemento.tipoVehiculo);
                t.Rows[filas].Cells[5].Paragraphs.First().Append(elemento.edad);
                t.Rows[filas].Cells[6].Paragraphs.First().Append(elemento.sexo);
                t.Rows[filas].Cells[7].Paragraphs.First().Append(elemento.vivo);
                t.Rows[filas].Cells[8].Paragraphs.First().Append(elemento.fallecido);
                filas++;
            }
            doc.InsertTable(t);
            doc.InsertParagraph(Environment.NewLine + Environment.NewLine);

            Table tf = doc.AddTable(3, 2);
            tf.Alignment = Alignment.center;
            tf.Rows[0].Cells[0].Paragraphs.First().Append("f." + "__________:___");
            tf.Rows[1].Cells[0].Paragraphs.First().Append(director.NombreCompleto);
            tf.Rows[2].Cells[0].Paragraphs.First().Append("Director");

            tf.Rows[0].Cells[1].Paragraphs.First().Append("f." + "______________");
            tf.Rows[1].Cells[1].Paragraphs.First().Append(secretario.NombreCompleto);
            tf.Rows[2].Cells[1].Paragraphs.First().Append("Secretario");
            doc.InsertTable(tf);

            doc.Save();
            Process.Start("WINWORD.EXE", @ubicacion);
        }

        public void crearPdfServiciosDeAgua(string evento, DateTime fechaInicio, DateTime fechaFinal, List<DataGridServiciosDeAguaDatos> elementosInforme, BomberoInforme director, BomberoInforme secretario, String ubicacion)
        {
            //abrir el documento
            var doc = DocX.Create(@ubicacion);
            doc.PageLayout.Orientation = Orientation.Landscape;

            //crear el titulo
            string title = "Benemerito Comite de Bomberos Voluntarios" + Environment.NewLine +
                "19a. Compañia de Bomberos Voluntarios" + Environment.NewLine +
                "Estadisticas de " + evento + Environment.NewLine +
                "Correspondiente del " + fechaInicio.ToShortDateString() + " al " + fechaFinal.ToShortDateString();
            Paragraph paragraphTitle = doc.InsertParagraph(title, false, titleFormat);
            paragraphTitle.Alignment = Alignment.center;

            doc.InsertParagraph(Environment.NewLine + Environment.NewLine);

            ///crear Tabla 
            ///
            Table t = doc.AddTable(elementosInforme.Count + 1, 6);
            t.Alignment = Alignment.center;
            t.Design = TableDesign.ColorfulGrid;
            //titulo de las tablas 
            t.Rows[0].Cells[0].Paragraphs.First().Append("Fecha").Bold();
            t.Rows[0].Cells[1].Paragraphs.First().Append("Hora").Bold();
            t.Rows[0].Cells[2].Paragraphs.First().Append("Cantidad").Bold();
            t.Rows[0].Cells[3].Paragraphs.First().Append("Lugar").Bold();
            t.Rows[0].Cells[4].Paragraphs.First().Append("nombre").Bold();
            t.Rows[0].Cells[5].Paragraphs.First().Append("Galones").Bold();

            //elementos de la tabla 
            int filas = 1;
            foreach (DataGridServiciosDeAguaDatos elemento in elementosInforme)
            {
                t.Rows[filas].Cells[0].Paragraphs.First().Append(elemento.fecha);
                t.Rows[filas].Cells[1].Paragraphs.First().Append(elemento.hora);
                t.Rows[filas].Cells[2].Paragraphs.First().Append(elemento.cantidad);
                t.Rows[filas].Cells[3].Paragraphs.First().Append(elemento.lugar);
                t.Rows[filas].Cells[4].Paragraphs.First().Append(elemento.nombre);
                t.Rows[filas].Cells[5].Paragraphs.First().Append(elemento.galones);
                filas++;
            }
            doc.InsertTable(t);
            doc.InsertParagraph(Environment.NewLine + Environment.NewLine);

            Table tf = doc.AddTable(3, 2);
            tf.Alignment = Alignment.center;
            tf.Rows[0].Cells[0].Paragraphs.First().Append("f." + "__________:___");
            tf.Rows[1].Cells[0].Paragraphs.First().Append(director.NombreCompleto);
            tf.Rows[2].Cells[0].Paragraphs.First().Append("Director");

            tf.Rows[0].Cells[1].Paragraphs.First().Append("f." + "______________");
            tf.Rows[1].Cells[1].Paragraphs.First().Append(secretario.NombreCompleto);
            tf.Rows[2].Cells[1].Paragraphs.First().Append("Secretario");
            doc.InsertTable(tf);

            doc.Save();
            Process.Start("WINWORD.EXE", @ubicacion);
        }
        public void crearWordSuicidios(string evento, DateTime fechaInicio, DateTime fechaFinal, List<DataGridFallecimientoDatos> elementosInforme, BomberoInforme director, BomberoInforme secretario, String ubicacion)
        {
            //abrir el documento
            var doc = DocX.Create(@ubicacion);
            doc.PageLayout.Orientation = Orientation.Landscape;

            //crear el titulo
            string title = "Benemerito Comite de Bomberos Voluntarios" + Environment.NewLine +
                "19a. Compañia de Bomberos Voluntarios" + Environment.NewLine +
                "Estadisticas de " + evento + Environment.NewLine +
                "Correspondiente del " + fechaInicio.ToShortDateString() + " al " + fechaFinal.ToShortDateString();
            Paragraph paragraphTitle = doc.InsertParagraph(title, false, titleFormat);
            paragraphTitle.Alignment = Alignment.center;

            doc.InsertParagraph(Environment.NewLine + Environment.NewLine);

            ///crear Tabla 
            ///
            Table t = doc.AddTable(elementosInforme.Count + 1, 8);
            t.Alignment = Alignment.center;
            t.Design = TableDesign.ColorfulGrid;
            //titulo de las tablas 
            t.Rows[0].Cells[0].Paragraphs.First().Append("Fecha").Bold();
            t.Rows[0].Cells[1].Paragraphs.First().Append("Hora").Bold();
            t.Rows[0].Cells[2].Paragraphs.First().Append("Cantidad").Bold();
            t.Rows[0].Cells[3].Paragraphs.First().Append("Lugar").Bold();
            t.Rows[0].Cells[4].Paragraphs.First().Append("Nombre").Bold();
            t.Rows[0].Cells[5].Paragraphs.First().Append("Causa").Bold();
            t.Rows[0].Cells[6].Paragraphs.First().Append("Edad").Bold();
            t.Rows[0].Cells[7].Paragraphs.First().Append("Sexo").Bold();

            //elementos de la tabla 
            int filas = 1;
            foreach (DataGridFallecimientoDatos elemento in elementosInforme)
            {
                t.Rows[filas].Cells[0].Paragraphs.First().Append(elemento.fecha);
                t.Rows[filas].Cells[1].Paragraphs.First().Append(elemento.hora);
                t.Rows[filas].Cells[2].Paragraphs.First().Append(elemento.cantidad);
                t.Rows[filas].Cells[3].Paragraphs.First().Append(elemento.lugar);
                t.Rows[filas].Cells[4].Paragraphs.First().Append(elemento.nombre);
                t.Rows[filas].Cells[5].Paragraphs.First().Append(elemento.causa);
                t.Rows[filas].Cells[6].Paragraphs.First().Append(elemento.edad);
                t.Rows[filas].Cells[7].Paragraphs.First().Append(elemento.sexo);
                filas++;
            }
            doc.InsertTable(t);
            doc.InsertParagraph(Environment.NewLine + Environment.NewLine);

            Table tf = doc.AddTable(3, 2);
            tf.Alignment = Alignment.center;
            tf.Rows[0].Cells[0].Paragraphs.First().Append("f." + "__________:___");
            tf.Rows[1].Cells[0].Paragraphs.First().Append(director.NombreCompleto);
            tf.Rows[2].Cells[0].Paragraphs.First().Append("Director");

            tf.Rows[0].Cells[1].Paragraphs.First().Append("f." + "______________");
            tf.Rows[1].Cells[1].Paragraphs.First().Append(secretario.NombreCompleto);
            tf.Rows[2].Cells[1].Paragraphs.First().Append("Secretario");
            doc.InsertTable(tf);

            doc.Save();
            Process.Start("WINWORD.EXE", @ubicacion);

        }
    }
}
