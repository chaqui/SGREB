using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using iTextSharp;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.Threading.Tasks;
using System.IO;
using SGREB.miscellany;

namespace SGREB.Controlador
{
    class PDFCreador
    {

        public void crearPDFcomun(string evento, DateTime fechaInicio, DateTime fechaFinal, List<DataGridComunDatos> elementosInforme, BomberoInforme director, BomberoInforme secretario, String ubicacion)
        {
            int centrado = iTextSharp.text.Image.ALIGN_CENTER;
            //creacion del documento
            Document doc = new Document();

            PdfWriter writer = PdfWriter.GetInstance(doc, new FileStream(@ubicacion, FileMode.Create));
            doc.AddTitle("Informe");
            doc.SetPageSize(iTextSharp.text.PageSize.LETTER.Rotate());
            doc.Open();
            iTextSharp.text.Font _contenidoTabla = new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 8, iTextSharp.text.Font.NORMAL, BaseColor.BLACK);
            iTextSharp.text.Font _titulo = new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 12, iTextSharp.text.Font.BOLD, BaseColor.BLACK);
            iTextSharp.text.Font _tituloTabla = new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 10, iTextSharp.text.Font.BOLD, BaseColor.BLACK);

            //titulo 
            Paragraph parafo1 = new Paragraph("Benemerito Comite de Bomberos Voluntarios", _titulo);
            parafo1.Alignment = centrado;
            doc.Add(parafo1);
            Paragraph parafo2 = new Paragraph("19a. Compañia de Bomberos Voluntarios", _titulo);
            parafo2.Alignment = centrado;
            doc.Add(parafo2);
            Paragraph parafo3 = new Paragraph("Estadisticas de " + evento + " Mensuales ", _titulo);
            parafo3.Alignment = centrado;
            doc.Add(parafo3);
            Paragraph parafo4 = new Paragraph("Correspondiente del " + fechaInicio.ToShortDateString() + " al " + fechaFinal.ToShortDateString(), _titulo);
            parafo4.Alignment = centrado;
            doc.Add(parafo4);
            doc.Add(Chunk.NEWLINE);



            //tabla de informe 
            PdfPTable tblIncidente = new PdfPTable(8);
            tblIncidente.WidthPercentage = 100;

            //celdas
            //Titulo de las Celdas
            PdfPCell clFecha = new PdfPCell(new Phrase("Fecha", _tituloTabla));
            clFecha.HorizontalAlignment = centrado;
            tblIncidente.AddCell(clFecha);
            PdfPCell clHora = new PdfPCell(new Phrase("Hora", _tituloTabla));
            clHora.HorizontalAlignment = centrado;
            tblIncidente.AddCell(clHora);
            PdfPCell clCantidad = new PdfPCell(new Phrase("Cantidad", _tituloTabla));
            clCantidad.HorizontalAlignment = centrado;
            tblIncidente.AddCell(clCantidad);
            PdfPCell clLugar = new PdfPCell(new Phrase("Lugar", _tituloTabla));
            clLugar.HorizontalAlignment = centrado;
            tblIncidente.AddCell(clLugar);
            PdfPCell clEdad = new PdfPCell(new Phrase("Edad", _tituloTabla));
            clEdad.HorizontalAlignment = centrado;
            tblIncidente.AddCell(clEdad);
            PdfPCell clSexo = new PdfPCell(new Phrase("Sexo", _tituloTabla));
            clSexo.HorizontalAlignment = centrado;
            tblIncidente.AddCell(clSexo);
            PdfPCell clVivo = new PdfPCell(new Phrase("Vivo", _tituloTabla));
            clVivo.HorizontalAlignment = centrado;
            tblIncidente.AddCell(clVivo);
            PdfPCell clFallecido = new PdfPCell(new Phrase("Fallecido", _tituloTabla));
            clFallecido.HorizontalAlignment = centrado;
            tblIncidente.AddCell(clFallecido);

            foreach (DataGridComunDatos elemento in elementosInforme)
            {
                clFecha = new PdfPCell(new Phrase(elemento.Fecha, _contenidoTabla));
                clFecha.HorizontalAlignment = centrado;
                tblIncidente.AddCell(clFecha);
                clHora = new PdfPCell(new Phrase(elemento.Hora, _contenidoTabla));
                clHora.HorizontalAlignment = centrado;
                tblIncidente.AddCell(clHora);
                clCantidad = new PdfPCell(new Phrase(elemento.Cantidad, _contenidoTabla));
                clCantidad.HorizontalAlignment = centrado;
                tblIncidente.AddCell(clCantidad);
                clLugar = new PdfPCell(new Phrase(elemento.Lugar, _contenidoTabla));
                clLugar.HorizontalAlignment = centrado;
                tblIncidente.AddCell(clLugar);
                clEdad = new PdfPCell(new Phrase(elemento.sexo, _contenidoTabla));
                clEdad.HorizontalAlignment = centrado;
                tblIncidente.AddCell(clEdad);
                clSexo = new PdfPCell(new Phrase(elemento.Edad, _contenidoTabla));
                clSexo.HorizontalAlignment = centrado;
                tblIncidente.AddCell(clSexo);
                clVivo = new PdfPCell(new Phrase(elemento.Vivo, _contenidoTabla));
                clVivo.HorizontalAlignment = centrado;
                tblIncidente.AddCell(clVivo);
                clFallecido = new PdfPCell(new Phrase(elemento.Fallecido, _contenidoTabla));
                clFallecido.HorizontalAlignment = centrado;
                tblIncidente.AddCell(clFallecido);
            }

            doc.Add(tblIncidente);

            doc.Add(Chunk.NEWLINE);

            //Firmas
            PdfPTable tblFirmas = new PdfPTable(2);
            tblIncidente.WidthPercentage = 100;
            PdfPCell clDirecto = new PdfPCell(new Phrase(director.NombreCompleto, _tituloTabla));
            clDirecto.HorizontalAlignment = centrado;
            clDirecto.Border = 0;
            tblFirmas.AddCell(clDirecto);
            PdfPCell clSecretario = new PdfPCell(new Phrase(secretario.NombreCompleto, _tituloTabla));
            clSecretario.HorizontalAlignment = centrado;
            clSecretario.Border = 0;
            tblFirmas.AddCell(clSecretario);
            clDirecto = new PdfPCell(new Phrase("Directo", _tituloTabla));
            clDirecto.HorizontalAlignment = centrado;
            clDirecto.Border = 0;
            tblFirmas.AddCell(clDirecto);
            clSecretario = new PdfPCell(new Phrase("Secretario", _tituloTabla));
            clSecretario.HorizontalAlignment = centrado;
            clSecretario.Border = 0;
            tblFirmas.AddCell(clSecretario);
            //cerrar pdf 
            doc.Add(tblFirmas);
            doc.Close();
            writer.Close();

        }

        public void crearPDFIncendio(string evento, DateTime fechaInicio, DateTime fechaFinal, List<DataGridIncendiosDatos> elementosInforme, BomberoInforme director, BomberoInforme secretario, String ubicacion)
        {
            int centrado = iTextSharp.text.Image.ALIGN_CENTER;
            //creacion del documento
            Document doc = new Document();

            PdfWriter writer = PdfWriter.GetInstance(doc, new FileStream(@ubicacion, FileMode.Create));
            doc.AddTitle("Informe");
            doc.SetPageSize(iTextSharp.text.PageSize.LETTER.Rotate());
            doc.Open();
            iTextSharp.text.Font _contenidoTabla = new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 8, iTextSharp.text.Font.NORMAL, BaseColor.BLACK);
            iTextSharp.text.Font _titulo = new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 12, iTextSharp.text.Font.BOLD, BaseColor.BLACK);
            iTextSharp.text.Font _tituloTabla = new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 10, iTextSharp.text.Font.BOLD, BaseColor.BLACK);

            //titulo 
            Paragraph parafo1 = new Paragraph("Benemerito Comite de Bomberos Voluntarios", _titulo);
            parafo1.Alignment = centrado;
            doc.Add(parafo1);
            Paragraph parafo2 = new Paragraph("19a. Compañia de Bomberos Voluntarios", _titulo);
            parafo2.Alignment = centrado;
            doc.Add(parafo2);
            Paragraph parafo3 = new Paragraph("Estadisticas de " + evento + " Mensuales ", _titulo);
            parafo3.Alignment = centrado;
            doc.Add(parafo3);
            Paragraph parafo4 = new Paragraph("Correspondiente del " + fechaInicio.ToShortDateString() + " al " + fechaFinal.ToShortDateString(), _titulo);
            parafo4.Alignment = centrado;
            doc.Add(parafo4);
            doc.Add(Chunk.NEWLINE);



            //tabla de informe 
            PdfPTable tblIncidente = new PdfPTable(9);
            tblIncidente.WidthPercentage = 100;

            //celdas
            //Titulo de las Celdas
            PdfPCell clFecha = new PdfPCell(new Phrase("Fecha", _tituloTabla));
            clFecha.HorizontalAlignment = centrado;
            tblIncidente.AddCell(clFecha);
            PdfPCell clHora = new PdfPCell(new Phrase("Hora", _tituloTabla));
            clHora.HorizontalAlignment = centrado;
            tblIncidente.AddCell(clHora);
            PdfPCell clCantidad = new PdfPCell(new Phrase("Cantidad", _tituloTabla));
            clCantidad.HorizontalAlignment = centrado;
            tblIncidente.AddCell(clCantidad);
            PdfPCell clLugar = new PdfPCell(new Phrase("Lugar", _tituloTabla));
            clLugar.HorizontalAlignment = centrado;
            tblIncidente.AddCell(clLugar);
            PdfPCell clNombre = new PdfPCell(new Phrase("propietario", _tituloTabla));
            clNombre.HorizontalAlignment = centrado;
            tblIncidente.AddCell(clNombre);
            PdfPCell clEdad = new PdfPCell(new Phrase("perdidas", _tituloTabla));
            clEdad.HorizontalAlignment = centrado;
            tblIncidente.AddCell(clEdad);
            PdfPCell clSexo = new PdfPCell(new Phrase("Agua Utilizada", _tituloTabla));
            clSexo.HorizontalAlignment = centrado;
            tblIncidente.AddCell(clSexo);
            PdfPCell clVivo = new PdfPCell(new Phrase("Fallecidos", _tituloTabla));
            clVivo.HorizontalAlignment = centrado;
            tblIncidente.AddCell(clVivo);
            PdfPCell clFallecido = new PdfPCell(new Phrase("Vivos", _tituloTabla));
            clFallecido.HorizontalAlignment = centrado;
            tblIncidente.AddCell(clFallecido);

            foreach (DataGridIncendiosDatos elemento in elementosInforme)
            {
                clFecha = new PdfPCell(new Phrase(elemento.Fecha, _contenidoTabla));
                clFecha.HorizontalAlignment = centrado;
                tblIncidente.AddCell(clFecha);
                clHora = new PdfPCell(new Phrase(elemento.Hora, _contenidoTabla));
                clHora.HorizontalAlignment = centrado;
                tblIncidente.AddCell(clHora);
                clCantidad = new PdfPCell(new Phrase(elemento.Cantidad, _contenidoTabla));
                clCantidad.HorizontalAlignment = centrado;
                tblIncidente.AddCell(clCantidad);
                clLugar = new PdfPCell(new Phrase(elemento.Lugar, _contenidoTabla));
                clLugar.HorizontalAlignment = centrado;
                tblIncidente.AddCell(clLugar);
                clNombre = new PdfPCell(new Phrase(elemento.propietario, _contenidoTabla));
                clNombre.HorizontalAlignment = centrado;
                tblIncidente.AddCell(clNombre);
                clEdad = new PdfPCell(new Phrase(elemento.perdidas, _contenidoTabla));
                clEdad.HorizontalAlignment = centrado;
                tblIncidente.AddCell(clEdad);
                clSexo = new PdfPCell(new Phrase(elemento.aguaUtilizada, _contenidoTabla));
                clSexo.HorizontalAlignment = centrado;
                tblIncidente.AddCell(clSexo);
                clVivo = new PdfPCell(new Phrase(elemento.Fallecidos, _contenidoTabla));
                clVivo.HorizontalAlignment = centrado;
                tblIncidente.AddCell(clVivo);
                clFallecido = new PdfPCell(new Phrase(elemento.Vivos, _contenidoTabla));
                clFallecido.HorizontalAlignment = centrado;
                tblIncidente.AddCell(clFallecido);

            }

            doc.Add(tblIncidente);

            doc.Add(Chunk.NEWLINE);

            //Firmas
            PdfPTable tblFirmas = new PdfPTable(2);
            tblIncidente.WidthPercentage = 100;
            PdfPCell clDirecto = new PdfPCell(new Phrase(director.NombreCompleto, _tituloTabla));
            clDirecto.HorizontalAlignment = centrado;
            clDirecto.Border = 0;
            tblFirmas.AddCell(clDirecto);
            PdfPCell clSecretario = new PdfPCell(new Phrase(secretario.NombreCompleto, _tituloTabla));
            clSecretario.HorizontalAlignment = centrado;
            clSecretario.Border = 0;
            tblFirmas.AddCell(clSecretario);
            clDirecto = new PdfPCell(new Phrase("Directo", _tituloTabla));
            clDirecto.HorizontalAlignment = centrado;
            clDirecto.Border = 0;
            tblFirmas.AddCell(clDirecto);
            clSecretario = new PdfPCell(new Phrase("Secretario", _tituloTabla));
            clSecretario.HorizontalAlignment = centrado;
            clSecretario.Border = 0;
            tblFirmas.AddCell(clSecretario);
            //cerrar pdf 
            doc.Add(tblFirmas);
            doc.Close();
            writer.Close();

        }

        internal void crearPDFEComun(string evento, DateTime fechaInicio, DateTime fechaFinal, List<DataGridEnfermedadComunDatos> elementosInforme, BomberoInforme director, BomberoInforme secretario, string ubicacion)
        {
            int centrado = iTextSharp.text.Image.ALIGN_CENTER;
            //creacion del documento
            Document doc = new Document();

            PdfWriter writer = PdfWriter.GetInstance(doc, new FileStream(@ubicacion, FileMode.Create));
            doc.AddTitle("Informe");
            doc.SetPageSize(iTextSharp.text.PageSize.LETTER.Rotate());
            doc.Open();
            iTextSharp.text.Font _contenidoTabla = new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 8, iTextSharp.text.Font.NORMAL, BaseColor.BLACK);
            iTextSharp.text.Font _titulo = new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 12, iTextSharp.text.Font.BOLD, BaseColor.BLACK);
            iTextSharp.text.Font _tituloTabla = new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 10, iTextSharp.text.Font.BOLD, BaseColor.BLACK);

            //titulo 
            Paragraph parafo1 = new Paragraph("Benemerito Comite de Bomberos Voluntarios", _titulo);
            parafo1.Alignment = centrado;
            doc.Add(parafo1);
            Paragraph parafo2 = new Paragraph("19a. Compañia de Bomberos Voluntarios", _titulo);
            parafo2.Alignment = centrado;
            doc.Add(parafo2);
            Paragraph parafo3 = new Paragraph("Estadisticas de " + evento + " Mensuales ", _titulo);
            parafo3.Alignment = centrado;
            doc.Add(parafo3);
            Paragraph parafo4 = new Paragraph("Correspondiente del " + fechaInicio.ToShortDateString() + " al " + fechaFinal.ToShortDateString(), _titulo);
            parafo4.Alignment = centrado;
            doc.Add(parafo4);
            doc.Add(Chunk.NEWLINE);



            //tabla de informe 
            PdfPTable tblIncidente = new PdfPTable(9);
            tblIncidente.WidthPercentage = 100;

            //celdas
            //Titulo de las Celdas
            PdfPCell clFecha = new PdfPCell(new Phrase("Fecha", _tituloTabla));
            clFecha.HorizontalAlignment = centrado;
            tblIncidente.AddCell(clFecha);
            PdfPCell clHora = new PdfPCell(new Phrase("Hora", _tituloTabla));
            clHora.HorizontalAlignment = centrado;
            tblIncidente.AddCell(clHora);
            PdfPCell clCantidad = new PdfPCell(new Phrase("Cantidad", _tituloTabla));
            clCantidad.HorizontalAlignment = centrado;
            tblIncidente.AddCell(clCantidad);
            PdfPCell clLugar = new PdfPCell(new Phrase("Lugar", _tituloTabla));
            clLugar.HorizontalAlignment = centrado;
            tblIncidente.AddCell(clLugar);
            PdfPCell clEdad = new PdfPCell(new Phrase("Edad", _tituloTabla));
            clEdad.HorizontalAlignment = centrado;
            tblIncidente.AddCell(clEdad);
            PdfPCell clSexo = new PdfPCell(new Phrase("Sexo", _tituloTabla));
            clSexo.HorizontalAlignment = centrado;
            tblIncidente.AddCell(clSexo);
            PdfPCell clCausa = new PdfPCell(new Phrase("Causas", _tituloTabla));
            clCausa.HorizontalAlignment = centrado;
            tblIncidente.AddCell(clCausa);
            PdfPCell clVivo = new PdfPCell(new Phrase("Vivo", _tituloTabla));
            clVivo.HorizontalAlignment = centrado;
            tblIncidente.AddCell(clVivo);
            PdfPCell clFallecido = new PdfPCell(new Phrase("Fallecido", _tituloTabla));
            clFallecido.HorizontalAlignment = centrado;
            tblIncidente.AddCell(clFallecido);

            foreach (DataGridEnfermedadComunDatos elemento in elementosInforme)
            {
                clFecha = new PdfPCell(new Phrase(elemento.Fecha, _contenidoTabla));
                clFecha.HorizontalAlignment = centrado;
                tblIncidente.AddCell(clFecha);
                clHora = new PdfPCell(new Phrase(elemento.Hora, _contenidoTabla));
                clHora.HorizontalAlignment = centrado;
                tblIncidente.AddCell(clHora);
                clCantidad = new PdfPCell(new Phrase(elemento.Cantidad, _contenidoTabla));
                clCantidad.HorizontalAlignment = centrado;
                tblIncidente.AddCell(clCantidad);
                clLugar = new PdfPCell(new Phrase(elemento.Lugar, _contenidoTabla));
                clLugar.HorizontalAlignment = centrado;
                tblIncidente.AddCell(clLugar);
                clEdad = new PdfPCell(new Phrase(elemento.sexo, _contenidoTabla));
                clEdad.HorizontalAlignment = centrado;
                tblIncidente.AddCell(clEdad);
                clCausa = new PdfPCell(new Phrase(elemento.Causa, _contenidoTabla));
                clCausa.HorizontalAlignment = centrado;
                tblIncidente.AddCell(clCausa);
                clSexo = new PdfPCell(new Phrase(elemento.Edad, _contenidoTabla));
                clSexo.HorizontalAlignment = centrado;
                tblIncidente.AddCell(clSexo);
                clVivo = new PdfPCell(new Phrase(elemento.Vivo, _contenidoTabla));
                clVivo.HorizontalAlignment = centrado;
                tblIncidente.AddCell(clVivo);
                clFallecido = new PdfPCell(new Phrase(elemento.Fallecido, _contenidoTabla));
                clFallecido.HorizontalAlignment = centrado;
                tblIncidente.AddCell(clFallecido);
            }

            doc.Add(tblIncidente);

            doc.Add(Chunk.NEWLINE);

            //Firmas
            PdfPTable tblFirmas = new PdfPTable(2);
            tblIncidente.WidthPercentage = 100;
            PdfPCell clDirecto = new PdfPCell(new Phrase(director.NombreCompleto, _tituloTabla));
            clDirecto.HorizontalAlignment = centrado;
            clDirecto.Border = 0;
            tblFirmas.AddCell(clDirecto);
            PdfPCell clSecretario = new PdfPCell(new Phrase(secretario.NombreCompleto, _tituloTabla));
            clSecretario.HorizontalAlignment = centrado;
            clSecretario.Border = 0;
            tblFirmas.AddCell(clSecretario);
            clDirecto = new PdfPCell(new Phrase("Directo", _tituloTabla));
            clDirecto.HorizontalAlignment = centrado;
            clDirecto.Border = 0;
            tblFirmas.AddCell(clDirecto);
            clSecretario = new PdfPCell(new Phrase("Secretario", _tituloTabla));
            clSecretario.HorizontalAlignment = centrado;
            clSecretario.Border = 0;
            tblFirmas.AddCell(clSecretario);
            //cerrar pdf 
            doc.Add(tblFirmas);
            doc.Close();
            writer.Close();
        }

        public void crearPDFAtropellado(string evento, DateTime fechaInicio, DateTime fechaFinal, List<DataGridAtropelladosDatos> elementosInforme, BomberoInforme director, BomberoInforme secretario, String ubicacion)
        {
            int centrado = iTextSharp.text.Image.ALIGN_CENTER;
            //creacion del documento
            Document doc = new Document();

            PdfWriter writer = PdfWriter.GetInstance(doc, new FileStream(@ubicacion, FileMode.Create));
            doc.AddTitle("Informe");
            doc.SetPageSize(iTextSharp.text.PageSize.LETTER.Rotate());
            doc.Open();
            iTextSharp.text.Font _contenidoTabla = new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 8, iTextSharp.text.Font.NORMAL, BaseColor.BLACK);
            iTextSharp.text.Font _titulo = new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 12, iTextSharp.text.Font.BOLD, BaseColor.BLACK);
            iTextSharp.text.Font _tituloTabla = new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 10, iTextSharp.text.Font.BOLD, BaseColor.BLACK);

            //titulo 
            Paragraph parafo1 = new Paragraph("Benemerito Comite de Bomberos Voluntarios", _titulo);
            parafo1.Alignment = centrado;
            doc.Add(parafo1);
            Paragraph parafo2 = new Paragraph("19a. Compañia de Bomberos Voluntarios", _titulo);
            parafo2.Alignment = centrado;
            doc.Add(parafo2);
            Paragraph parafo3 = new Paragraph("Estadisticas de " + evento + " Mensuales ", _titulo);
            parafo3.Alignment = centrado;
            doc.Add(parafo3);
            Paragraph parafo4 = new Paragraph("Correspondiente del " + fechaInicio.ToShortDateString() + " al " + fechaFinal.ToShortDateString(), _titulo);
            parafo4.Alignment = centrado;
            doc.Add(parafo4);
            doc.Add(Chunk.NEWLINE);



            //tabla de informe 
            PdfPTable tblIncidente = new PdfPTable(9);
            tblIncidente.WidthPercentage = 100;

            //celdas
            //Titulo de las Celdas
            PdfPCell clFecha = new PdfPCell(new Phrase("Fecha", _tituloTabla));
            clFecha.HorizontalAlignment = centrado;
            tblIncidente.AddCell(clFecha);
            PdfPCell clHora = new PdfPCell(new Phrase("Hora", _tituloTabla));
            clHora.HorizontalAlignment = centrado;
            tblIncidente.AddCell(clHora);
            PdfPCell clCantidad = new PdfPCell(new Phrase("Cantidad", _tituloTabla));
            clCantidad.HorizontalAlignment = centrado;
            tblIncidente.AddCell(clCantidad);
            PdfPCell clLugar = new PdfPCell(new Phrase("Lugar", _tituloTabla));
            clLugar.HorizontalAlignment = centrado;
            tblIncidente.AddCell(clLugar);
            PdfPCell clNombre = new PdfPCell(new Phrase("tipoVehiculo", _tituloTabla));
            clNombre.HorizontalAlignment = centrado;
            tblIncidente.AddCell(clNombre);
            PdfPCell clEdad = new PdfPCell(new Phrase("edad", _tituloTabla));
            clEdad.HorizontalAlignment = centrado;
            tblIncidente.AddCell(clEdad);
            PdfPCell clSexo = new PdfPCell(new Phrase("Sexo", _tituloTabla));
            clSexo.HorizontalAlignment = centrado;
            tblIncidente.AddCell(clSexo);
            PdfPCell clVivo = new PdfPCell(new Phrase("Vivo", _tituloTabla));
            clVivo.HorizontalAlignment = centrado;
            tblIncidente.AddCell(clVivo);
            PdfPCell clFallecido = new PdfPCell(new Phrase("Fallecido", _tituloTabla));
            clFallecido.HorizontalAlignment = centrado;
            tblIncidente.AddCell(clFallecido);

            foreach (DataGridAtropelladosDatos elemento in elementosInforme)
            {
                clFecha = new PdfPCell(new Phrase(elemento.fecha, _contenidoTabla));
                clFecha.HorizontalAlignment = centrado;
                tblIncidente.AddCell(clFecha);
                clHora = new PdfPCell(new Phrase(elemento.hora, _contenidoTabla));
                clHora.HorizontalAlignment = centrado;
                tblIncidente.AddCell(clHora);
                clCantidad = new PdfPCell(new Phrase(elemento.cantidad, _contenidoTabla));
                clCantidad.HorizontalAlignment = centrado;
                tblIncidente.AddCell(clCantidad);
                clLugar = new PdfPCell(new Phrase(elemento.lugar, _contenidoTabla));
                clLugar.HorizontalAlignment = centrado;
                tblIncidente.AddCell(clLugar);
                clNombre = new PdfPCell(new Phrase(elemento.tipoVehiculo, _contenidoTabla));
                clNombre.HorizontalAlignment = centrado;
                tblIncidente.AddCell(clNombre);
                clEdad = new PdfPCell(new Phrase(elemento.edad, _contenidoTabla));
                clEdad.HorizontalAlignment = centrado;
                tblIncidente.AddCell(clEdad);
                clSexo = new PdfPCell(new Phrase(elemento.sexo, _contenidoTabla));
                clSexo.HorizontalAlignment = centrado;
                tblIncidente.AddCell(clSexo);
                clVivo = new PdfPCell(new Phrase(elemento.vivo, _contenidoTabla));
                clVivo.HorizontalAlignment = centrado;
                tblIncidente.AddCell(clVivo);
                clFallecido = new PdfPCell(new Phrase(elemento.fallecido, _contenidoTabla));
                clFallecido.HorizontalAlignment = centrado;
                tblIncidente.AddCell(clFallecido);

            }

            doc.Add(tblIncidente);

            doc.Add(Chunk.NEWLINE);

            //Firmas
            PdfPTable tblFirmas = new PdfPTable(2);
            tblIncidente.WidthPercentage = 100;
            PdfPCell clDirecto = new PdfPCell(new Phrase(director.NombreCompleto, _tituloTabla));
            clDirecto.HorizontalAlignment = centrado;
            clDirecto.Border = 0;
            tblFirmas.AddCell(clDirecto);
            PdfPCell clSecretario = new PdfPCell(new Phrase(secretario.NombreCompleto, _tituloTabla));
            clSecretario.HorizontalAlignment = centrado;
            clSecretario.Border = 0;
            tblFirmas.AddCell(clSecretario);
            clDirecto = new PdfPCell(new Phrase("Directo", _tituloTabla));
            clDirecto.HorizontalAlignment = centrado;
            clDirecto.Border = 0;
            tblFirmas.AddCell(clDirecto);
            clSecretario = new PdfPCell(new Phrase("Secretario", _tituloTabla));
            clSecretario.HorizontalAlignment = centrado;
            clSecretario.Border = 0;
            tblFirmas.AddCell(clSecretario);
            //cerrar pdf 
            doc.Add(tblFirmas);
            doc.Close();
            writer.Close();

        }

        public void crearPdfServiciosDeAgua(string evento, DateTime fechaInicio, DateTime fechaFinal, List<DataGridServiciosDeAguaDatos> elementosInforme, BomberoInforme director, BomberoInforme secretario, String ubicacion)
        {
            int centrado = iTextSharp.text.Image.ALIGN_CENTER;
            //creacion del documento
            Document doc = new Document();

            PdfWriter writer = PdfWriter.GetInstance(doc, new FileStream(@ubicacion, FileMode.Create));
            doc.AddTitle("Informe");
            doc.SetPageSize(iTextSharp.text.PageSize.LETTER.Rotate());
            doc.Open();
            iTextSharp.text.Font _contenidoTabla = new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 8, iTextSharp.text.Font.NORMAL, BaseColor.BLACK);
            iTextSharp.text.Font _titulo = new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 12, iTextSharp.text.Font.BOLD, BaseColor.BLACK);
            iTextSharp.text.Font _tituloTabla = new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 10, iTextSharp.text.Font.BOLD, BaseColor.BLACK);

            //titulo 
            Paragraph parafo1 = new Paragraph("Benemerito Comite de Bomberos Voluntarios", _titulo);
            parafo1.Alignment = centrado;
            doc.Add(parafo1);
            Paragraph parafo2 = new Paragraph("19a. Compañia de Bomberos Voluntarios", _titulo);
            parafo2.Alignment = centrado;
            doc.Add(parafo2);
            Paragraph parafo3 = new Paragraph("Estadisticas de " + evento + " Mensuales ", _titulo);
            parafo3.Alignment = centrado;
            doc.Add(parafo3);
            Paragraph parafo4 = new Paragraph("Correspondiente del " + fechaInicio.ToShortDateString() + " al " + fechaFinal.ToShortDateString(), _titulo);
            parafo4.Alignment = centrado;
            doc.Add(parafo4);
            doc.Add(Chunk.NEWLINE);



            //tabla de informe 
            PdfPTable tblIncidente = new PdfPTable(6);
            tblIncidente.WidthPercentage = 100;

            //celdas
            //Titulo de las Celdas
            PdfPCell clFecha = new PdfPCell(new Phrase("Fecha", _tituloTabla));
            clFecha.HorizontalAlignment = centrado;
            tblIncidente.AddCell(clFecha);
            PdfPCell clHora = new PdfPCell(new Phrase("Hora", _tituloTabla));
            clHora.HorizontalAlignment = centrado;
            tblIncidente.AddCell(clHora);
            PdfPCell clCantidad = new PdfPCell(new Phrase("Cantidad", _tituloTabla));
            clCantidad.HorizontalAlignment = centrado;
            tblIncidente.AddCell(clCantidad);
            PdfPCell clLugar = new PdfPCell(new Phrase("Lugar", _tituloTabla));
            clLugar.HorizontalAlignment = centrado;
            tblIncidente.AddCell(clLugar);
            PdfPCell clNombre = new PdfPCell(new Phrase("nombre", _tituloTabla));
            clNombre.HorizontalAlignment = centrado;
            tblIncidente.AddCell(clNombre);
            PdfPCell clEdad = new PdfPCell(new Phrase("galones", _tituloTabla));
            clEdad.HorizontalAlignment = centrado;
            tblIncidente.AddCell(clEdad);

            foreach (DataGridServiciosDeAguaDatos elemento in elementosInforme)
            {
                clFecha = new PdfPCell(new Phrase(elemento.fecha, _contenidoTabla));
                clFecha.HorizontalAlignment = centrado;
                tblIncidente.AddCell(clFecha);
                clHora = new PdfPCell(new Phrase(elemento.hora, _contenidoTabla));
                clHora.HorizontalAlignment = centrado;
                tblIncidente.AddCell(clHora);
                clCantidad = new PdfPCell(new Phrase(elemento.cantidad, _contenidoTabla));
                clCantidad.HorizontalAlignment = centrado;
                tblIncidente.AddCell(clCantidad);
                clLugar = new PdfPCell(new Phrase(elemento.lugar, _contenidoTabla));
                clLugar.HorizontalAlignment = centrado;
                tblIncidente.AddCell(clLugar);
                clNombre = new PdfPCell(new Phrase(elemento.nombre, _contenidoTabla));
                clNombre.HorizontalAlignment = centrado;
                tblIncidente.AddCell(clNombre);
                clEdad = new PdfPCell(new Phrase(elemento.galones, _contenidoTabla));
                clEdad.HorizontalAlignment = centrado;
                tblIncidente.AddCell(clEdad);

            }

            doc.Add(tblIncidente);

            doc.Add(Chunk.NEWLINE);

            //Firmas
            PdfPTable tblFirmas = new PdfPTable(2);
            tblIncidente.WidthPercentage = 100;
            PdfPCell clDirecto = new PdfPCell(new Phrase(director.NombreCompleto, _tituloTabla));
            clDirecto.HorizontalAlignment = centrado;
            clDirecto.Border = 0;
            tblFirmas.AddCell(clDirecto);
            PdfPCell clSecretario = new PdfPCell(new Phrase(secretario.NombreCompleto, _tituloTabla));
            clSecretario.HorizontalAlignment = centrado;
            clSecretario.Border = 0;
            tblFirmas.AddCell(clSecretario);
            clDirecto = new PdfPCell(new Phrase("Directo", _tituloTabla));
            clDirecto.HorizontalAlignment = centrado;
            clDirecto.Border = 0;
            tblFirmas.AddCell(clDirecto);
            clSecretario = new PdfPCell(new Phrase("Secretario", _tituloTabla));
            clSecretario.HorizontalAlignment = centrado;
            clSecretario.Border = 0;
            tblFirmas.AddCell(clSecretario);
            //cerrar pdf 
            doc.Add(tblFirmas);
            doc.Close();
            writer.Close();

        }

        public void crearPdfSuicidios(string evento, DateTime fechaInicio, DateTime fechaFinal, List<DataGridFallecimientoDatos> elementosInforme, BomberoInforme director, BomberoInforme secretario, String ubicacion)
        {
            int centrado = iTextSharp.text.Image.ALIGN_CENTER;
            //creacion del documento
            Document doc = new Document();

            PdfWriter writer = PdfWriter.GetInstance(doc, new FileStream(@ubicacion, FileMode.Create));
            doc.AddTitle("Informe");
            doc.SetPageSize(iTextSharp.text.PageSize.LETTER.Rotate());
            doc.Open();
            iTextSharp.text.Font _contenidoTabla = new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 8, iTextSharp.text.Font.NORMAL, BaseColor.BLACK);
            iTextSharp.text.Font _titulo = new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 12, iTextSharp.text.Font.BOLD, BaseColor.BLACK);
            iTextSharp.text.Font _tituloTabla = new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 10, iTextSharp.text.Font.BOLD, BaseColor.BLACK);

            //titulo 
            Paragraph parafo1 = new Paragraph("Benemerito Comite de Bomberos Voluntarios", _titulo);
            parafo1.Alignment = centrado;
            doc.Add(parafo1);
            Paragraph parafo2 = new Paragraph("19a. Compañia de Bomberos Voluntarios", _titulo);
            parafo2.Alignment = centrado;
            doc.Add(parafo2);
            Paragraph parafo3 = new Paragraph("Estadisticas de " + evento + " Mensuales ", _titulo);
            parafo3.Alignment = centrado;
            doc.Add(parafo3);
            Paragraph parafo4 = new Paragraph("Correspondiente del " + fechaInicio.ToShortDateString() + " al " + fechaFinal.ToShortDateString(), _titulo);
            parafo4.Alignment = centrado;
            doc.Add(parafo4);
            doc.Add(Chunk.NEWLINE);



            //tabla de informe 
            PdfPTable tblIncidente = new PdfPTable(8);
            tblIncidente.WidthPercentage = 100;

            //celdas
            //Titulo de las Celdas
            PdfPCell clFecha = new PdfPCell(new Phrase("Fecha", _tituloTabla));
            clFecha.HorizontalAlignment = centrado;
            tblIncidente.AddCell(clFecha);
            PdfPCell clHora = new PdfPCell(new Phrase("Hora", _tituloTabla));
            clHora.HorizontalAlignment = centrado;
            tblIncidente.AddCell(clHora);
            PdfPCell clCantidad = new PdfPCell(new Phrase("Cantidad", _tituloTabla));
            clCantidad.HorizontalAlignment = centrado;
            tblIncidente.AddCell(clCantidad);
            PdfPCell clLugar = new PdfPCell(new Phrase("Lugar", _tituloTabla));
            clLugar.HorizontalAlignment = centrado;
            tblIncidente.AddCell(clLugar);
            PdfPCell clNombre = new PdfPCell(new Phrase("nombre", _tituloTabla));
            clNombre.HorizontalAlignment = centrado;
            tblIncidente.AddCell(clNombre);
            PdfPCell clCausa = new PdfPCell(new Phrase("Causa", _tituloTabla));
            clCausa.HorizontalAlignment = centrado;
            tblIncidente.AddCell(clCausa);
            PdfPCell clEdad = new PdfPCell(new Phrase("Edad", _tituloTabla));
            clEdad.HorizontalAlignment = centrado;
            tblIncidente.AddCell(clEdad);
            PdfPCell clSexo = new PdfPCell(new Phrase("Sexo", _tituloTabla));
            clSexo.HorizontalAlignment = centrado;
            tblIncidente.AddCell(clSexo);

            foreach (DataGridFallecimientoDatos elemento in elementosInforme)
            {
                clFecha = new PdfPCell(new Phrase(elemento.fecha, _contenidoTabla));
                clFecha.HorizontalAlignment = centrado;
                tblIncidente.AddCell(clFecha);
                clHora = new PdfPCell(new Phrase(elemento.hora, _contenidoTabla));
                clHora.HorizontalAlignment = centrado;
                tblIncidente.AddCell(clHora);
                clCantidad = new PdfPCell(new Phrase(elemento.cantidad, _contenidoTabla));
                clCantidad.HorizontalAlignment = centrado;
                tblIncidente.AddCell(clCantidad);
                clLugar = new PdfPCell(new Phrase(elemento.lugar, _contenidoTabla));
                clLugar.HorizontalAlignment = centrado;
                tblIncidente.AddCell(clLugar);
                clNombre = new PdfPCell(new Phrase(elemento.nombre, _contenidoTabla));
                clNombre.HorizontalAlignment = centrado;
                tblIncidente.AddCell(clNombre);
                clCausa = new PdfPCell(new Phrase(elemento.causa, _contenidoTabla));
                clCausa.HorizontalAlignment = centrado;
                tblIncidente.AddCell(clCausa);
                clEdad = new PdfPCell(new Phrase(elemento.edad, _contenidoTabla));
                clEdad.HorizontalAlignment = centrado;
                tblIncidente.AddCell(clEdad);
                clEdad = new PdfPCell(new Phrase(elemento.sexo, _contenidoTabla));
                clEdad.HorizontalAlignment = centrado;
                tblIncidente.AddCell(clEdad);

            }

            doc.Add(tblIncidente);

            doc.Add(Chunk.NEWLINE);

            //Firmas
            PdfPTable tblFirmas = new PdfPTable(2);
            tblIncidente.WidthPercentage = 100;
            PdfPCell clDirecto = new PdfPCell(new Phrase(director.NombreCompleto, _tituloTabla));
            clDirecto.HorizontalAlignment = centrado;
            clDirecto.Border = 0;
            tblFirmas.AddCell(clDirecto);
            PdfPCell clSecretario = new PdfPCell(new Phrase(secretario.NombreCompleto, _tituloTabla));
            clSecretario.HorizontalAlignment = centrado;
            clSecretario.Border = 0;
            tblFirmas.AddCell(clSecretario);
            clDirecto = new PdfPCell(new Phrase("Directo", _tituloTabla));
            clDirecto.HorizontalAlignment = centrado;
            clDirecto.Border = 0;
            tblFirmas.AddCell(clDirecto);
            clSecretario = new PdfPCell(new Phrase("Secretario", _tituloTabla));
            clSecretario.HorizontalAlignment = centrado;
            clSecretario.Border = 0;
            tblFirmas.AddCell(clSecretario);
            //cerrar pdf 
            doc.Add(tblFirmas);
            doc.Close();
            writer.Close();

        }
    }
}
