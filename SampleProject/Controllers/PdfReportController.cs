using iTextSharp.text;
using iTextSharp.text.pdf;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace SampleProject.Controllers
{
    public class PdfReportController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult StaticPdfReport()
        {
            string path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/PdfReports/" + "dosya1.pdf");
            var stream = new FileStream(path, FileMode.Create);

            Document document = new Document(PageSize.A4);
            PdfWriter.GetInstance(document, stream);

            document.Open();

            Paragraph paragraph = new Paragraph("Ürünler Pdf Raporu");

            document.Add(paragraph);

            document.Close();

            return File("/PdfReports/dosya1.pdf", "application/pdf","dosya1.pdf");
        }

        public IActionResult StaticProductReport()
        {
            string path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/PdfReports/" + "dosya2.pdf");
            var stream = new FileStream(path, FileMode.Create);

            Document document = new Document(PageSize.A4);
            PdfWriter.GetInstance(document, stream);

            document.Open();

            PdfPTable pdftable = new PdfPTable(3);

            pdftable.AddCell("Ürün Adı");
            pdftable.AddCell("Açıklama");
            pdftable.AddCell("Fiyatı");

            pdftable.AddCell("Ayçiçek Yağı 2kg.");
            pdftable.AddCell("Açıklama1");
            pdftable.AddCell("85,00");

            pdftable.AddCell("Toshiba Laptop");
            pdftable.AddCell("Açıklama2");
            pdftable.AddCell("15.000");

            pdftable.AddCell("Nohut 500gr.");
            pdftable.AddCell("Açıklama3");
            pdftable.AddCell("35,00");

            document.Add(pdftable);

            document.Close();

            return File("/PdfReports/dosya2.pdf", "application/pdf", "dosya2.pdf");
        }
    }
}
